using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityStandardAssets.Utility;

public class RampMove : MonoBehaviour
{
    public Rigidbody RampPos;
    public Transform LeftPos, RightPos;
    public float speed,MoveSpeed;
    public bool LeftChk,RightChk;
    public float delay = 0.5f;
    public bool hold = false;
    float dis;
    public MakeChild Ball;
    public float BallSpeed;
    private void OnEnable()
    {
        LeftChk = true;
    }

    private void FixedUpdate()
    {
        if (Ball == null || Ball.Ball == null)
           return;
        if (LeftChk && !hold)
        {
            Vector3 currentPosition = RampPos.transform.position;

            // Lerp towards the target position
            Vector3 targetPosition = Vector3.Lerp(currentPosition, LeftPos.position, speed);

            // Calculate the velocity to move towards the target position
            Vector3 velocity = (targetPosition - currentPosition) / Time.fixedDeltaTime;

            // Apply the velocity to the rigidbody
            RampPos.linearVelocity = velocity.normalized * MoveSpeed;
             dis = Vector3.Distance(LeftPos.position, currentPosition);
            if (dis <= 0.1f)
            {
                LeftChk = false;
                hold = true;
                RightChk = true;
                RampPos.isKinematic = true;
            }

            if (Ball.Rig != null)
            {
                Ball.Rig.AddForce(LeftPos.forward * speed, ForceMode.Force);
            }

        }
        if (RightChk && !hold)
        {

            Vector3 currentPosition = RampPos.transform.position;

            // Lerp towards the target position
            Vector3 targetPosition = Vector3.Lerp(currentPosition, RightPos.position, speed);

            // Calculate the velocity to move towards the target position
            Vector3 velocity = (targetPosition - currentPosition) / Time.fixedDeltaTime;

            // Apply the velocity to the rigidbody
            RampPos.linearVelocity = velocity.normalized * MoveSpeed;
             dis = Vector3.Distance(RightPos.position, currentPosition);

            if (dis <= 0.1f)
            {
                LeftChk = true;
                hold = true;
                RightChk = false;
                RampPos.isKinematic = true;
            }
            if (Ball.Rig != null)
            {
                Ball.Rig.AddForce(LeftPos.forward * -speed, ForceMode.Force);
                BallSpeed = Ball.Rig.linearVelocity.magnitude;


                Debug.Log("Speed Value " + BallSpeed);
            }
        }
            Debug.Log("Speed Value " + BallSpeed);

        if (hold)
        {
            delay -= Time.deltaTime;
        }
        if(delay<=0 && hold)
        {
            hold = false;
            delay = 1f;
            RampPos.isKinematic = false;
        }
    }

    public void Left()
    {
        LeftChk = true;
        RightChk = false;
        hold = false;
    }
    public void Right()
    {
        LeftChk = false;
        RightChk = true;
        hold = false;
    }
    public void Hold()
    {
        hold = true;
    }

}

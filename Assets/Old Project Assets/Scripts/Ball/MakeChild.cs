using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MakeChild : MonoBehaviour
{
    public Transform ObjectParent;
    public Rigidbody Rig;
    public GameObject Ball;
    public float speed=1;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Ball = other.gameObject;
            //other.transform.SetParent(ObjectParent);
            other.TryGetComponent(out Rig);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Ball = null;
            //other.transform.parent = null;
        }
    }
    Vector3 currentPosition, PreviousPosition;

    //private void LateUpdate()
    //{
    //    if(Rig && Ball != null)
    //    {
    //        PreviousPosition = currentPosition;
    //        currentPosition = Ball.transform.position;
    //        // Lerp towards the target position
    //        Vector3 targetPosition = Vector3.Lerp(currentPosition, currentPosition,speed);

    //        // Calculate the velocity to move towards the target position
    //        Vector3 velocity = (targetPosition - currentPosition) / Time.deltaTime;

    //        // Apply the velocity to the rigidbody
    //        //Rig.velocity = velocity.normalized *speed ;
    //        Rig.MovePosition(Rig.transform.position);
           
    //    }
    //}
}

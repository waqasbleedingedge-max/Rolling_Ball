using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollerBall : MonoBehaviour
{
    public WheelCollider ballWheel1;
    public WheelCollider ballWheel2;
    public Transform wheelModel;
    float rotationSpeed;
    // Update is called once per frame
    [HideInInspector] public Vector3 wheelPosition = Vector3.zero;
    [HideInInspector] public Quaternion wheelRotation = Quaternion.identity;

    [HideInInspector] public float bumpForce, oldForce, RotationValue = 0f;
    private void Start()
    {
         
    }
    void Update()
    {
        float moveHorizontal = InputHandler.inputX;
        float moveVertical = InputHandler.inputY;
        float speed = InputHandler.inputZ;
       // Debug.Log("Speed =" + speed);
        Vector3 movement = new Vector3(moveVertical, 0.0f, -moveHorizontal);
       // Quaternion rot = Quaternion.Euler(movement);
        Quaternion rot = Quaternion.Euler(Vector3.left);
      
        // change direction according to movement direction
        //if (movement != Vector3.zero)
        //{
            Quaternion movementDir = Quaternion.LookRotation(movement, Vector3.up);
        // Transform t = new ;
        /// t.rotation = Quaternion.RotateTowards(transform.rotation, rot, rotationSpeed * Time.deltaTime);
        //}
        // float a=FindDegree(movement.x, movement.y);
         float a=FindDegree(moveHorizontal, moveVertical);
      //  Debug.Log("Degree =" + a);
        float i = Mathf.Clamp(0.02f, 0, speed);
        Debug.Log("i =" + i);
        ballWheel1.motorTorque = i;
        ballWheel1.steerAngle = a; 
        ballWheel2.motorTorque = i;
        ballWheel2.steerAngle = a;
    }
    public float FindDegree(float x, float y)
    {
        float value = (float)((System.Math.Atan2(x, y) / System.Math.PI) * 180f);
        if (value < 0) value += 360f;
        return value;
    }

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReachDestination : MonoBehaviour
{
    public Vector3 destination;
    public Transform TargetObj;
    Vector3 Dir = Vector3.zero;
    public float speed = 2f;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ChaseTarget();
    }

    private void ChaseTarget()
    {
       Dir=TargetObj.position-transform.position;
        Dir.Normalize();
        Vector3 dumyPos = transform.position + Dir;

        transform.position = Vector3.Lerp(transform.position,dumyPos,speed*Time.deltaTime);
        rb.position = transform.position;
        rb.rotation = transform.rotation;
    }
}

using NA.Vehicles.Ball;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakAbleBall : MonoBehaviour
{
    public AudioSource Audio;
    public bool BreakOnEnable = false;
    public GameObject OnObject, OffObject;
    public Collider Col;
    //public Rigidbody Rig;

    void OnEnable()
    {
        if (BreakOnEnable)
        {
            BreakBall();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent(out Ball ball))
        {
           

            Debug.Log("Collide");
            if(ball.CanBreakProps)
                BreakBall();
        }
    }


    public void BreakBall()
    {
        Col.enabled = false;
        //Destroy(Rig);
        OnObject.SetActive(true);
        OffObject.SetActive(false);
        Destroy(gameObject,2);
    }

}

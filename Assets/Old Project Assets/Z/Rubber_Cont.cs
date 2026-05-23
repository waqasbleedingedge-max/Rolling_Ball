using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rubber_Cont : MonoBehaviour
{
    public GameObject Temp;
    public AudioSource Audio;

    [Header("Player")]
    public Rigidbody Player_rb;
    public string Player_Name = "Player_Ball";
    public string Player_Collider = "Collider";

    [Header("Force")]
    public bool AddForce = false;
    public float forceAmount = 250f;
    //public Transform ForceDirection;
    public Vector3 forceDirection = Vector3.forward;
    public ForceMode forceMode = ForceMode.Force;

    void OnEnable()
    {
        Invoke(nameof(call), 0.1f);
    }
    void call()
    {
       // Player_rb = LevelManager.Instance.Player_Rb;
    }
    void OnTriggerEnter(Collider other)
    {
        Temp = other.gameObject;
        if (other.gameObject.name == Player_Name || other.gameObject.name == Player_Collider)
        {
            if (Audio != null)
            {
                Audio.Play();
            }
            AddForce = true;
            print("Rubber_Cont Enter_" + Temp);
        }
    }
    void OnTriggerExit(Collider other)
    {
        Temp = other.gameObject;
        if (other.gameObject.name == Player_Name || other.gameObject.name == Player_Collider)
        {
            AddForce = false;
            print("Rubber_Cont Exit_" + Temp);
        }
    }
    void FixedUpdate()
    {
        if (AddForce)
        {
            Player_rb.AddForce(forceDirection * forceAmount, forceMode);
            print("Rubber_Cont Force_" + Temp);
        }
    }
}
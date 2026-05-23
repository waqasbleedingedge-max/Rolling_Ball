using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone_Cont : MonoBehaviour
{
    public GameObject Temp;
    public AudioSource Audio;

    [Header("Player")]
    public string Player_Name = "Player_Ball";
    public string Player_Collider = "Collider";


    void OnEnable()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        Temp = collision.gameObject;
        if (collision.gameObject.name == Player_Name || collision.gameObject.name == Player_Collider)
        {
            if (Audio != null)
            {
                Audio.Play();
            }
            print("Stone_Cont Enter_" + Temp);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blades_Cont : MonoBehaviour
{
    public GameObject Temp;
    public AudioSource Audio;

    [Header("Player")]
    public string Player_Name = "Player_Ball";
    public string Player_Collider = "Collider";


    void OnEnable()
    {

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
            print("Stone_Cont Enter_" + Temp);
        }
    }
}

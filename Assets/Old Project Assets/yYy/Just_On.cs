using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Just_On : MonoBehaviour
{
    public bool On;
    public float Timer;
    public GameObject[] Just;
    
    void OnEnable()
    {
        On = true;
        Invoke(nameof(call),Timer);      
    }

    void call()
    {
        foreach (GameObject xXx in Just)
        {
            xXx.SetActive(true);
        }
    }
}
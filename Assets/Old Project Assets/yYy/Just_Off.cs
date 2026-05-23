using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Just_Off : MonoBehaviour
{
    public float _Timer;
    public GameObject _Off;

    void OnEnable()
    {
        Invoke(nameof(_call), _Timer);
    }

    void _call()
    {
        _Off.SetActive(false);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NA;

public class CarDrop : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
            {
            UiManager.Instance.LevelFailed();
        }
    }
}

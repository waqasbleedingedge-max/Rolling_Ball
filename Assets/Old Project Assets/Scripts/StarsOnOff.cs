using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsOnOff : MonoBehaviour
{
    public GameObject[] Stars;
    public int dummyNumber, dummyNumber2;
    private void OnEnable()
    {
        InvokeRepeating(nameof(StartsOn),1,4f);
    }
    

    void StartsOn()
    {
        Stars[dummyNumber].SetActive(false);
        Stars[dummyNumber2].SetActive(false);
        dummyNumber = Random.Range(0,Stars.Length);
        dummyNumber2 = Random.Range(0,Stars.Length);
        Stars[dummyNumber].SetActive(true);
        Stars[dummyNumber2].SetActive(true);
    }
}

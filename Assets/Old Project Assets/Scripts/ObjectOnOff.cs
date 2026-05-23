using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectOnOff : MonoBehaviour
{
    public GameObject[] On;
    public GameObject[] Off;
    public float OnDelay, OffDelay;
    public bool JustOn, JustOff;
    

    private void OnEnable()
    {
        if(JustOn)
        StartCoroutine(OnThings(OnDelay));
        if(JustOff)
            StartCoroutine(OffThings(OffDelay));
    }

    IEnumerator OnThings(float delay)
    {
        yield return new WaitForSecondsRealtime(delay);
        for (int i = 0; i < On.Length; i++)
        {
            if (On[i] != null)
                On[i].SetActive(true);
        }
    }
    IEnumerator OffThings(float delay)
    {
        yield return new WaitForSecondsRealtime(delay);
        for (int i = 0; i < Off.Length; i++)
        {
            if (Off[i] != null)
                Off[i].SetActive(false);
        }
    }

    private void OnDisable()
    {
        if(JustOn)
        for (int i = 0; i < On.Length; i++)
        {
            if(On[i]!=null)
                On[i].SetActive(false);
        }
        if(JustOff)
        for (int i = 0; i < Off.Length; i++)
        {
            if(Off[i]!=null)
                Off[i].SetActive(true);
        }
    }
}

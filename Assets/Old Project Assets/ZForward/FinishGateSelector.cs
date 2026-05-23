using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishGateSelector : MonoBehaviour
{

    private void OnEnable()
    {
        int a = Random.Range(1,3);

        transform.GetChild(a).gameObject.SetActive(true);
    }
}

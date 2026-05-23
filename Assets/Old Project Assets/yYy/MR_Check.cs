using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MR_Check : MonoBehaviour
{
    public bool _Active;
    MeshRenderer _mc;

    void OnEnable()
    {
        _mc = this.gameObject.GetComponent<MeshRenderer>();
        _mc.enabled = false;
        _Active = true;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BallForceSc : MonoBehaviour
{
    private void OnEnable()
    {
        transform.DOScale(1, .45f);
        Destroy(gameObject,5);
        //Rig.AddForce(Vector3.forward * ForceValue,ForceMode.Force);
    }
}

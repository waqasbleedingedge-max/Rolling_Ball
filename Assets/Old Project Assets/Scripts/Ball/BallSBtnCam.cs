using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BallSBtnCam : MonoBehaviour
{
    public float delayCall = 2f;
    int counter;
    public GameObject[] Balls;
    public Transform MovingObj;
    private void OnEnable()
    {
        InvokeRepeating(nameof(MoveNext),delayCall,delayCall);
    }

    void MoveNext()
    {
        if (counter < Balls.Length - 1)
        {
            counter++;
        }
        else
        {
            counter = 0;
        }

        MovingObj.DOLocalMoveZ(counter*5,1);

    }
    
}

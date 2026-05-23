using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallRotatorInBar : MonoBehaviour
{
    public Slider sliderVal;
    public Transform BallImage;
    public float RotateValue=1000;

    public void OnValueChange()
    {
        BallImage.transform.rotation=Quaternion.Euler(0,0,sliderVal.value*-RotateValue);
    }
}

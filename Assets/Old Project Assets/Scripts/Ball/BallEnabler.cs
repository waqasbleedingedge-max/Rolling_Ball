using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallEnabler : MonoBehaviour
{
    public GameObject[] Balls;


    private void OnEnable()
    {
        for (int i = 0; i < Balls.Length; i++)
        {
            Balls[i].SetActive(false);
        }

        Balls[PlayerPrefs.GetInt("selectedball")].SetActive(true);
    }
}

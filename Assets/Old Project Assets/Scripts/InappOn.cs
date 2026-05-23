using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InappOn : MonoBehaviour
{
    public GameObject InApp, NextPanel;

    private void OnEnable()
    {
        if (PlayerPrefs.GetInt("UnlockAll") == 1)
        {
            NextPanel.SetActive(true);
            InApp.SetActive(false);
        }
        else
        {
            NextPanel.SetActive(false);
            InApp.SetActive(true);
        }
    }
}

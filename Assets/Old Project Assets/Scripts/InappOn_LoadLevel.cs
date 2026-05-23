using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InappOn_LoadLevel : MonoBehaviour
{
    public GameObject InApp;

    void OnEnable()
    {
        if (PlayerPrefs.GetInt("Shop") == 1)
        {
            NextWork();
            InApp.SetActive(false);
        }
        else
        {
            InApp.SetActive(true);
        }
    }

    public void NextWork()
    {
       // LevelManager.Instance.LoadLevel();
    }
}
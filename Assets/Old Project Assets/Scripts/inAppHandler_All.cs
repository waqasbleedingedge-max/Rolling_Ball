using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inAppHandler_All : MonoBehaviour
{
    public bool IAP_Skip;
    [Header(".....Use For.....")]
    public bool Mode;
    public bool Level;
    public bool Ambulance;
    public bool Car;
    public bool Robot;
    public bool Environment;
    public bool Jumbo;

    [Header(".....Pannel.....")]
    public GameObject inApp_Pannel;
    public GameObject BG;

    void OnEnable()
    {
        if (IAP_Skip == true)
        {
            c_inApp_2_Pannel();
        }
        else
        {
            Check_IAP();
        }
    }
    public void c_inApp_2_Pannel()
    {
        inApp_Pannel.SetActive(false);
        BG.SetActive(true);
    }
    void Check_IAP()
    {
        // Mode
        if (Mode == true)
        {
            if (PlayerPrefs.GetInt("ModePurchased") == 0)
            {
                inApp_Pannel.SetActive(true); BG.SetActive(false);
            }
            if (PlayerPrefs.GetInt("ModePurchased") == 1)
            {
                c_inApp_2_Pannel();
            }
        }
        // Level
        if (Level == true)
        {
            if (PlayerPrefs.GetInt("LevelPurchased") == 0)
            {
                inApp_Pannel.SetActive(true); BG.SetActive(false);
            }
            if (PlayerPrefs.GetInt("LevelPurchased") == 1)
            {
                c_inApp_2_Pannel();
            }
        }
        // Amb
        if (Ambulance == true)
        {
            if (PlayerPrefs.GetInt("AmbPurchased") == 0)
            {
                inApp_Pannel.SetActive(true); BG.SetActive(false);
            }
            if (PlayerPrefs.GetInt("AmbPurchased") == 1)
            {
                c_inApp_2_Pannel();
            }
        }
        // Car
        if (Car == true)
        {
            if (PlayerPrefs.GetInt("CarPurchased") == 0)
            {
                inApp_Pannel.SetActive(true); BG.SetActive(false);
            }
            if (PlayerPrefs.GetInt("CarPurchased") == 1)
            {
                c_inApp_2_Pannel();
            }
        }
        // Robot
        if (Robot == true)
        {
            if (PlayerPrefs.GetInt("RoboPurchased") == 0)
            {
                inApp_Pannel.SetActive(true); BG.SetActive(false);
            }
            if (PlayerPrefs.GetInt("RoboPurchased") == 1)
            {
                c_inApp_2_Pannel();
            }
        }
        // Env
        if (Environment == true)
        {
            if (PlayerPrefs.GetInt("EnvPurchased") == 0)
            {
                inApp_Pannel.SetActive(true); BG.SetActive(false);
            }
            if (PlayerPrefs.GetInt("EnvPurchased") == 1)
            {
                c_inApp_2_Pannel();
            }
        }
        // Jumbo
        if (Jumbo == true)
        {
            if (PlayerPrefs.GetInt("Shop") == 0)
            {
                inApp_Pannel.SetActive(true); BG.SetActive(false);
            }

            if (PlayerPrefs.GetInt("Shop") == 1)
            {
                c_inApp_2_Pannel();
            }
        }
    }
}
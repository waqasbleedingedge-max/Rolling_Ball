using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ifBuy_All : MonoBehaviour
{
    static bool _rad;
    static bool _ua;
    public GameObject _IAP_Cog;

    public GameObject[] Restore_Button;

    [Header("Buy Ads")]
    public GameObject[] Remove_Button;

    [Header("Buy Mode")]
    public GameObject[] Mode_Button;

    [Header("Buy Level")]
    public GameObject[] Level_Button;

    [Header("Buy Ambo")]
    public GameObject[] Amb_Button;

    [Header("Buy Car")]
    public GameObject[] Car_Button;

    [Header("Buy Robo")]
    public GameObject[] Robo_Button;

    [Header("Buy Env")]
    public GameObject[] Env_Button;

    [Header("Buy Jumbo")]
    public GameObject[] Jumbo_Button;

    void OnEnable()
    {
        Check_IAP();
    }
    void _off()
    {
        _IAP_Cog.SetActive(false);
    }
    public void Check_IAP()
    {
        // removeAds
        if (PlayerPrefs.GetInt("RemoveAds") == 1)
        {
            for (int i = 0; i < Remove_Button.Length; i++)
            {
                Remove_Button[i].SetActive(false);
            }
            for (int i = 0; i < Restore_Button.Length; i++)
            {
                Restore_Button[i].SetActive(true);
            }
            //if (_rad == false)
            //{
            //    AdmobAdsManager_InfiSingle.Instance.Btn_IAP_Done();
            //    _rad = true;
            //    //_IAP_Cog.SetActive(true);
            //    //Invoke(nameof(_off),3f);
            //}
        }
        // Mode
        if (PlayerPrefs.GetInt("ModePurchased") == 1)
        {
            for (int i = 0; i < Mode_Button.Length; i++)
            {
                Mode_Button[i].SetActive(false);
            }
        }
        // Level
        if (PlayerPrefs.GetInt("LevelPurchased") == 1)
        {
            for (int i = 0; i < Level_Button.Length; i++)
            {
                Level_Button[i].SetActive(false);
            }
        }
        // Ambo
        if (PlayerPrefs.GetInt("AmbPurchased") == 1)
        {
            for (int i = 0; i < Amb_Button.Length; i++)
            {
                Amb_Button[i].SetActive(false);
            }
        }
        // Car
        if (PlayerPrefs.GetInt("CarPurchased") == 1)
        {
            for (int i = 0; i < Car_Button.Length; i++)
            {
                Car_Button[i].SetActive(false);
            }
        }
        // Robo
        if (PlayerPrefs.GetInt("RoboPurchased") == 1)
        {
            for (int i = 0; i < Robo_Button.Length; i++)
            {
              //  Robo_Button[i].SetActive(false);
            }
        }
        // Env
        if (PlayerPrefs.GetInt("EnvPurchased") == 1)
        {
            for (int i = 0; i < Env_Button.Length; i++)
            {
                Env_Button[i].SetActive(false);
            }
        }
        // Jumbo
        if (PlayerPrefs.GetInt("Shop") == 1)
        {
            for (int i = 0; i < Jumbo_Button.Length; i++)
            {
                Jumbo_Button[i].SetActive(false);
            }
            //if (_ua== false)
            //{
            //    AdmobAdsManager_InfiSingle.Instance.Btn_IAP_Done();
            //    _ua = true;
            //    //_IAP_Cog.SetActive(true);
            //    //Invoke(nameof(_off), 3f);
            //}
        }
        Invoke("Check_IAP", 1f);
    }

    int xXx;
    public void Btn_IAP_Restore()
    {
        xXx = PlayerPrefs.GetInt("coins");
        // PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        PlayerPrefs.SetInt("coins", xXx);

//Admob_other.Instance.AdRestore();
      //  Admob_other.Instance.Btn_InApp_Restore_Reload();
    }
}
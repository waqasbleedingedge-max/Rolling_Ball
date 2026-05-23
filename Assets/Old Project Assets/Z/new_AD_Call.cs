//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class new_AD_Call : MonoBehaviour
//{
//    public bool cCc;
//    public int Coin;
//    public Text[] All_Coin;

//    public bool Bann;
//    public bool MRec;
//    public bool Inter;
//    public bool Rew_AD;

//    [Header(" . . . Loading . . . ")]
//    public bool Load_Ban;
//    public bool Load_Med_Rec;
//    public bool Load_Rew;
//    public bool Load_Int;

//    [Header("Reward")]
//    public GameObject Reward;
//    public bool Game_Pannel;

//    [Header(" . . . GamePlay . . . ")]
//    public bool Hunting;

//    [Header("Gun")]
//    public GameObject Bg_Gun;
//    public bool Gun;

//    void OnEnable()
//    {
//        tsk();
//        if (Bann == true)
//        {
//            AdmobAdsManager_InfiSingle.Instance.ShowSmallAdaptiveBanner(GoogleMobileAds.Api.AdPosition.Top);
//        }
//        if (MRec == true)
//        {
//            AdmobAdsManager_InfiSingle.Instance.ShowMediumBanner(GoogleMobileAds.Api.AdPosition.BottomLeft);
//        }
//        if (Inter == true)
//        {
//            AdmobAdsManager_InfiSingle.Instance.ShowInterstitial();
//        }
//        if (Hunting == true)
//        {
//            AdmobAdsManager_InfiSingle.Instance.ShowSmallAdaptiveBanner(GoogleMobileAds.Api.AdPosition.Top);
//            AdmobAdsManager_InfiSingle.Instance.LoadInterstitial();
//            AdmobAdsManager_InfiSingle.Instance.hideMediumBanner();
//        }
//        loAd();
//    }
//    public void InT_Now()
//    {
//        AdmobAdsManager_InfiSingle.Instance.ShowInterstitial();
//    }
//    public void MRec_Now()
//    {
//        AdmobAdsManager_InfiSingle.Instance.ShowMediumBanner(GoogleMobileAds.Api.AdPosition.BottomLeft);
//    }
//    void loAd()
//    {
//        if (Load_Ban == true)
//        {
//            AdmobAdsManager_InfiSingle.Instance.ShowSmallAdaptiveBanner(GoogleMobileAds.Api.AdPosition.Top);
//        }
//        if (Load_Med_Rec == true)
//        {
//            AdmobAdsManager_InfiSingle.Instance.LoadMediumBanner();
//        }
//        if (Load_Int == true)
//        {
//            AdmobAdsManager_InfiSingle.Instance.LoadInterstitial();
//        }
//        if (Load_Rew == true)
//        {
//            AdmobAdsManager_InfiSingle.Instance.LoadRewardedVideo();
//        }
//    }
//    public void Btn_Get_Coin_Now()
//    {
//        if (Game_Pannel == true)
//        {
//            AdmobAdsManager_InfiSingle.Instance.hideMediumBanner();
//        }
//        PlayerPrefs.SetInt("LoadReward", 0);
//        Reward.SetActive(true);
//        if (Gun == true)
//        {
//            Bg_Gun.SetActive(false);
//        }
//        Invoke("waitAD_now", 1f);
//    }
//    void waitAD_now()
//    {
//       //dnt AdmobAdsManager_InfiSingle.Instance.ShowRewardedVideo(Chk_Coins);
//        if (PlayerPrefs.GetInt("LoadReward") == 0)
//        {
//          //dnt  AdmobAdsManager_InfiSingle.Instance.LoadRewardedVideo();
//            Invoke("waitAD_Later", 6f);
//        }
//        else
//        {
//            R_Off();
//        }
//    }
//    void waitAD_Later()
//    {
//       //dnt AdmobAdsManager_InfiSingle.Instance.ShowRewardedVideo(Chk_Coins);
//        if (PlayerPrefs.GetInt("LoadReward") == 0)
//        {
//            R_Off();
//        }
//        else
//        {
//            R_Off();
//        }
//    }
//    void Chk_Coins()
//    {
//        Coin = PlayerPrefs.GetInt("Coins");
//        Coin = Coin + Coin;
//        PlayerPrefs.SetInt("Coins", Coin);
//        if (Game_Pannel == true)
//        {
//            AdmobAdsManager_InfiSingle.Instance.ShowMediumBanner(GoogleMobileAds.Api.AdPosition.BottomLeft);
//        }
//    }
//    void tsk()
//    {
//        Coin = PlayerPrefs.GetInt("Coins");
//        if (cCc == true)
//        {
//            foreach (Text item in All_Coin)
//            {
//                item.GetComponent<Text>().text = ("$ " + Coin).ToString();
//            }
//            Invoke("tsk", 1f);
//        }
//    }
//    void OnDisable()
//    {
//        if (Inter == true)
//        {
//            //  AdmobAdsManager_InfiSingle.Instance.LoadInterstitial();
//        }
//        if (MRec == true)
//        {
//            AdmobAdsManager_InfiSingle.Instance.hideMediumBanner();
//        }
//    }
//    void R_Off()
//    {
//        if (Gun == true)
//        {
//            Bg_Gun.SetActive(true);
//        }
//        Reward.SetActive(false);
//    }
//}
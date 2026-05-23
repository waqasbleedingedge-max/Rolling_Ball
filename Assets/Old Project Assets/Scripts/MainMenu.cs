//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;
//using UnityEngine.SceneManagement;
//using MoreMountains.NiceVibrations;
//using NA;

//public class MainMenu : SimpleSingleton<MainMenu>
//{
//    // Start is called before the first frame update
//    //  public Text text;
//    // public AudioSource ASBG;
//    public GameObject MM;
//    public Slider soundsSlider;
//    public Slider musicSlider;
//    private void Start()
//    {
//        if(GameAppManager.Instance)
//        {

//            GameAppManager.Instance.ShowUnlockEverything();

//        }
//        //  int a = LevelSelection.abc;

//        if (CoinsManager.Instance)
//        {
//            CoinsManager.Instance.ShowCoins();
//        }
//        //text.text = PlayerPrefs.GetInt("coins").ToString();
//        if (SoundsManager.Instance)
//        {
//            Debug.Log("Play Sound");
//            SoundsManager.Instance.palyBGMusic();
//        }

//    }
//    public void Play()
//    {

//         if (PlayerPrefs.GetInt("haptics") == 0)
//          {
//             MMVibrationManager.Haptic(HapticTypes.HeavyImpact);
//          }

//        if (SoundsManager.Instance)
//        {
//            SoundsManager.Instance.ButtonClickPlay();
//        }

//        Debug.Log("Play pressed");
//        if(LoadingManager.Instance)
//        {
//            StartCoroutine(LoadingManager.Instance.LoadYourAsyncScene("ModeSelection",true));
//        }
//        MM.gameObject.SetActive(false);
//    }






//    public void MoreGAmes()
//    {
//        if (SoundsManager.Instance)
//        {
//            SoundsManager.Instance.ButtonClickPlay();
//        }
//        if (PlayerPrefs.GetInt("haptics") == 0)
//        {
//            MMVibrationManager.Haptic(HapticTypes.HeavyImpact);
//        }
//        Application.OpenURL("https://play.google.com/store/apps/developer?id=Soft+games");


//    }   

//    public void RateUs()
//    {
//        if (SoundsManager.Instance)
//        {
//            SoundsManager.Instance.ButtonClickPlay();
//        }
//        if (PlayerPrefs.GetInt("haptics") == 0)
//        {
//            MMVibrationManager.Haptic(HapticTypes.HeavyImpact);
//        }
//        Application.OpenURL("https://play.google.com/store/apps/developer?id=com.limo.multi.storey.car.parking");

//    }

//    public void PrivacyPolicy()
//    {
//        if (SoundsManager.Instance)
//        {
//            SoundsManager.Instance.ButtonClickPlay();
//        }
//        if (PlayerPrefs.GetInt("haptics") == 0)
//        {
//            MMVibrationManager.Haptic(HapticTypes.HeavyImpact);
//        }
//        Application.OpenURL("https://softgames112.blogspot.com/2019/02/soft-games-privacy-policy-privacy-of.html");



//    }

//    public void Quit()
//    {
//        if (SoundsManager.Instance)
//        {
//            SoundsManager.Instance.ButtonClickPlay();
//        }
//        if (PlayerPrefs.GetInt("haptics") == 0)
//        {
//            MMVibrationManager.Haptic(HapticTypes.HeavyImpact);
//        }
//        Application.Quit();
//    }

//    public void SoundSet()
//    {


//            PlayerPrefs.SetFloat("sounds", soundsSlider.value);
//            if (SoundsManager.Instance)
//            {
//                SoundsManager.Instance.SoundsVolume(soundsSlider.value);

//            }


//    } public void MusicSet()
//    {


//            PlayerPrefs.SetFloat("music", musicSlider.value);
//            if (SoundsManager.Instance)
//            {
//                SoundsManager.Instance.BGMusicVolume(musicSlider.value);

//            }


//    }

//    public void Haptics(bool a)
//    {
//        if (SoundsManager.Instance)
//        {
//            SoundsManager.Instance.ButtonClickPlay();
//        }
//        if (a)
//        {
//            PlayerPrefs.SetInt("haptics", 0);
//            if (PlayerPrefs.GetInt("haptics") == 0)
//            {
//                MMVibrationManager.Haptic(HapticTypes.HeavyImpact);
//            }
//        }
//        else
//        {
//            PlayerPrefs.SetInt("haptics", 1);
//        }
//    }

//    public void UnlockAll()
//    {
//        GameAppManager.Instance.UnlockEverything();
//        if (PlayerPrefs.GetInt("haptics") == 0)
//        {
//            MMVibrationManager.Haptic(HapticTypes.HeavyImpact);
//        }

//    }

//    public void OpenShop()
//    {
//        GameAppManager.Instance.ShowShop();
//    }

//    public void ButtonClickSound()
//    {
//        if (SoundsManager.Instance)
//        {
//            SoundsManager.Instance.ButtonClickPlay();
//        }
//        if (PlayerPrefs.GetInt("haptics") == 0)
//        {
//            MMVibrationManager.Haptic(HapticTypes.HeavyImpact);
//        }


//    }

//    public void RemoveAds()
//    {
//        ButtonClickSound();
//        GameAppManager.Instance.Buy_noAds();

//    }

//    public void VideoAdReward()
//    {
//        if (SoundsManager.Instance)
//        {
//            SoundsManager.Instance.ButtonClickPlay();
//        }
//        if (PlayerPrefs.GetInt("haptics") == 0)
//        {
//            MMVibrationManager.Haptic(HapticTypes.HeavyImpact);
//        }
//        if (Application.internetReachability == NetworkReachability.NotReachable)
//        {
//            Debug.Log("Internet Not Connected");
//        }
//        else
//        {
//            AdmobAdsManager_InfiSingle.Instance.LoadRewardedVideo();
//            Invoke("waitAD_now",0.2f);

//        }

//    }
//    void waitAD_now()
//    {
//        //dnt AdmobAdsManager_InfiSingle.Instance.ShowRewardedVideo(GetCoins);
//        if (PlayerPrefs.GetInt("LoadReward") == 0)
//        {
//            AdmobAdsManager_InfiSingle.Instance.LoadRewardedVideo();
//            Invoke("waitAD_Later", 6f);
//        }
//        else
//        {
//            //Reward.SetActive(false);
//        }
//    }
//    void waitAD_Later()
//    {
//        //dnt AdmobAdsManager_InfiSingle.Instance.ShowRewardedVideo(GetCoins);
//        if (PlayerPrefs.GetInt("LoadReward") == 0)
//        {
//           // Reward.SetActive(false);
//        }
//        else
//        {

//          //  Reward.SetActive(false);
//        }
//    }


//    void GetCoins()
//    {
//        CoinsManager.Instance.AddCoins(CoinsManager.Instance.coins);
//      //  MainAdsManagerController.instance.removeall_rewardevent();
//    }

//    public void CLickSound()
//    {
//        if(SoundsManager.Instance)
//        {
//            SoundsManager.Instance.ButtonClickPlay();
//        }
//    }
//}

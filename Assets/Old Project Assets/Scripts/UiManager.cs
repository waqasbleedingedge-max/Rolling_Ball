using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//using MoreMountains.NiceVibrations;

namespace NA
{
    public class UiManager : SimpleSingleton<UiManager>
    {

        public GameObject canvas;
        public GameObject cameraRCC;
        public GameObject cameraCine;
        public Text onCompleteRewardText;
        public Text onCompleteRewardTotalText;
        public static bool isPlaying;
        public Text screenPositionText;
        // public RCC_CarControllerV3 player;
        private bool AD;
        bool rccControlls;
        private void Start()
        {
            //player = GameObject.FindWithTag("Player").GetComponent<RCC_CarControllerV3>();
            isPlaying = true;
            //  SwitchControlsRight(false);
            //  SoundsManager.Instance.BGMusicVolume(0.3f);
        }

        public void GamePaused()
        {
            if (SoundsManager.Instance)
            {
                SoundsManager.Instance.ButtonClickPlay();
            }
            if (PlayerPrefs.GetInt("haptics") == 0)
            {
                //MMVibrationManager.Haptic(HapticTypes.HeavyImpact);
            }
            if (Application.internetReachability == NetworkReachability.NotReachable)
            {
                Debug.Log("Internet Not Connected");
            }
            else
            {
                //   AdmobAdsManager_InfiSingle.Instance.LoadInterstitial();
                Invoke("Task1", 0.50f);
                Invoke("Task2", 2.0f);

            }
            ReferenceManager.Instance.pausePanel.SetActive(true);
            //   ReferenceManager.Instance.gamePlayPanel.SetActive(false);

            Time.timeScale = 0.001f;
        }

        public void Resume()
        {
            if (SoundsManager.Instance)
            {
                SoundsManager.Instance.ButtonClickPlay();
            }
            if (PlayerPrefs.GetInt("haptics") == 0)
            {
                //MMVibrationManager.Haptic(HapticTypes.HeavyImpact);
            }
            ReferenceManager.Instance.pausePanel.SetActive(false);
            //  ReferenceManager.Instance.gamePlayPanel.SetActive(true);

            Time.timeScale = 1f;
            Check();
        }

        public void Next()
        {
            if (SoundsManager.Instance)
            {
                SoundsManager.Instance.ButtonClickPlay();
            }
            if (PlayerPrefs.GetInt("haptics") == 0)
            {
                //MMVibrationManager.Haptic(HapticTypes.HeavyImpact);
            }
           // LevelManager.Instance.IncreaseLevel();
            //if (PlayerPrefs.GetInt("CurrentLevel")>=4)
            //{
            //    PlayerPrefs.SetInt("CurrentLevel", Random.Range(0,4));
            //}
            //else
            //{
            //   LevelManager.Instance.IncreaseLevel();
            //}
            Check();

            if (LoadingManager.Instance)
            {
                StartCoroutine(LoadingManager.Instance.LoadYourAsyncScene("GamePlay", false));
                //   if (PlayerPrefs.GetInt("CurrentLevel") >= 0 && PlayerPrefs.GetInt("CurrentLevel") < 5)
                // {
                //     StartCoroutine(LoadingManager.Instance.LoadYourAsyncScene("GamePlay"));
                //   }
                //   else if (PlayerPrefs.GetInt("CurrentLevel") > 4 && PlayerPrefs.GetInt("CurrentLevel") < 10)
                //  {
                //      StartCoroutine(LoadingManager.Instance.LoadYourAsyncScene("GamePlay" + (PlayerPrefs.GetInt("CurrentLevel") % 5 + 2)));
                //  }

            }
        }

        public void LevelFailed()
        {
            if (Application.internetReachability == NetworkReachability.NotReachable)
            {
                Debug.Log("Internet Not Connected");
            }
            else
            {
                // AdmobAdsManager_InfiSingle.Instance.LoadInterstitial();
                //  Invoke("Task1", 0.50f);
                //   Invoke("Task2", 2.0f);

            }
            isPlaying = false;
            // Camera.main.gameObject.GetComponent<AudioListener>().enabled = false;
            ReferenceManager.Instance.failedPanel.SetActive(true);
            ReferenceManager.Instance.gamePlayPanel.SetActive(false);
        }

        public void LevelComplete()
        {
            if (Application.internetReachability == NetworkReachability.NotReachable)
            {
                Debug.Log("Internet Not Connected");
            }
            else
            {


                //    AdmobAdsManager_InfiSingle.Instance.LoadInterstitial();
                //    Invoke("Task1", 0.50f);


                //    Invoke("Task2",2.0f);

            }
            isPlaying = false;
            //  onCompleteRewardText.text = CoinsManager.Instance.levelsRewards[PlayerPrefs.GetInt("CurrentLevel")].ToString();
            //    PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins") + CoinsManager.Instance.levelsRewards[PlayerPrefs.GetInt("CurrentLevel")]);
            //  Debug.Log("Current Level : "+ PlayerPrefs.GetInt("CurrentLevel") + "Unlocked Level : " + PlayerPrefs.GetInt("unlockedLevels"));
            Activity.Instance.player.gameObject.SetActive(false);
            if (ReferenceManager.Instance.StarterPlayer.activeInHierarchy)
            {
                ReferenceManager.Instance.StarterPlayer.SetActive(false);
            }
            //Destroy(Activity.Instance.player.gameObject.SetActive(false);
            if (PlayerPrefs.GetInt("unlockedLevels") == PlayerPrefs.GetInt("CurrentLevel"))
            {
                PlayerPrefs.SetInt("unlockedLevels", PlayerPrefs.GetInt("unlockedLevels") + 1);
            }
            ReferenceManager.Instance.completePanel.SetActive(true);
            ReferenceManager.Instance.gamePlayPanel.SetActive(false);
            //   SoundsManager.Instance.BGMusicUnPause();
            // Debug.Log("Current Level : " + PlayerPrefs.GetInt("CurrentLevel") + "Unlocked Level : " + PlayerPrefs.GetInt("unlockedLevels"));
        }

        public void Restart()
        {
            Time.timeScale = 1;
            if (SoundsManager.Instance)
            {
                SoundsManager.Instance.ButtonClickPlay();
            }
            if (PlayerPrefs.GetInt("haptics") == 0)
            {
                //MMVibrationManager.Haptic(HapticTypes.HeavyImpact);
            }
            if (LoadingManager.Instance)
            {
                Scene scene = SceneManager.GetActiveScene();
                StartCoroutine(LoadingManager.Instance.LoadYourAsyncScene(scene.name, false));
            }
            Check();

        }


        public void MainMenu()
        {
            Time.timeScale = 1;
            if (SoundsManager.Instance)
            {
                SoundsManager.Instance.ButtonClickPlay();
            }
            if (PlayerPrefs.GetInt("haptics") == 0)
            {
                //MMVibrationManager.Haptic(HapticTypes.HeavyImpact);
            }
            if (LoadingManager.Instance)
            {
                StartCoroutine(LoadingManager.Instance.LoadYourAsyncScene("MainMenu", false));
            }
            Check();
        }
        public void StartRace()
        {
            cameraRCC.SetActive(true);
            // cameraCine.SetActive(false);
            canvas.SetActive(true);
            // Debug.Log("Start Game");
            //   Activity.Instance.player.GetComponent<RCC_CarControllerV3>().canControl = true;


        }

        public void RaceFinish()
        {
            //  cameraRCC.GetComponent<RCC_Camera>().enabled = false;
        }

        public void NOSOnOff(bool a)
        {
            FunctionCallingPlayer.Instance.NosONOFF(a);
        }


        public void SwitchControlls()
        {

            if (!rccControlls)
            {
                ReferenceManager.Instance.RCCCamera.SetActive(true);
                ReferenceManager.Instance.RCCCanvas.SetActive(true);
                ReferenceManager.Instance.RCCPlayer.SetActive(true);
                ReferenceManager.Instance.StarterCamera.SetActive(false);
                ReferenceManager.Instance.StarterCanvas.SetActive(false);
                ReferenceManager.Instance.StarterPlayer.SetActive(false);
                ReferenceManager.Instance.StarterFollowCamera.SetActive(false);
                rccControlls = true;
            }
            else
            {
                ReferenceManager.Instance.RCCCamera.SetActive(false);
                ReferenceManager.Instance.RCCCanvas.SetActive(false);
                ReferenceManager.Instance.RCCPlayer.SetActive(false);
                ReferenceManager.Instance.StarterCamera.SetActive(true);
                ReferenceManager.Instance.StarterCanvas.SetActive(true);
                ReferenceManager.Instance.StarterPlayer.SetActive(true);
                ReferenceManager.Instance.StarterFollowCamera.SetActive(true);
                rccControlls = false;
            }
        }

        public void CotrollsSet()
        {

        }

        public void SwitchRCCControlsLeft(bool a)
        {
            if (a)
            {
                //  RCC_Settings.Instance.mobileController = RCC_Settings.MobileController.TouchScreen;
            }
            else
            {
                //RCC_Settings.Instance.mobileController = RCC_Settings.MobileController.SteeringWheel;
            }

        }




        public void VideoAdReward()
        {
            if (SoundsManager.Instance)
            {
                SoundsManager.Instance.ButtonClickPlay();
            }
            if (PlayerPrefs.GetInt("haptics") == 0)
            {
                //MMVibrationManager.Haptic(HapticTypes.HeavyImpact);
            }
            if (Application.internetReachability == NetworkReachability.NotReachable)
            {
                Debug.Log("Internet Not Connected");
            }
            else
            {

                //dnt  AdmobAdsManager_InfiSingle.Instance.LoadRewardedVideo();
                Invoke("waitAD_now", 0.2f);

            }

        }
        void waitAD_now()
        {
            //dnt  AdmobAdsManager_InfiSingle.Instance.ShowRewardedVideo(GetCoins);
            if (PlayerPrefs.GetInt("LoadReward") == 0)
            {
                //dnt   AdmobAdsManager_InfiSingle.Instance.LoadRewardedVideo();
                Invoke("waitAD_Later", 3f);
            }

        }
        void waitAD_Later()
        {
            //dnt AdmobAdsManager_InfiSingle.Instance.ShowRewardedVideo(GetCoins);

        }

        void GetCoins()
        {
            //  PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins") + CoinsManager.Instance.levelsRewards[PlayerPrefs.GetInt("CurrentLevel")]);

            //MainAdsManagerController.instance.removeall_rewardevent();
        }
        void Task1()
        {
            //    AdmobAdsManager_InfiSingle.Instance.ShowInterstitial();
        }
        void Task2()
        {
            //  AdmobAdsManager_InfiSingle.Instance.LoadMediumBanner();

            //   AdmobAdsManager_InfiSingle.Instance.ShowMediumBanner(GoogleMobileAds.Api.AdPosition.BottomLeft);
            AD = true;
        }
        void Check()
        {
            if (AD == true)
            {
                // AdmobAdsManager_InfiSingle.Instance.hideMediumBanner();
            }
            //  This_P.SetActive(false);
            //  Next_P.SetActive(true);
        }

    }
}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using MoreMountains.NiceVibrations;
using NA;
//using TMPro;

public class LevelSelection : MonoBehaviour
{
    // public static int abc;
    public Button playButton;
    public Button[] levelButtons;

    public GameObject uI;


    public GameObject tMP;


    void Start()
    {
        Init();
    }
    public void Init()
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            Debug.Log("Internet Not Connected");
        }
        else
        {
            // Adscaller.instance.show_AdmobInsterstitial();
        }
        // PlayerPrefs.SetInt("unlockedLevels", 4);


        for (int i = 0; i < levelButtons.Length; i++)
        {

            if (i == 0 && PlayerPrefs.GetInt("unlockedLevels") == 0)
            {

                levelButtons[i].transform.GetChild(0).gameObject.SetActive(false);
                levelButtons[i].transform.GetChild(1).gameObject.SetActive(true);
                levelButtons[i].transform.GetChild(2).gameObject.SetActive(true);
                int a = i;
                a++;
                levelButtons[i].transform.GetChild(3).gameObject.GetComponent<Text>().text = a.ToString();

                int levelIndex = i;


                levelButtons[i].onClick.RemoveAllListeners();
                levelButtons[i].onClick.AddListener(() => LoadLevel(levelIndex));

            }
            else if (i < PlayerPrefs.GetInt("unlockedLevels"))
            {



                levelButtons[i].interactable = true;
                int levelIndex = i;


                levelButtons[i].onClick.RemoveAllListeners();
                levelButtons[i].onClick.AddListener(() => LoadLevel(levelIndex));

                levelButtons[i].transform.GetChild(0).gameObject.SetActive(false);
                levelButtons[i].transform.GetChild(1).gameObject.SetActive(true);
                levelButtons[i].transform.GetChild(2).gameObject.SetActive(false);
                int a = i;
                a++;
                levelButtons[i].transform.GetChild(3).gameObject.GetComponent<Text>().text = a.ToString();

            }
            else if (i == PlayerPrefs.GetInt("unlockedLevels"))
            {
                levelButtons[i].interactable = true;
                int levelIndex = i;


                levelButtons[i].onClick.RemoveAllListeners();
                levelButtons[i].onClick.AddListener(() => LoadLevel(levelIndex));

                levelButtons[i].transform.GetChild(0).gameObject.SetActive(false);
                levelButtons[i].transform.GetChild(1).gameObject.SetActive(false);
                levelButtons[i].transform.GetChild(2).gameObject.SetActive(true);
                int a = i;
                a++;
                levelButtons[i].transform.GetChild(3).gameObject.GetComponent<Text>().text = a.ToString();
            }
            else if (i == PlayerPrefs.GetInt("unlockedLevels") + 1)
            {
                levelButtons[i].interactable = true;
                int levelIndex = i;


                levelButtons[i].onClick.RemoveAllListeners();
                levelButtons[i].onClick.AddListener(() => VideoAdRewardLevelUnlock(levelIndex));

                levelButtons[i].transform.GetChild(0).gameObject.SetActive(false);
                levelButtons[i].transform.GetChild(1).gameObject.SetActive(false);
                levelButtons[i].transform.GetChild(2).gameObject.SetActive(false);
                levelButtons[i].transform.GetChild(3).gameObject.SetActive(false);
                levelButtons[i].transform.GetChild(5).gameObject.SetActive(true);
            }
            else
            {

                levelButtons[i].interactable = false;
                levelButtons[i].transform.GetChild(0).gameObject.SetActive(true);
                levelButtons[i].transform.GetChild(1).gameObject.SetActive(false);
                levelButtons[i].transform.GetChild(2).gameObject.SetActive(false);
                levelButtons[i].transform.GetChild(3).gameObject.SetActive(false);


            }
        }


    }

    public void LoadLevel(int n)
    {
        Debug.Log(" Level index = " + n);

        if (SoundsManager.Instance)
        {
            SoundsManager.Instance.ButtonClickPlay();
        }

        if (PlayerPrefs.GetInt("haptics") == 0)
        {
            //MMVibrationManager.Haptic(HapticTypes.HeavyImpact);
        }
        if (n < 0)
        {
            PlayerPrefs.SetInt("CurrentLevel", n);
        }
        else
        {
            PlayerPrefs.SetInt("CurrentLevel", n);
        }

        StartCoroutine(LoadingManager.Instance.LoadYourAsyncScene("Garage", true));
        uI.SetActive(false);
        // playButton.gameObject.SetActive(true);
        // playButton.onClick.RemoveAllListeners();
        //   playButton.onClick.AddListener(LoadLevelButton);

    }

    public void LoadLevelButton()
    {

        StartCoroutine(LoadingManager.Instance.LoadYourAsyncScene("Garage", true));
        uI.SetActive(false);
    }

    public void MainMenu()
    {
        if (PlayerPrefs.GetInt("haptics") == 0)
        {
            //MMVibrationManager.Haptic(HapticTypes.HeavyImpact);
        }

        if (SoundsManager.Instance)
        {
            SoundsManager.Instance.ButtonClickPlay();
        }

        Debug.Log("Play pressed");
        if (LoadingManager.Instance)
        {
            StartCoroutine(LoadingManager.Instance.LoadYourAsyncScene("ModeSelection", false));
            uI.SetActive(false);
        }
    }


    public void unlockLevels()
    {
        //  GameAppManager.Instance.UnlockAllLevels();
    }

    public void VideoAdRewardLevelUnlock(int Index)
    {

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

            //  AdmobAdsManager_InfiSingle.Instance.LoadRewardedVideo();
            //dnt Invoke("waitAD_now", 0.2f);

        }

    }
    public int Cc;
    public void PrintNumber(int c)
    {
        Cc = c;
        Debug.Log(" Number 1= " + c);
        Debug.Log(" Number = " + Cc);
        print("aaaa = " + c);
        print("aaaabbbb = " + Cc);
    }

    void waitAD_now()
    {
        //dnt   AdmobAdsManager_InfiSingle.Instance.ShowRewardedVideo(UnlockCar);
        if (PlayerPrefs.GetInt("LoadReward") == 0)
        {
            //dnt  AdmobAdsManager_InfiSingle.Instance.LoadRewardedVideo();
            Invoke("waitAD_Later", 3f);
        }

    }
    void waitAD_Later()
    {
        //dnt  AdmobAdsManager_InfiSingle.Instance.ShowRewardedVideo(UnlockCar);

    }


    void UnlockCar()
    {
        LoadLevel(PlayerPrefs.GetInt("unlockedLevels") + 1);
        Init();
    }
    public void DoubleReward(int Index)
    {

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
            Invoke("waitAD_now1", 0.2f);

        }

    }
    void waitAD_now1()
    {
        //dnt AdmobAdsManager_InfiSingle.Instance.ShowRewardedVideo(GetCoins);
        if (PlayerPrefs.GetInt("LoadReward") == 0)
        {
            //dnt   AdmobAdsManager_InfiSingle.Instance.LoadRewardedVideo();
            Invoke("waitAD_Later1", 3f);
        }

    }
    void waitAD_Later1()
    {
        //dnt AdmobAdsManager_InfiSingle.Instance.ShowRewardedVideo(GetCoins);

    }


    void GetCoins()
    {
        CoinsManager.Instance.AddCoins(CoinsManager.Instance.coins);
        // MainAdsManagerController.instance.removeall_rewardevent();
    }


}

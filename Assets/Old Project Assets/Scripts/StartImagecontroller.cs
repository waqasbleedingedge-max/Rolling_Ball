using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using NA;
public class StartImagecontroller : MonoBehaviour
{
    public GameObject myLoad, AddLoder, PrivacyObj;
   // string filePath = "", imagePath = "";
    Sprite tempaddsprite;
    //public Sprite AccImg, GameImg;
    public GameObject logo;
    // Use this for initialization
    public int time;

    public GameObject video;

    public VideoPlayer vp;

    void Awake()
    {

        if (PlayerPrefs.GetInt("GDPRConsentAd") == 0)
        {
            PrivacyObj.SetActive(true);
         //   myLoad.SetActive(false);
          //  video.SetActive(false);
            Debug.Log("GDPR 0");
            // Invoke("StopVideo", 12f);
            PlayerPrefs.SetFloat("music", 1);
            PlayerPrefs.SetFloat("sounds", 1);
        }
        else
        {
            Debug.Log("GDPR 1");
            PrivacyObj.SetActive(false);
          //  video.SetActive(true);
          //  myLoad.SetActive(true);
           // AddLoder.SetActive(true);
            vp.Play();
            Debug.Log("GDPR Else");
            Invoke("LogoActivator", 14f);
        }
    }

    void LogoActivator()
    {
        myLoad.SetActive(true);
        logo.SetActive(true);
        CoinsManager.Instance.ActivateCoinsCanvas();
       // video.SetActive(false);
        Invoke("StartLoading", 5f);
    }
    void StopVideo()
    {
        video.SetActive(false);
    }
    void my_LoaD()
    {
        LoadingManager.Instance.LoadYourAsyncScene("MainMenu", false);
    }
    public void StartLoading()
    {
        if (LoadingManager.Instance)
        {
            StartCoroutine(LoadingManager.Instance.LoadYourAsyncScene("MainMenu", false));
        }
    }

    public void On_NativeBanRun()
    {
    }
    public void On_AgreeButton()
    {
        Debug.Log("GDPR Agree");
        PlayerPrefs.SetInt("GDPRConsentAd", 1);
        PrivacyObj.SetActive(false);
       // myLoad.SetActive(true);
      //  video.SetActive(true);
       
        PrivacyObj.SetActive(false);
        //  video.SetActive(true);
        //  myLoad.SetActive(true);
       // AddLoder.SetActive(true);
        vp.Play();
        Debug.Log("GDPR Else");
        Invoke("LogoActivator", 14f);
        //Invoke("LogoActivator", 3f);
        //self   LoadingManager.Instance.LoadYourAsyncScene("MainMenu", false);
    }

    public void On_PrivacyButton()
    {
        Application.OpenURL("https://softgames112.blogspot.com/2019/02/soft-games-privacy-policy-privacy-of.html");
    }
   // public void LogoActivator()
  //  {
        //logo.SetActive(true);
 //  }
}
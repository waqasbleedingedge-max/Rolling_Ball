using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using NA;

public class LoadingManager : Singleton<LoadingManager>
{
    public GameObject canvas;
    public Slider loadingBar;
    public Text progressText;
    private float currentValue;
    private float targetValue;
    private bool AD;

    [SerializeField]
    [Range(0, 1)]
    private float progressAnimationMultiplier = 0.25f;


    void OnEnable()
    {
        Debug.Log("OnEnable called");
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        HideLoading();
        Debug.Log("OnSceneLoaded: " + scene.name);
        Debug.Log(mode);
    }

    void OnDisable()
    {
        Debug.Log("OnDisable");
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void ShowLoading()
    {
        canvas.SetActive(true);
    }
    public void HideLoading()
    {
        canvas.SetActive(false);
    }

    public IEnumerator LoadYourAsyncScene(string scene,bool interstetial)
    {
        Debug.Log("Load " + scene);
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            Debug.Log("Internet Not Connected");
        }
        else if(interstetial)
        {
            if (Application.internetReachability == NetworkReachability.ReachableViaCarrierDataNetwork || Application.internetReachability == NetworkReachability.ReachableViaLocalAreaNetwork)
            {
                //if (PlayerPrefs.GetInt("Shop") == 0)
                //{
                //    AdmobAdsManager_InfiSingle.Instance.LoadInterstitial();
                //    Invoke("task1", 0.5f);
                //    Invoke("task2", 2f);
                //    Invoke("chk",5);
                //}
               

            }
          

        }
       
    
        if (scene == "GamePlay")
        {
            CoinsManager.Instance.canvas.SetActive(false);

        }
        else
        {
            CoinsManager.Instance.canvas.SetActive(true);
        }

       // canvas.SetActive(true);
        while (Application.internetReachability == NetworkReachability.NotReachable)
        {
            yield return null;
        }

        yield return null;

        currentValue = targetValue = 0;
        ShowLoading();
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(scene);

        asyncLoad.allowSceneActivation = false;
        Debug.Log("Pro :" + asyncLoad.progress);

       // Debug.Log("Connection done");

      //  AsyncOperation operation = SceneManager.LoadSceneAsync(scene);

        while (!asyncLoad.isDone)
        {
            targetValue = asyncLoad.progress / 0.9f;

            currentValue = Mathf.MoveTowards(currentValue, targetValue, progressAnimationMultiplier * Time.deltaTime);

            float loaded = (currentValue * 100);
            progressText.text = loaded.ToString("F0") + "%";
            loadingBar.value = loaded;

            if (Mathf.Approximately(currentValue, 1))
            {
                asyncLoad.allowSceneActivation = true;
               
            }
            yield return null;
            
        }
       
        Debug.Log("loading false");

    //    canvas.SetActive(false);
    }
// void task1()
//{
//    AdmobAdsManager_InfiSingle.Instance.ShowInterstitial();
//}
//void task2()
//{
//       AdmobAdsManager_InfiSingle.Instance.LoadMediumBanner();

//    AdmobAdsManager_InfiSingle.Instance.ShowMediumBanner(GoogleMobileAds.Api.AdPosition.BottomLeft);
//    AD = true;
//}
//void chk()
//{
//        if (AD == true)
//        {
//            AdmobAdsManager_InfiSingle.Instance.hideMediumBanner();
//        }
//        //This_P.SetActive(false);
//        //Next_P.SetActive(true);
//    }
}

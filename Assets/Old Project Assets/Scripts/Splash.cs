
using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//using TMPro;

public class Splash : MonoBehaviour
{
    [Space(5)]
    public bool AppOpen;
    public float A0_Load;
    public float A0_Show;

    [Space(5)]
    public bool ABCD;
    public bool Scene;
    public float Timer;
    public GameObject Next;

    // public GameObject agePanel;
    //public GameObject consentPanel;
    //public Text ageText;
    //public Slider slider;
    public Slider loadingBar;
    public Text progressText;
    private float currentValue;
    private float targetValue;
    public static bool WelComeOn;
    [SerializeField]
    [Range(0, 1)]
    private float progressAnimationMultiplier = 0.25f;
    // Start is called before the first frame update

    void Awake()
    {
        if (PlayerPrefs.GetInt("coins") == 0)
        {
            PlayerPrefs.SetInt("coins", 50);
        }
    }

    void OnEnable()
    {
        print("Call_ OnE");
        _Start();

        WelComeOn = true;
        if (PlayerPrefs.GetInt("onStartFirstTime", 0) == 0)
        {
            PlayerPrefs.SetInt("onStartFirstTime", 1);
        }
    }

    void _Start()
    {
        if (ABCD == true)
        {
            print("Call_ True");
            Invoke(nameof(call), Timer);
        }
        else
        {
            print("Call_ False");

            Invoke(nameof(App_Load), A0_Load);
            Invoke(nameof(App_Load), A0_Load + 2);
            Invoke(nameof(App_Show), A0_Show);

            Invoke(nameof(LoadNextScene), 12);

            //if (PlayerPrefs.GetInt("GDPRConsentAd") == 0)
            //{
            //    consentPanel.SetActive(true);
            //}
            //else
            //{
            // Invoke(nameof(ShowAppOpenAd), 6);
            //   StartCoroutine(LoadYourAsyncScene());
            //}

        }
    }
    void call()
    {
        if (Scene == true)
        {
            print("Call_ S=T Back");
            SceneManager.LoadScene("Back");
        }
        else
        {
            print("Call_ S=F Next");
            Next.SetActive(true);
        }

    }
    void ShowAppOpenAd()
    {
        //if (AdmobAdsManager_InfiSingle.Instance)
        //{
        //    AdmobAdsManager_InfiSingle.Instance.ShowAppOpenAd();
        //}
    }
    void bann()
    {
        // AdmobAdsManager_InfiSingle.Instance.ShowSmallBanner();
    }
    public void LoadNextScene()
    {
        print("Call_ Going Ball");
        SceneManager.LoadSceneAsync("going_ball");

    }

    public void ChangeValueToText()
    {
        //  ageText.text = (slider.value).ToString();
    }

    public void PP()
    {

    }

    public void YesNO()
    {
        //consentPanel.SetActive(false);
        PlayerPrefs.SetInt("GDPRConsentAd", 1);
        //Invoke("LoadNextScene", 5.0f);
        StartCoroutine(LoadYourAsyncScene());
    }
    public IEnumerator LoadYourAsyncScene()
    {
        // canvas.SetActive(true);
        while (Application.internetReachability == NetworkReachability.NotReachable)
        {
            yield return null;
        }

        yield return null;

        currentValue = targetValue = 0;
        // ShowLoading();
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("going_ball");

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


    }
    public void ChangeValueOFSlider(float value)
    {
        int Number = (int)value;
        if (Number < 99)
        {
            progressText.text = Number.ToString("F0") + "%";

        }
        else
        {
            progressText.text = "100%";

        }
    }
    void App_Load()
    {
        if (AppOpen == true)
        {
          //  AdmobAdsManager.Instance.LoadAppOpenAd();
        }

    }
    void App_Show()
    {
        if (AppOpen == true)
        {
            // AdmobAdsManager_Super.Instance.Show_Both_AppOpen();
           // AdmobAdsManager.Instance.ShowAppOpenAd();
        }
    }
}

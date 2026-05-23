using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using NA;
//using MoreMountains.NiceVibrations;

public class GiftFill : MonoBehaviour
{
    public GameObject Reward;

    private float fillAmount;
    public Image fillImage;
    public Button accel;
    public Button getGift;
    public Button noThanks;
    public Text fill;

    public Text rewardCoins;
    public GameObject rewardPanel;
    float fil;
    float timer;
    bool calculate = false;

    public GameObject giftOpenAnimBox;
    public GameObject giftraw;

    public GameObject completePanel;
    public GameObject questPanel;

    public AudioSource completeMusic;
    // public AudioSource giftSound;
    bool acce = false;
    // Start is called before the first frame update

    void Start()
    {
        fillAmount = PlayerPrefs.GetFloat("fillamount");
        fillImage.fillAmount = fillAmount;
        //if (AdmobAdsManager_InfiSingle.Instance != null)
        //{
        //    // AdmobAdsManager_InfiSingle.Instance.ShowInterstitial();
        //    //  AdmobAdsManager_InfiSingle.Instance.LoadInterstitial();
        //}

        Invoke("ActivateNoThanks", 4.0f);
        fil = fillAmount;

        StartCoroutine(Boxfiller(0.2f));
    }

    IEnumerator Boxfiller(float incrementValue)
    {
        yield return new WaitForSeconds(0.2f);
        incrementValue = fillAmount + incrementValue;
        while (fillAmount < incrementValue)
        {
            timer = Time.deltaTime;
            fillAmount += timer / 20;
            fillImage.fillAmount = fillAmount;
            fill.text = ((int)(fillAmount * 100)) + "%";
            if(fillAmount * 100<=100)
            {
                yield return null;
            }
           
        }
        accel.gameObject.SetActive(true);
        PlayerPrefs.SetFloat("fillamount", fillAmount);
        if (fillAmount >= 1f)
        {
            calculate = true;
            accel.gameObject.SetActive(false);
            getGift.gameObject.SetActive(true);
            PlayerPrefs.SetFloat("fillamount", 0.0f);
            fillAmount = 0;
        }
    }
    //private void Update()
    //{

    //    if (fillAmount >= 1f)
    //    {
    //        calculate = true;
    //        accel.gameObject.SetActive(false);
    //        getGift.gameObject.SetActive(true);
    //        PlayerPrefs.SetFloat("fillamount", 0.0f);
    //        fillAmount = 0;
    //    }
    //    else if (fillAmount<=fil+0.2f&& calculate ==false)
    //    {
    //        timer = Time.deltaTime;
    //        fillAmount += timer / 20;
    //        fillImage.fillAmount = fillAmount;
    //        fill.text = ((int)(fillAmount*100))+"%";
    //    }
    //    else if(calculate == false)
    //    {
    //        accel.gameObject.SetActive(true);
    //        getGift.gameObject.SetActive(false);
    //    }
    //    else if (acce && fillAmount <= fil + 0.2f) 
    //    {

    //      //  this.gameObject.SetActive(false);
    //      //  completePanel.SetActive(true);

    //    }



    //}
    int val;
    public void Refill()
    {
        SoundsManager.Instance.ButtonClickPlay();
        //MMVibrationManager.Haptic(HapticTypes.HeavyImpact);
        val = 1;
        Get_Coins();
    }

    public void OpenGift()
    {
        completeMusic.Stop();
        SoundsManager.Instance.ButtonClickPlay();
        //MMVibrationManager.Haptic(HapticTypes.HeavyImpact);
        val = 2;
        Get_Coins();
    }
    public void Get_Coins()
    {
        load_rew();
        Reward.SetActive(true);

        //Reward.transform.GetChild(1).gameObject.SetActive(true);
        //Reward.transform.GetChild(2).gameObject.SetActive(false);
        Invoke("waitAD_now", .5f);
    }
    void waitAD_now()
    {
        // Aqib

        show_rew();
        Reward.SetActive(false);
    }

    void Chk_Coins()
    {
        //?1? AdmobAdsManager_Infi.Instance.Btn_Reward_Done("You Have Done Reward Successfully");

        Reward.SetActive(false);
        if (val == 1)
        {
            Accelerate();
        }
        if (val == 2)
        {
            if(!IsInvoking(nameof(GiftReward)))
                 Invoke(nameof(GiftReward),2f);
        }

        //coin = PlayerPrefs.GetInt("Total_Currency");
        //coin = coin + coin;
        //PlayerPrefs.SetInt("Total_Currency", coin);
    }
    void NotRewardAlloat_Chk_Coins()
    {
        Reward.SetActive(false);
        
        
    }
    public void GiftReward()
    {


        int reward = 500;
        giftOpenAnimBox.SetActive(true);
        giftraw.SetActive(true);
        rewardCoins.text = reward.ToString();
        rewardPanel.SetActive(true);


        Invoke("CollectCoins", 3.0f);

    }

    public void CollectCoins()
    {
        CoinsManager.Instance.AddCoinsCounter(500);
    }


    public void Accelerate()
    {
        SoundsManager.Instance.ButtonClickPlay();
        //MMVibrationManager.Haptic(HapticTypes.HeavyImpact);
        StartCoroutine(Boxfiller(0.2f));
        // acce = true;
    }
    public void NoThanksDelay()
    {
        Invoke("Funk", 1.0f);
    }

    private void Funk()
    {

        noThanks.onClick.Invoke();
    }
    public void NoThanks()
    {
        SoundsManager.Instance.ButtonClickPlay();
        //MMVibrationManager.Haptic(HapticTypes.HeavyImpact);
        PlayerPrefs.SetFloat("fillamount", fillAmount);
        int a = PlayerPrefs.GetInt("CurrentLevel");
        if (a % 3 == 0)
        {
            questPanel.SetActive(true);
        }
        else
        {
            completePanel.SetActive(true);
            
        }
        // if(PlayerPrefs.GetInt("current"))
        // Time.timeScale = 1;
    }

    public void GetGift()
    {

    }
    public void ActivateNoThanks()
    {
        noThanks.gameObject.SetActive(true);
    }

    void load_rew()
    {
       // zWork.Instance.Btn_Load_Rew();
    }
    void show_rew()
    {
           //  zWork.Instance.Btn_Show_Rew(Chk_Coins);
        Invoke(nameof(load_rew), 1f);
    }


}

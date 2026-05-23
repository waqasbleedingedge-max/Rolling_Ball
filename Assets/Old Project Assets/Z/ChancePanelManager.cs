using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class ChancePanelManager : MonoBehaviour
{

    [SerializeField] private GameObject Reward;
    [SerializeField] private Image imageFill;
    [SerializeField] private Text counter;
    [SerializeField] private Button noThanks;
    [SerializeField] private float fillTime = 3.0f;

    private void OnEnable()
    {

        Invoke("ActivateNoThanks", 1f);
        StartCoroutine(ImageFiller());
    }

    IEnumerator ImageFiller()
    {
        float t = 0f;
        while (t < fillTime)
        {

            t += Time.deltaTime;
            imageFill.fillAmount = t / fillTime;

            counter.text = ((int)(4 - t)).ToString();

            yield return null;

        }
        GiveChance();
    }
    public void GiveChance()
    {
        //dnt AdmobAdsManager_InfiSingle.Instance.ShowRewardedVideo(RVReward);
        //dnt AdmobAdsManager_InfiSingle.Instance.LoadRewardedVideo();
        Get_Coins();
    }


    public void Get_Coins()
    {

        PlayerPrefs.SetInt("LoadReward", 0);
        Reward.SetActive(true);
        //Reward.transform.GetChild(1).gameObject.SetActive(true);
        //Reward.transform.GetChild(2).gameObject.SetActive(false);
        Invoke("waitAD_now", 1f);
    }
    void waitAD_now()
    {
        show_rv();
        if (PlayerPrefs.GetInt("LoadReward") == 0)
        {
            load_rv();
            Invoke("waitAD", 3f);
        }
        else
        {
            off_R();
        }
    }
    void waitAD()
    {
        show_rv();
        if (PlayerPrefs.GetInt("LoadReward") == 0)
        {
            off_R();
            //Reward.transform.GetChild(1).gameObject.SetActive(false);
            //Reward.transform.GetChild(2).gameObject.SetActive(true);
        }
        else
        {
            off_R();
        }
    }
    void off_R()
    {
        Reward.SetActive(false);
    }
    void show_rv()
    {
        // AdmobAdsManager_InfiSingle.Instance.ShowRewardedVideo(Chk_Coins);
    }
    void load_rv()
    {
        // AdmobAdsManager_InfiSingle.Instance.LoadRewardedVideo();
    }
    void Chk_Coins()
    {

        RVReward();
        //coin = PlayerPrefs.GetInt("Total_Currency");
        //coin = coin + coin;
        //PlayerPrefs.SetInt("Total_Currency", coin);
    }













    public void RVReward()
    {
        PlayerPrefs.SetInt("chance", PlayerPrefs.GetInt("chance") + 1);
      //  LevelManager.Instance.LevelFailed();

        noThanks.gameObject.SetActive(true);
        this.gameObject.SetActive(false);
    }

    private void ActivateNoThanks()
    {
        // LevelManager.Instance.LevelFailed();
        noThanks.gameObject.SetActive(true);
    }

    public void NoThanks()
    {
        StopCoroutine(ImageFiller());
      //  LevelManager.Instance.LevelFailed();
        this.gameObject.SetActive(false);
    }
}

using NA;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WelComeBack : MonoBehaviour
{
    public bool FB_Event;

    public int WelcomeBonus;
    public Text textReward;
    public GameObject Particle;
    public GameObject ClaimBtn;
    int dum;

    void OnEnable()
    {
        load_rew();
        ClaimBtn.SetActive(true);
        // dum = PlayerPrefs.GetInt("coins");
        //dum = dum + WelcomeBonus;
        //PlayerPrefs.SetInt("coins", dum);

        _FB();
    }

    void _FB()
    {
        if (FB_Event == true)
        {
          // LevelManager.Instance.Btn_FB_Call("_WB_IAP_Show");
        }
        
    }

    public void OnClaimBtnClick()
    {
        if (CoinReward.Instance)
            CoinReward.Instance.PlayCoinsAnimation();

        hmrbann();
        //CoinReward.Instance.CountCoins(dum);
        //SoundsManager.Instance?.ButtonClickPlay();
        ClaimBtn.SetActive(false);

        StartCoroutine(CoinsAdding());

    }
    IEnumerator CoinsAdding()
    {
        yield return new WaitForSeconds(2.35f);
        if (CoinsManager.Instance)
            CoinsManager.Instance.AddCoins(WelcomeBonus);

        yield return new WaitForSeconds(.7f);
        gameObject.SetActive(false);
    }
    public void OnClickReward2x()
    {
        SoundsManager.Instance.ButtonClickPlay();

        show_rew();
    }
    void AddCoinssss()
    {
        //?1? AdmobAdsManager_Infi.Instance.Btn_Reward_Done("You Have Done Reward Successfully");

        WelcomeBonus = WelcomeBonus * 2;

        Particle.SetActive(true);

        StartCoroutine(Coins2xReward());
    }

    IEnumerator Coins2xReward()
    {
        yield return new WaitForSecondsRealtime(2.5f);

        textReward.text = WelcomeBonus.ToString();
    }
    void load_rew()
    {
       // zWork.Instance.Btn_Load_Rew();
    }
    void show_rew()
    {
        // zWork.Instance.Btn_Show_Rew(AddCoinssss);
        Invoke(nameof(load_rew), 1f);
    }

    void hmrbann()
    {
      //  AdmobAdsManager.Instance.HideMediumBanner();
    }
}
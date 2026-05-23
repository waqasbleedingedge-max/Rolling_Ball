using NA;
using UnityEngine;

public class FreeCoinsReward : MonoBehaviour
{
    public int CoinsRewardValue = 500;

    private void OnEnable()
    {
        load_rew();
        load_Int();
    }

    public void Get_Coins()
    {
        load_rew();
        load_Int();
       // LevelManager.Instance.Reward.SetActive(true);
        SoundsManager.Instance?.ButtonClickPlay();

        Invoke("waitAD_now", .5f);
    }
    void waitAD_now()
    {
        // Aqib

        show_rew();
      //  LevelManager.Instance.Reward.SetActive(false);
    }

    public void Chk_Coins()
    {
        //?1? AdmobAdsManager_Infi.Instance.Btn_Reward_Done("You Have Done Reward Successfully");

        CoinReward.Instance.CountCoins(CoinsRewardValue);
        CoinsManager.Instance.AddCoins(CoinsRewardValue);
        PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins") + CoinsRewardValue);
    }
    public void NotRewardAloatChk_Coins()
    {
       // LevelManager.Instance.Reward.SetActive(false);
    }

    int xXx;
    public void Btn_AD_Call()
    {
        if (xXx == 0)
        {
            show_rew();
            xXx = 1;
        }
        else
        {
            show_Int();
            Chk_Coins();
            xXx = 0;
        }
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

    void load_Int()
    {
       // zWork.Instance.Btn_Load_Int();
    }

    void show_Int()
    {
        //zWork.Instance.Btn_Show_Int();
        Invoke(nameof(load_Int), 1f);
    }

}
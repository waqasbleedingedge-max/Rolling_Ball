using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using NA;
using DG.Tweening;

public class RewardAnimationEvent : MonoBehaviour
{
    public GameObject Reward, Particle;
    public Animator RewardAnim;
    public Transform[] TextScal;
    //public string X21;
    //public string X22;
    //public string X31;
    //public string X32;
    //public string X4;
    int a = 1;
    public Text t;
    public Text LevelRewardText;
    public Transform levelCompleteBall;
    public Transform[] levelcompleteBoxesPositions;
    public Button X2Button;
    public Button noThanks;
    public AudioSource popSound;
    private void OnEnable()
    {
     //   LevelRewardText.text = (LevelManager.Instance.GetLevelReward()).ToString();
    }
    public void Action(int s)
    {
        //if (s == X21)
        //{
        a = s;

       // t.text = (LevelManager.Instance.GetLevelReward() * s).ToString();
        //}
        //else if (s == X22)
        //{
        //    a = 2;
        //    t.text = (LevelManager.Instance.LevelsData[PlayerPrefs.GetInt("CurrentLevel")].levelReward * 2).ToString();
        //}
        //else if (s == X31)
        //{
        //    a = 3;
        //    t.text = (LevelManager.Instance.LevelsData[PlayerPrefs.GetInt("CurrentLevel")].levelReward * 3).ToString();
        //}
        //else if (s == X32)
        //{
        //    a = 4;
        //    t.text = (LevelManager.Instance.LevelsData[PlayerPrefs.GetInt("CurrentLevel")].levelReward * 3).ToString();
        //}
        //else if (s == X4)
        //{
        //    a = 5;
        //    t.text = (LevelManager.Instance.LevelsData[PlayerPrefs.GetInt("CurrentLevel")].levelReward * 5).ToString();
        //}

    }
    void ResetTextScale()
    {
        for (int i = 0; i < TextScal.Length; i++)
        {
            TextScal[i].DOScale(1.1f, .3f);
        }
    }

    public void RewardButton()
    {
        //X2Button.interactable = false;
        PlayCompleteAnim();


        Invoke("PopSoundPlay", 0.20f);
        Invoke("RVAdCall", 2.0f);
    }

    public void PopSoundPlay()
    {
        popSound.Play();
    }

    public void PlayCompleteAnim()
    {
        //if (a == 1)
        //{
        if (levelCompleteBall)
            levelCompleteBall.GetComponent<Animator>().enabled = false;
        //levelCompleteBall.SetPositionAndRotation(new Vector3(levelcompleteBoxesPositions[0].position.x, levelcompleteBoxesPositions[0].position.y + 2, levelcompleteBoxesPositions[0].position.z), levelCompleteBall.rotation);
        //levelCompleteBall.DOMoveY(levelcompleteBoxesPositions[0].position.y, 0.5f);
        //levelcompleteBoxesPositions[0].DOPunchScale(new Vector3(0.706f, 1.15f, 1.15f), 0.15f, 1, 0.2f).SetDelay(0.3f);
        //}
        //else if (a == 2)
        //{
        //    levelCompleteBall.GetComponent<Animator>().enabled = false;
        //    levelCompleteBall.SetPositionAndRotation(new Vector3(levelcompleteBoxesPositions[1].position.x, levelcompleteBoxesPositions[1].position.y + 2, levelcompleteBoxesPositions[1].position.z), levelCompleteBall.rotation);
        //    levelCompleteBall.DOMoveY(levelcompleteBoxesPositions[1].position.y, 0.5f);
        //    levelcompleteBoxesPositions[1].DOPunchScale(new Vector3(0.706f, 1.15f, 1.15f), 0.15f, 1, 0.2f).SetDelay(0.3f);
        //}
        //else if (a == 3)
        //{
        //    levelCompleteBall.GetComponent<Animator>().enabled = false;
        //    levelCompleteBall.SetPositionAndRotation(new Vector3(levelcompleteBoxesPositions[2].position.x, levelcompleteBoxesPositions[2].position.y + 2, levelcompleteBoxesPositions[2].position.z), levelCompleteBall.rotation);
        //    levelCompleteBall.DOMoveY(levelcompleteBoxesPositions[2].position.y, 0.5f);
        //    levelcompleteBoxesPositions[2].DOPunchScale(new Vector3(0.706f, 1.15f, 1.15f), 0.15f, 1, 0.2f).SetDelay(0.3f);
        //}
        //else if (a == 4)
        //{
        //    levelCompleteBall.GetComponent<Animator>().enabled = false;
        //    levelCompleteBall.SetPositionAndRotation(new Vector3(levelcompleteBoxesPositions[3].position.x, levelcompleteBoxesPositions[3].position.y + 2, levelcompleteBoxesPositions[3].position.z), levelCompleteBall.rotation);
        //    levelCompleteBall.DOMoveY(levelcompleteBoxesPositions[3].position.y, 0.5f);
        //    levelcompleteBoxesPositions[3].DOPunchScale(new Vector3(0.706f, 1.15f, 1.15f), 0.15f, 1, 0.2f).SetDelay(0.3f);
        //}
        //else if (a == 5)
        //{
        //    levelCompleteBall.GetComponent<Animator>().enabled = false;
        //    levelCompleteBall.SetPositionAndRotation(new Vector3(levelcompleteBoxesPositions[4].position.x, levelcompleteBoxesPositions[4].position.y + 2, levelcompleteBoxesPositions[4].position.z), levelCompleteBall.rotation);
        //    levelCompleteBall.DOMoveY(levelcompleteBoxesPositions[4].position.y, 0.5f);
        //    levelcompleteBoxesPositions[4].DOPunchScale(new Vector3(0.706f, 1.15f, 1.15f), 0.15f, 1, 0.2f).SetDelay(0.3f);
        //}
    }
    public void RVAdCall()
    {
        // AdmobAdsManager_InfiSingle.Instance.showRewardedVideoAd(RVREwardMultiplier);
        //  AdmobAdsManager_InfiSingle.Instance.LoadRewardedVideo();
        Get_Coins();
    }

    public void Get_Coins()
    {

        Reward.SetActive(true);
        RewardAnim.enabled = false;
        //X2Button.interactable = false;
        popSound.Stop();
        //Reward.transform.GetChild(1).gameObject.SetActive(true);
        //Reward.transform.GetChild(2).gameObject.SetActive(false);
        waitAD_now();
    }
    void waitAD_now()
    {
        // Aqib
        Reward.SetActive(false);

        show_rew();
    }
    bool checkonetime;
    void Chk_Coins()
    {
        //?1? AdmobAdsManager_Infi.Instance.Btn_Reward_Done("You Have Done Reward Successfully");

        Reward.SetActive(false);
        if (!checkonetime)
        {
            checkonetime = true;
            Invoke(nameof(RVREwardMultiplier), 1.5f);
        }

        //coin = PlayerPrefs.GetInt("Total_Currency");
        //coin = coin + coin;
        //PlayerPrefs.SetInt("Total_Currency", coin);
    }

    void RewardNotAllowChk_Coins()
    {

    }
    public void RVREwardMultiplier()
    {
        RewardMultiply();
    }
    int TotralReward = 0;
    public void RewardMultiply()
    {
        //if (a == 1)
        //{
       // TotralReward = LevelManager.Instance.GetLevelReward() * a;
       // LevelManager.Instance.SetLevelReward(TotralReward);
        StartCoroutine(AddCoinsText());
        Particle.SetActive(true);
        // CoinReward.Instance.PlayCoinsAnimation();
        // CoinsManager.Instance.AddCoins(TotralReward);
        checkonetime = false;
        RewardAnim.enabled = true;
        //}
        //else if (a == 2)
        //{
        //    PlayerPrefs.SetInt("reward", LevelManager.Instance.LevelsData[PlayerPrefs.GetInt("CurrentLevel")].levelReward * 2);
        //    CoinReward.Instance.CountCoins(LevelManager.Instance.LevelsData[PlayerPrefs.GetInt("CurrentLevel")].levelReward * 2);
        //}
        //else if (a == 3)
        //{
        //    PlayerPrefs.SetInt("reward", LevelManager.Instance.LevelsData[PlayerPrefs.GetInt("CurrentLevel")].levelReward * 3);
        //    CoinReward.Instance.CountCoins(LevelManager.Instance.LevelsData[PlayerPrefs.GetInt("CurrentLevel")].levelReward * 3);
        //}
        //else if (a == 4)
        //{
        //    PlayerPrefs.SetInt("reward", LevelManager.Instance.LevelsData[PlayerPrefs.GetInt("CurrentLevel")].levelReward * 3);
        //    CoinReward.Instance.CountCoins(LevelManager.Instance.LevelsData[PlayerPrefs.GetInt("CurrentLevel")].levelReward * 3);
        //}
        //else if (a == 5)
        //{
        //    PlayerPrefs.SetInt("reward", LevelManager.Instance.LevelsData[PlayerPrefs.GetInt("CurrentLevel")].levelReward * 5);
        //    CoinReward.Instance.CountCoins(LevelManager.Instance.LevelsData[PlayerPrefs.GetInt("CurrentLevel")].levelReward * 5);
        //}

        //transform.root.gameObject.SetActive(false);

        //PlayerPrefs.SetInt("CurrentLevel", PlayerPrefs.GetInt("CurrentLevel") + 1);
        //noThanks.onClick.Invoke();
        //noThanks.interactable = false;
        //Invoke("LoadingScene", 3f);

    }

    IEnumerator AddCoinsText()
    {
        yield return new WaitForSecondsRealtime(2.6f);

        LevelRewardText.text = TotralReward.ToString();
    }
    public void LoadingScene()
    {
        SceneManager.LoadScene(2);
    }

    void load_rew()
    {
       // zWork.Instance.Btn_Load_Rew();
    }
    void show_rew()
    {
       // zWork.Instance.Btn_Show_Rew(Chk_Coins);
        Invoke(nameof(load_rew), 1f);
    }
}

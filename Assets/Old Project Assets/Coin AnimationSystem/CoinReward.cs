using System.Collections;
using DG.Tweening;
using NA;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoinReward : SimpleSingleton<CoinReward>
{
  //  public static CoinReward CoinRewardInstance;
    [SerializeField] private GameObject pileOfCoins;
    [SerializeField] private Text counter;
    [SerializeField] private Transform[] initialPos;
    [SerializeField] private Quaternion[] initialRotation;
    [SerializeField] private int coinsAmount;
    [SerializeField] private GameObject pileOfSkips;
    [SerializeField] private Text SkipsCounter;
    [SerializeField] private Transform[] SkipsInitialPos;
    [SerializeField] private Quaternion[] SkipsInitialRotation;
    [SerializeField] private int SkipsAmount;
    [SerializeField] private AudioSource coinsSound;
    void Start()
    {
        
        if (coinsAmount == 0) 
            coinsAmount = 10; 
        initialRotation = new Quaternion[coinsAmount];
        
        
     //   CoinRewardInstance = this;
    }


   public void CountCoins(int coins)
    {
        SoundsManager.Instance.ButtonClickPlay();

        pileOfCoins.SetActive(true);
        var delay = 0f;
        
        for (int i = 0; i < pileOfCoins.transform.childCount; i++)
        {
            pileOfCoins.transform.GetChild(i).position = initialPos[i].position;
            pileOfCoins.transform.GetChild(i).rotation = initialRotation[i];
            
            
            
            pileOfCoins.transform.GetChild(i).DOScale(1f, 0.3f).SetDelay(delay).SetEase(Ease.OutBack);

            pileOfCoins.transform.GetChild(i).GetComponent<RectTransform>().DOAnchorPos(new Vector3(0, 0, 0), 0.8f)
                .SetDelay(delay + 0.5f).SetEase(Ease.InBack);
             

            pileOfCoins.transform.GetChild(i).DORotate(Vector3.zero, 0.5f).SetDelay(delay + 0.5f)
                .SetEase(Ease.Flash);
            
            
            pileOfCoins.transform.GetChild(i).DOScale(0f, 0.3f).SetDelay(delay + 1.5f).SetEase(Ease.OutBack);

            delay += 0.1f;

            counter.transform.parent.GetChild(0).transform.DOScale(1.1f, 0.1f).SetLoops(10,LoopType.Yoyo).SetEase(Ease.InOutSine).SetDelay(1.2f);
        }
        Invoke("PlaySound", 0.6f);
        StartCoroutine(countCoins(coins));
    } 
    public void CountSkips(int skips)
    {
        SoundsManager.Instance.ButtonClickPlay();

        pileOfSkips.SetActive(true);
        var delay = 0f;
        
        for (int i = 0; i < pileOfSkips.transform.childCount; i++)
        {
            pileOfSkips.transform.GetChild(i).position = SkipsInitialPos[i].position;
            pileOfSkips.transform.GetChild(i).rotation = initialRotation[i];



            pileOfSkips.transform.GetChild(i).DOScale(1f, 0.3f).SetDelay(delay).SetEase(Ease.OutBack);

            pileOfSkips.transform.GetChild(i).GetComponent<RectTransform>().DOAnchorPos(new Vector3(0, 0, 0), 0.8f)
                .SetDelay(delay + 0.5f).SetEase(Ease.InBack);


            pileOfSkips.transform.GetChild(i).DORotate(Vector3.zero, 0.5f).SetDelay(delay + 0.5f)
                .SetEase(Ease.Flash);


            pileOfSkips.transform.GetChild(i).DOScale(0f, 0.3f).SetDelay(delay + 1.5f).SetEase(Ease.OutBack);

            delay += 0.1f;

            SkipsCounter.transform.parent.GetChild(0).transform.DOScale(1.1f, 0.1f).SetLoops(10,LoopType.Yoyo).SetEase(Ease.InOutSine).SetDelay(1.2f);
        }
        Invoke("PlaySound", 0.6f);
        StartCoroutine(countSkips(skips));
    }

    public void PlaySound()
    {
        coinsSound.Play();
    }
    
    IEnumerator countCoins(int coins)
    {
        yield return new WaitForSecondsRealtime(2f);
        CoinsManager.Instance.getCoinsPanel.SetActive(false);
        CoinsManager.Instance.AddCoins(PlayerPrefs.GetInt("reward"));
        //if(CoinsManager.Instance.quest.activeInHierarchy)
        //{
        //    CoinsManager.Instance.quest.SetActive(false); CoinsManager.Instance.complete.SetActive(true);
        //}
        
        counter.text = PlayerPrefs.GetFloat("reward").ToString();
    }
    IEnumerator countSkips(int skips)
    {
        yield return new WaitForSecondsRealtime(2f);
        CoinsManager.Instance.getSkipsPanel.SetActive(false);
        CoinsManager.Instance.AddSkips(10);
        //if(CoinsManager.Instance.quest.activeInHierarchy)
        //{
        //    CoinsManager.Instance.quest.SetActive(false); CoinsManager.Instance.complete.SetActive(true);
        //}
        
        counter.text = PlayerPrefs.GetFloat("reward").ToString();
    }
    public void PlayCoinsAnimation()
    {
        SoundsManager.Instance.ButtonClickPlay();

        pileOfCoins.SetActive(true);
        var delay = 0f;

        for (int i = 0; i < pileOfCoins.transform.childCount; i++)
        {
            pileOfCoins.transform.GetChild(i).position = initialPos[i].position;
            pileOfCoins.transform.GetChild(i).rotation = initialRotation[i];



            pileOfCoins.transform.GetChild(i).DOScale(1f, 0.3f).SetDelay(delay).SetEase(Ease.OutBack);

            pileOfCoins.transform.GetChild(i).GetComponent<RectTransform>().DOAnchorPos(new Vector3(0, 0, 0), 0.8f)
                .SetDelay(delay + 0.5f).SetEase(Ease.InBack);


            pileOfCoins.transform.GetChild(i).DORotate(Vector3.zero, 0.5f).SetDelay(delay + 0.5f)
                .SetEase(Ease.Flash);


            pileOfCoins.transform.GetChild(i).DOScale(0f, 0.3f).SetDelay(delay + 1.5f).SetEase(Ease.OutBack);

            delay += 0.1f;

            counter.transform.parent.GetChild(0).transform.DOScale(1.1f, 0.1f).SetLoops(10, LoopType.Yoyo).SetEase(Ease.InOutSine).SetDelay(1.2f);
        }
        Invoke("PlaySound", 0.6f);
    }
}

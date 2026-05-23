using DG.Tweening;
using NA;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
//using MoreMountains.NiceVibrations;

public class QuestManager : MonoBehaviour
{
    public GameObject Reward;
    public GameObject quest;
    public GameObject[] rewardButtons;
    public Image lockAnimDemo;
    // Image locker;
    public bool anim = true;
    public int rvs = 0;
   public GameObject continueButton;

    public GameObject[] skips;
    public Image[] balls;
    public Image[] coins;
    int c = 0;
    int b = 0;
    int s = 0;
    public Image TextTarget;
    int chances = 3;
    public GameObject ballsImage;
    public GameObject coisImage;
    public GameObject skipsImage;
    public GameObject coinsText;
    public GameObject complete;
    public GameObject RVPanel;
    [SerializeField] private Text textCounter;
    [SerializeField] private Image imageFill;
    [SerializeField] private GameObject noThanks;
    [SerializeField] private GameObject GetCoinsPanel;
    [SerializeField] private int counter = 3;
    float limitCounter = 0f;

    public AudioSource lockSound;
    public AudioSource getCoinSound;

    public AudioSource completeSound;
    int countClick = 0;
    //public AudioSource Sound;

    private void OnEnable()
    {
        countClick = 0;
        completeSound.Play();
    }
    public void OnQuestButton(int index)
    {
        if (countClick < 3)
        {
            countClick++;
        }
        else
        {
            Debug.Log("ReturnNot Clicked");
            return;

        }
      //  SoundsManager.Instance.ButtonClickPlay();
        //MMVibrationManager.Haptic(HapticTypes.HeavyImpact);
        rvs++;
      //  Image locker = Instantiate(lockAnimDemo, transform.GetChild(0),true);
       // locker.rectTransform.SetLocalPositionAndRotation(rewardButtons[index].transform.position, rewardButtons[index].transform.rotation);
      //  Destroy(locker,2);
      //  locker.transform.GetChild(0).gameObject.SetActive(false);
        StartCoroutine(QuestButtonEffetct( index));
        Debug.Log(" Clicked");





    }

    IEnumerator QuestButtonEffetct( int index)
    {
       // SoundsManager.Instance.ButtonClickPlay();
        chances--;
        // rewardButtons[index].transform.GetChild(3).gameObject.SetActive(false);
        rewardButtons[index].transform.GetChild(3).transform.GetChild(2).DORotate(new Vector3(rewardButtons[index].transform.GetChild(2).transform.rotation.x, rewardButtons[index].transform.GetChild(2).transform.rotation.y, rewardButtons[index].transform.GetChild(2).transform.rotation.z + -90), 1.0f);
        lockSound.Play();
        yield return new WaitForSeconds(1.0f);
        rewardButtons[index].transform.GetChild(3).transform.GetChild(2).gameObject.SetActive(false);

        int rn = Random.Range(0, 3);
    //    Debug.Log("Random Number = " + rn);
        if (rn > 0)
        {
            s++;
            rewardButtons[index].transform.GetChild(0).gameObject.SetActive(true);
        }
        else if(rn < 1)
        {
            c++;
           // int coinsrv = Random.Range(5, 10);
            rewardButtons[index].transform.GetChild(1).gameObject.SetActive(true);
          //  rewardButtons[index].transform.GetChild(1).transform.GetChild(0).GetComponent<Text>().text = (coinsrv*10).ToString();

        }
        float a = 1;
        while (a>0) 
        {
            a -= Time.deltaTime;
            rewardButtons[index].transform.GetChild(3).transform.GetChild(0).transform.GetComponent<Image>().fillAmount = a;
            rewardButtons[index].transform.GetChild(3).transform.GetChild(1).transform.GetComponent<Image>().fillAmount = a;
            yield return null;
            
        
        }
        if (rn > 0)
        {
           

            Image img =  Instantiate(rewardButtons[index].transform.GetChild(0).GetComponent<Image>(),transform);

            if ((s - 1) < skips.Length)
            {
                img.transform.DOMove(skips[s - 1].transform.position, 0.5f).OnComplete(() => CollectedImageOn(img));
                img.transform.DOScale(new Vector3(0, 0, 0), 0.5f);
            }
            //  img.rectTransform.DoMove(img.rectTransform.position, skips[s].transform.position, 0.8f);


        }
        else if (rn < 1)
        {
           

            Image img = Instantiate(rewardButtons[index].transform.GetChild(1).GetComponent<Image>(), rewardButtons[index].transform);
          //  img.transform.SetLocalPositionAndRotation(rewardButtons[index].transform.GetChild(1).transform.position, img.transform.rotation);


            img.transform.DOMove(coins[c-1].transform.position, 0.5f).OnComplete(() => CollectedImageOn(img));
            img.transform.DOScale(new Vector3(0, 0, 0), 0.5f);
           // Destroy(img,1.0f);
            //  rewardButtons[index].transform.GetChild(1).transform.GetChild(0).GetComponent<Text>().text = (coinsrv*10).ToString();

        }
        if (rvs >=3)
        {
            for(int i = 0; i < rewardButtons.Length; i++)
            {
                rewardButtons[i].GetComponent<Button>().interactable = false;
                continueButton.SetActive(true);
            }
        }

        if (rvs >= 3)
        {
            for (int i = 0; i < rewardButtons.Length; i++)
            {
                rewardButtons[i].GetComponent<Button>().interactable = false;
                continueButton.SetActive(true);
            }
        }
        
     //   locker.transform.GetChild(0).transform.GetComponent<Image>().fillAmount = 


    }
    void CollectedImageOn(Image g)
    {
        if (g == null)
            return;
        getCoinSound.Play();
        Destroy(g.gameObject);
        for (int i = 1; i <= 3; i++)
        {
            if (i <= s)
            {
                skips[i - 1].gameObject.SetActive(true);
            }
            if (b >= i)
            {
                balls[i - 1].gameObject.SetActive(true);
            }
            if (i <= c)
            {
                coins[i - 1].gameObject.SetActive(true);
            }
        }
       

        if(c==3)
        {
            Debug.Log(c + " coin");
            coinsText.SetActive(true);
           // Invoke("Nothanks", 2.0f);
           // PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins") + 100);
            // GetCoinsPanel.SetActive(true);
            CoinsManager.Instance.AddCoinsCounter(100);
           // Invoke("Nothanks", 2.0f);
        }
        if (s == 3)
        {
            CoinsManager.Instance.AddSkipsCounter();
        }
        if(b == 3)
        {

        }

        if (s + b + c >= 3&&s<3&&b<3&&c<3)
        {
           
            StartCoroutine(PanelsSwap());
         //   StartCoroutine(RVCounterImage());
          //  CoinsManager.Instance.AddCoinsCounter(100);
        }
           
        if (chances<=0&&c<3&&s<3&&b<3)
        {
           // RVPanel.SetActive(true);
           // StartCoroutine(Counter());
        }
    }

    IEnumerator PanelsSwap()
    {
        yield return new WaitForSeconds(2.0f);
        quest.SetActive(false);
        complete.SetActive(true);
    }


    IEnumerator RVCounterImage()
    {
        yield return new WaitForSeconds(1.0f);
        RVPanel.SetActive(true);
        float count = 3;
        while (count>0)
        {

            count-=Time.deltaTime;
            imageFill.fillAmount = (count/3f);
            textCounter.text = ((int)count).ToString();



            yield return null;
        }
        ContinueRV();
    }

    public void ContinueRV()
    {
        StopCoroutine(RVCounterImage());
        SoundsManager.Instance.ButtonClickPlay();
        //MMVibrationManager.Haptic(HapticTypes.HeavyImpact);
        //  RVReward();
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
        //dnt AdmobAdsManager_InfiSingle.Instance.ShowRewardedVideo(Chk_Coins);
    }
    void load_rv()
    {
        //dnt AdmobAdsManager_InfiSingle.Instance.LoadRewardedVideo();
    }
    void Chk_Coins()
    {

        RVReward();
        //coin = PlayerPrefs.GetInt("Total_Currency");
        //coin = coin + coin;
        //PlayerPrefs.SetInt("Total_Currency", coin);
    }














    private void RVReward()
    {
        chances = 1;
       // if (rvs >= 3)
       // {
            for (int i = 0; i < rewardButtons.Length; i++)
            {
                rewardButtons[i].GetComponent<Button>().interactable = true;
                RVPanel.SetActive(false);
            }
      //  }
    }
   

  

    IEnumerator Counter()
    {
        yield return new WaitForSeconds(0.2f);
        while (limitCounter < counter)
        {
            limitCounter += Time.deltaTime;
            textCounter.text = ((int)(counter - limitCounter)).ToString();
            imageFill.fillAmount = (limitCounter / 3);

            yield return null;
            ContinueRV();
        }
    }
   
    public void Nothanks()
    {
        SoundsManager.Instance.ButtonClickPlay();
        //MMVibrationManager.Haptic(HapticTypes.HeavyImpact);
        Debug.Log("NoThanksAction");
        Invoke("NoThanksDone",2.0f);

    }

    public void NoThanksDone()
    {
        complete.SetActive(true);
        this.gameObject.SetActive(false);
    }

    public void NoThanksAction()
    {
        SoundsManager.Instance.ButtonClickPlay();
        //MMVibrationManager.Haptic(HapticTypes.HeavyImpact);

        Debug.Log("NoThanksAction");
        complete.SetActive(true);
        this.gameObject.SetActive(false);
    }

  
}

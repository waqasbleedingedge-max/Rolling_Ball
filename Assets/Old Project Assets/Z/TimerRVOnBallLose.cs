using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerRVOnBallLose : MonoBehaviour
{

    [SerializeField] private Text textCounter;
    [SerializeField] private Image imageFill;
    [SerializeField] private GameObject noThanks;
    [SerializeField] private int counter = 3;
    float limitCounter = 0f;

    private void OnEnable()
    {
        StartCoroutine(Counter());
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
            GiveChance();
        }
    }
    public void GiveChance()
    {
        //dnt AdmobAdsManager_InfiSingle.Instance.ShowRewardedVideo(RVReward);
        //dnt  AdmobAdsManager_InfiSingle.Instance.LoadRewardedVideo();
    }

    public void RVReward()
    {

    }
    public void Nothanks()
    {



    }




}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityStandardAssets.Utility;


public class CheckPoint : MonoBehaviour
{
    [SerializeField]
    private int checkointIndex;
    public GameObject rewardObject;
    public Transform SpawnPos;
    bool isCollected = false;

    public AudioSource collect;
    //private void Start()
    //{
    //    int ballIndex = PlayerPrefs.GetInt("selectedball");
    //    //for (int i = 0; i < rewardObject.transform.childCount; i++)
    //    //{
    //    //    if (i == ballIndex)
    //    //    {
    //    //        rewardObject.transform.GetChild(i).gameObject.SetActive(true);
    //    //    }
    //    //    else
    //    //    {
    //    //        rewardObject.transform.GetChild(i).gameObject.SetActive(false);
    //    //    }

    //    //}
    //    InvokeRepeating("CheckReward",5.0f, 5.0f);
    //}
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if (isCollected)
            {
               // LevelManager.Instance.currentCheckpoint = checkointIndex;
               // LevelManager.Instance.currentCheckpointTransform = SpawnPos;
            }
            else
            {
                //collect.Play();
                //   isCollected = true;

                
                //Destroy(rewardObject, 0.10f);
               // rewardObject.transform.DOMove(SmoothFollow.Instance.lerpTarget.transform.position, 1.0f);
               
              //  if (LevelManager.Instance.currentCheckpoint != checkointIndex && LevelManager.Instance.chance < 5)
                //{
                // //   LevelManager.Instance.currentCheckpoint = checkointIndex;
                //    int a = PlayerPrefs.GetInt("chance");

                //    //if (a<5)
                //    //{
                //    //    PlayerPrefs.SetInt("chance", PlayerPrefs.GetInt("chance") + 1);
                //    //}
                //    //else
                //    //{
                //    //    PlayerPrefs.SetInt("chance", 5);
                //    //}
                   
                //  //  Debug.Log("Chance = " + (PlayerPrefs.GetInt("chance")).ToString());
                //}
                //else
                //{
                //    LevelManager.Instance.currentCheckpoint = checkointIndex;
                //}
                //LevelManager.Instance.SetChanceUi(true);
                //LevelManager.Instance.currentCheckpointTransform = SpawnPos;

            }

        }
    }

    public void CheckReward()
    {
        //    if(isCollected)
        //    {
        //        CancelInvoke("CheckReward");
        //        return;
        //    }
        //    if(PlayerPrefs.GetInt("chance") <= 5)
        //    {
        //        rewardObject.SetActive(true);
        //    }
        //    else
        //    {
        //        rewardObject.SetActive(false);
        //    }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityStandardAssets.Utility;

public class FinishTriggerEvent : MonoBehaviour
{

    public float ontriggerEnterDelay;
    public string[] tags;

    public Transform finishPointTarget;
    public UnityEvent OnTriggerEnterEvent;
    public UnityEvent OnTriggerEnterEventInstant;
    public UnityEvent OnTriggerExitEvent;

    public GameObject[] finishStacks;



    private void Start()
    {
   //     int rn = Random.Range(0, 2);
   ////     Debug.Log("random number : " + rn);
   //     for (int i = 0; i < finishStacks.Length; i++)
   //     {
   //         if(i==rn)
   //         {
   //             finishStacks[i].SetActive(true);
   //         }

   //         else
   //             finishStacks[i].SetActive(false);
   //     }
       
    }


    private void OnTriggerEnter(Collider other)
    {
        foreach(string tag in tags)
        {
            if(other.CompareTag(tag))
            {
                Time.timeScale = 1f;
                OnTriggerEnterEventInstant.Invoke();
                SmoothFollow.Instance.ChangeCamTarget();
               // LevelManager.Instance.SetMass();
                Destroy(PathCalculator.Instance.gameObject);
                StartCoroutine(TriggerEnterDelay());
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        foreach (string tag in tags)
        {
            if (other.CompareTag(tag))
            {
                OnTriggerExitEvent.Invoke();
            }
        }
    }

    IEnumerator TriggerEnterDelay()
    {
        yield return new WaitForSeconds(ontriggerEnterDelay);
      //  LevelManager.Instance.InitComplete();
        OnTriggerEnterEvent.Invoke();

    }

    public void StopBall()
    {
       // LevelManager.Instance.SetStopBall();
    }

}

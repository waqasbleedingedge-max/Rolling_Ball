using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using NA;

public class FinishPoint : MonoBehaviour
{
    public UnityEvent OnLevelComplete, OnLevelFailed;
   
    public float timeRemaining = 10;
    public bool timerIsRunning = false;
    public Text timeText;
    private void Start()
    {
        // Starts the timer automatically
        timeText = ReferenceManager.Instance.timerText;
        timerIsRunning = true;
       
    }

    private void OnEnable()
    {
       
    }
    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
               // Debug.Log("Time has run out!");
                timeRemaining = 0;
                OnLevelFailed.Invoke();
                timerIsRunning = false;
            }
        }
    }
    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
       
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
           
                StartCoroutine(LevelFinished(other.gameObject));
          
           

        }
     
        
    }


    public IEnumerator LevelFinished(GameObject other)
    {
       
          yield return new WaitForSeconds(0.3f);
        other.gameObject.GetComponentInParent<Rigidbody>().isKinematic = true;
     //   SoundsManager.Instance.BGusicPause();
      
            UiManager.Instance.LevelComplete();
        
        ReferenceManager.Instance.gamePlayPanel.SetActive(false);
        OnLevelComplete.Invoke();

        yield return new WaitForSeconds(0.2f);
        this.gameObject.SetActive(false);
      
    }
       
    


}

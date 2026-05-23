using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerEvent : MonoBehaviour
{

    public float ontriggerEnterDelay;
    public string[] tags;


    public UnityEvent OnTriggerEnterEvent;
    public UnityEvent OnTriggerEnterEventInstant;
    public UnityEvent OnTriggerExitEvent;
    private void OnTriggerEnter(Collider other)
    {
        foreach(string tag in tags)
        {
            if(other.CompareTag(tag))
            {
                OnTriggerEnterEventInstant.Invoke();
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
      //  LevelManager.Instance.completePanel.SetActive(true);
        OnTriggerEnterEvent.Invoke();

    }

}

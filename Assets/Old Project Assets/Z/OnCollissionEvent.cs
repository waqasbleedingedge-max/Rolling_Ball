using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnCollissionEvent : MonoBehaviour
{
    public float ontriggerEnterDelay;
    public string[] tags;


    public UnityEvent OnTriggerEnterEvent;
    public UnityEvent OnTriggerEnterEventInstant;
    public UnityEvent OnTriggerExitEvent;

    private void OnCollisionEnter(Collision collision)
    {
        foreach (string tag in tags)
        {
            if (collision.transform.CompareTag(tag))
            {
                OnTriggerEnterEventInstant.Invoke();
                StartCoroutine(TriggerEnterDelay());
            }
        }
    }
    IEnumerator TriggerEnterDelay()
    {
        yield return new WaitForSeconds(ontriggerEnterDelay);
        //  LevelManager.Instance.completePanel.SetActive(true);
        OnTriggerEnterEvent.Invoke();

    }
    //private void (Collider other)
    //{
    //    foreach (string tag in tags)
    //    {
    //        if (other.CompareTag(tag))
    //        {
    //            OnTriggerEnterEventInstant.Invoke();
    //            StartCoroutine(TriggerEnterDelay());
    //        }
    //    }
    //}


}

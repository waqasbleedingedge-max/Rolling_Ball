using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnEnableDelay : MonoBehaviour
{
    public float delay;
    public UnityEvent  OnEnableInstant,EnableDelay, DisableEvent;

    private void OnEnable()
    {
        OnEnableInstant.Invoke();
        StartCoroutine(DelayFunc());
    }

    IEnumerator DelayFunc()
    {
        yield return new WaitForSeconds(delay);
        EnableDelay.Invoke();
    }

    private void OnDisable()
    {
        DisableEvent.Invoke();
    }
}

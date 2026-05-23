using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideGameObject : MonoBehaviour
{
    public bool HideTargetItem;

    public float DelayTime;
    public GameObject TargetItem;
    private void OnEnable()
    {
        StartCoroutine(OnDisableObgect());
    }
    IEnumerator OnDisableObgect()
    {
        yield return new WaitForSecondsRealtime(DelayTime);
        if (HideTargetItem&& TargetItem)
            TargetItem.SetActive(false);
        else
            gameObject.SetActive(false);
    }
}

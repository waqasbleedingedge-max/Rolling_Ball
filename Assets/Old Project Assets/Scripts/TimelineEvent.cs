using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Playables;
using NA;

public class TimelineEvent : MonoBehaviour
{
    public PlayableDirector director;
    public UnityEvent TimelineStartEvent, TimelineEndEvent;
    private void OnEnable()
    {
        TimelineStartEvent.Invoke();
        ReferenceManager.Instance.cutSceneSkipButton.gameObject.SetActive(true);
        ReferenceManager.Instance.cutSceneSkipButton.onClick.RemoveAllListeners();
        ReferenceManager.Instance.cutSceneSkipButton.onClick.AddListener(StopTimeline);
     //   SoundsManager.Instance.BGMusicVolume(0.4f);
    }

    private void OnDisable()
    {
        TimelineEndEvent.Invoke();
        ReferenceManager.Instance.cutSceneSkipButton.gameObject.SetActive(false);
    }

   

 

    public void StopTimeline()
    {
        director.Stop();
        ReferenceManager.Instance.cutSceneSkipButton.gameObject.SetActive(false);
    }
}

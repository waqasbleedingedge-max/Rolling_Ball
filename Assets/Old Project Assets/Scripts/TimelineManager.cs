using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using NA;

public class TimelineManager : MonoBehaviour
{
    public PlayableDirector director;

    void OnEnable()
    {
        director.played += OnPlayableDirectorPlayed;
        director.stopped += OnPlayableDirectorStopped;
    }

    void OnPlayableDirectorPlayed(PlayableDirector aDirector)
    {
        Debug.Log("Director true");
        if (director == aDirector)
        {
           
            ReferenceManager.Instance.cutSceneSkipButton.gameObject.SetActive(true);
            ReferenceManager.Instance.cutSceneSkipButton.onClick.RemoveAllListeners();
            ReferenceManager.Instance.cutSceneSkipButton.onClick.AddListener(StopTimeline);
        }
    }

    void OnDisable()
    {
       // director.played -= OnPlayableDirectorPlayed;
    }

    public void StopTimeline()
    {
        director.Stop();
        ReferenceManager.Instance.cutSceneSkipButton.gameObject.SetActive(false);
    }

    void OnPlayableDirectorStopped(PlayableDirector aDirector)
    {
       // Debug.Log("Director Stop");
        if (director == aDirector)
            ReferenceManager.Instance.cutSceneSkipButton.gameObject.SetActive(false);
    }

}

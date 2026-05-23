using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using NA;

public class AditiveSceLoader : SimpleSingleton<AditiveSceLoader>
{
    public string sceneName;
    public Transform[] wayPoints;
    IEnumerator Start()
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
        yield return new WaitForSeconds(0.2f);
       // SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneName));
    }
}

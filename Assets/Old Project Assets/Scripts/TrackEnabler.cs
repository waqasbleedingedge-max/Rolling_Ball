using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TrackEnabler : MonoBehaviour
{
    public string sceneName;
   // public GameObject[] tracksList;
    IEnumerator Start()
    {
       // tracksList[PlayerPrefs.GetInt("CurrentLevel")%5].SetActive(true);

        SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
        yield return new WaitForSeconds(0.2f);
        // SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneName));
    }


}

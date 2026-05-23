using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NA;

public class SetLevelReward : MonoBehaviour
{
    public Text coinsText;

    private void OnEnable()
    {
       // coinsText.text = LevelManager.Instance.GetLevelReward().ToString();
    }
}

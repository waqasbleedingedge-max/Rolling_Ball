using NA;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetTotalCoins : MonoBehaviour
{
    public Text coinsText;

    private void OnEnable()
    {
        coinsText.text = PlayerPrefs.GetInt("coins").ToString();
    }
}

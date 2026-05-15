using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class rewardSystem : MonoBehaviour
{
    [SerializeField] private Text rewardToShow;
    public int CoinsAmount;
    void Start()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("rewardNo"))
        {
            var multiplier = other.gameObject.name;

            rewardToShow.text = (CoinsAmount * float.Parse(multiplier)).ToString();
            PlayerPrefs.SetFloat("reward",float.Parse( rewardToShow.text));
        }
    }

    public void GetTheReward()
    {
   //     CoinReward.Instance.CountCoins(500);
    }
}

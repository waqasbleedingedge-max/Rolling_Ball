using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System;
using UnityEngine;
using UnityEngine.UI;
//using MoreMountains.NiceVibrations;




namespace NA
{
    public class CoinsManager : SimpleSingleton<CoinsManager>
    {
       
        public GameObject canvas;
        [SerializeField]
        private Text CoinsText;
       // public int[] levelsRewards; // Set all levels Rewards
     //   public int[] CarsPrice; // Set all Cars Prices
        public GameObject getCoinsPanel;
        public GameObject getSkipsPanel;
        public Text getCoinsText;
        public Text getSkipsText;
        //public GameObject quest;
        public GameObject complete;
        public Text skipsText;
             
        public AudioSource coinsSound;
     
        public int coins
        {
            get
            {
                return PlayerPrefs.GetInt("coins");
            }

        }

        public int skips
        {
            get
            {
                return PlayerPrefs.GetInt("skips");
            }
        }


        private void Start()
        {
            UpdateCoinsText();
           // PlayerPrefs.SetInt("coins", 5000);
        }

        // Add Earned Coins To pref
        public void AddCoins(int coins)
        {

            Debug.Log("AddCoins");
            PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins") + coins);
            UpdateCoinsText();
        } 
        public void AddSkips(int coins)
        {

            Debug.Log("Add Skips");
            PlayerPrefs.SetInt("skips", PlayerPrefs.GetInt("skips") + coins);
            UpdateCoinsText();
        }

        // minus Coins If Purchase is done
        public void MinusCoins(int coins)
        {


            PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins") - coins);

            UpdateCoinsText();
        } 
        public void MinusSkips(int coins)
        {


            PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins") - coins);

            UpdateCoinsText();
        }


        // Show and Set Level wise Reward
      //  public int LevelReward()
      //  {
       //     return levelsRewards[PlayerPrefs.GetInt("CurrentLevel")];
//
      //  }

        public void UpdateCoinsText()
        {
            CoinsText.text = coins.ToString();
            skipsText.text = skips.ToString();
        }

        public void Shop()
        {
          //  GameAppManager.Instance.ShowShop();
            if (SoundsManager.Instance)
            {
                SoundsManager.Instance.ButtonClickPlay();
            }
            if (PlayerPrefs.GetInt("haptics") == 0)
            {
                //MMVibrationManager.Haptic(HapticTypes.HeavyImpact);
            }
        }

        public void AddCoinsCounter(int coin)
        {
            PlayerPrefs.SetInt("reward", coin);
            getCoinsText.text = coin.ToString();
            getCoinsPanel.SetActive(true);
        } 
        public void AddSkipsCounter()
        {
            //PlayerPrefs.SetInt("reward", coin);
            getSkipsText.text = 10.ToString();
            getSkipsPanel.SetActive(true);
        }
        public void ActivateCoinsCanvas()
        {
            canvas.SetActive(true);
        }

      

        public void ShowCoins()
        {
            CoinsText.transform.parent.gameObject.SetActive(true);
        }



    }

}




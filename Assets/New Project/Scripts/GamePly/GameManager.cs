using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Rollance
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;

        [Header("Level Prefabs")]
        public GameObject[] levelPrefabs;

        private GameObject currentLevelObject;

        private int currentLevel = 0;
        private string levelKey = "CurrentLevel";


        [Header("UI")]
        public Text levelText;


        [Header("Win Lose Panels")]
        public GameObject MainPanel;
        public GameObject WinPanel;
        public GameObject LosePanel;
        public GameObject PausedPanel;


        
        [Header("Disable Objects After Swipe")]
        public GameObject BallSelectionButton;
        public GameObject Swipe;
        public GameObject swipeToControl;



        public static Action OnLevelStart;


       

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
        void Start()
        {
            LoadLevel();
        }

        private void OnEnable()
        {
            RollingBallController.FirstClick += DisappearBallSelectionButton;
        }



        private void OnDisable()
        {
            RollingBallController.FirstClick -= DisappearBallSelectionButton;
        }


        private void DisappearBallSelectionButton()
        {

            BallSelectionButton.SetActive(false);
            swipeToControl.SetActive(false);
            Swipe.SetActive(false);
        }
        // 🔄 LOAD LEVEL FROM SAVE
        void LoadLevel()
        {

          //  WaypointManager.Instance.ResetProgress();
            currentLevel = PlayerPrefs.GetInt(levelKey, 0);

            if (currentLevel >= levelPrefabs.Length)
                currentLevel = 0;

            SpawnLevel(currentLevel);

            


        }




        void SpawnLevel(int index)
        {
            if (levelPrefabs.Length == 0) return;

            // 🧹 Old level destroy
            if (currentLevelObject != null)
            {
                Destroy(currentLevelObject);
            }

            // 🔥 Instantiate new level
            currentLevelObject = Instantiate(levelPrefabs[index], Vector3.zero, Quaternion.identity);

            currentLevel = index;

            UpdateLevelText();


            GlobalBallManager.Instance.SetBallStartPosition(currentLevel);

           
        }

       
        // 🔁 NEXT LEVEL
        public void ActivateNextLevel()
        {
            if (levelPrefabs.Length == 0) return;

            currentLevel++;

            // 🔄 Loop back if last level
            if (currentLevel >= levelPrefabs.Length)
            {
                ShowAndroidToast("Game Completed!");
                currentLevel = 0;
            }

            // 💾 SAVE
            PlayerPrefs.SetInt(levelKey, currentLevel);
            PlayerPrefs.Save();

            // 🔥 Direct spawn (NO scene reload needed)
            SpawnLevel(currentLevel);


            MainPanel.gameObject.SetActive(true);
            WinPanel.gameObject.SetActive(false);



            OnLevelStart?.Invoke();
        }

        // 🔄 RESTART LEVEL
        public void RestartLevel()
        {
            SpawnLevel(currentLevel);
        }

        // 🧹 RESET GAME
        public void ResetGame()
        {
            PlayerPrefs.DeleteKey(levelKey);
            PlayerPrefs.Save();

            currentLevel = 0;
            SpawnLevel(currentLevel);
        }


        public void LevelComplete()
        {
            if (WinPanel != null && MainPanel != null)
            {
                MainPanel.gameObject.SetActive(false);
                WinPanel.gameObject.SetActive(true);

            }

           

            CoinsFlyAnimation.Instance.PlayAnimation();
            CoinsManager.Instance.AddCoins(100);
        }

        public void LevelFailed()
        {
            if (LosePanel != null && MainPanel != null)
            {
                MainPanel.gameObject.SetActive(false);
                LosePanel.gameObject.SetActive(true);

            }

            CoinsManager.Instance.SpendCoins(100);

        }

        void UpdateLevelText()
        {
            if (levelText != null)
            {
                levelText.text = (currentLevel + 1).ToString();
            }
        }
        // 📱 ANDROID TOAST
        void ShowAndroidToast(string message)
        {
#if UNITY_ANDROID && !UNITY_EDITOR
        AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");

        AndroidJavaClass toastClass = new AndroidJavaClass("android.widget.Toast");

        activity.Call("runOnUiThread", new AndroidJavaRunnable(() =>
        {
            AndroidJavaObject toastObject = toastClass.CallStatic<AndroidJavaObject>(
                "makeText",
                activity,
                message,
                toastClass.GetStatic<int>("LENGTH_SHORT")
            );
            toastObject.Call("show");
        }));
#endif
        }
    }

}
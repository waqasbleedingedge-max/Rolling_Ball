using System.Collections;
using UnityEngine;
using UnityEngine.UI;


namespace Rollance
{
    public class CoinsManager : MonoBehaviour
    {
        public static CoinsManager Instance;

        [Header("Settings")]
        public int startingCoins = 100;

        [Header("UI")]
        public Text coinsText;

        [Header("Animation")]
        public float animationSpeed = 200f; // higher = faster animation

        private int currentCoins;   // 💾 real value (saved)
        private int displayCoins;   // 🎬 animated value (UI)
        public Text pendingCoinsText;

        private string coinsKey = "PlayerCoins";
        private Coroutine coinRoutine;

        private void Awake()
        {
            // ✅ Singleton
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
            LoadCoins();
        }

        // 🔄 LOAD / INIT
        void LoadCoins()
        {
            if (!PlayerPrefs.HasKey(coinsKey))
            {
                currentCoins = startingCoins;
                PlayerPrefs.SetInt(coinsKey, currentCoins);
            }
            else
            {
                currentCoins = PlayerPrefs.GetInt(coinsKey);
            }

            displayCoins = currentCoins; // sync UI
            UpdateUI();
        }

        // 💾 SAVE
        void SaveCoins()
        {
            PlayerPrefs.SetInt(coinsKey, currentCoins);
            PlayerPrefs.Save();

            // 🔥 restart animation
            if (coinRoutine != null)
                StopCoroutine(coinRoutine);

            coinRoutine = StartCoroutine(AnimateCoins(currentCoins));
        }

        // ➕ ADD
        public void AddCoins(int amount)
        {
            currentCoins += amount;
            SaveCoins();
        }

        // ➖ SPEND
        public bool SpendCoins(int amount)
        {
            if (currentCoins >= amount)
            {
                currentCoins -= amount;
                SaveCoins();
                return true;
            }

           print("❌ Not enough coins");
            return false;
        }

        // 🎬 ANIMATION (Smooth Increase/Decrease)
        IEnumerator AnimateCoins(int target)
        {
            int startValue = displayCoins;          // starting (100)
            int totalToAdd = target - startValue;   // total increase (50)

            while (displayCoins != target)
            {
                displayCoins = (int)Mathf.MoveTowards(displayCoins, target, animationSpeed * Time.deltaTime);

                int pending = target - displayCoins; // 🔥 remaining coins

                UpdateUI(pending);

                yield return null;
            }

            // final ensure
            UpdateUI(0);
        }

        // 🔄 UI UPDATE
        void UpdateUI(int pending = 0)
        {
            if (coinsText != null)
                coinsText.text = displayCoins.ToString();

            if (pendingCoinsText != null)
                pendingCoinsText.text = pending.ToString(); // 🔥 remaining
        }

        // 🔍 GET CURRENT COINS
        public int GetCoins()
        {
            return currentCoins;
        }

        // 🧹 RESET (optional)
        public void ResetCoins()
        {
            PlayerPrefs.DeleteKey(coinsKey);
            LoadCoins();
        }

        // 🔧 UI Rebind (important for multiple scenes)
        public void SetUIText(Text newText)
        {
            coinsText = newText;
            UpdateUI();
        }
    }

}

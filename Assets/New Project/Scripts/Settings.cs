using UnityEngine;
using UnityEngine.UI;

namespace Rollance
{
    public class Settings : MonoBehaviour
    {
        public static Settings Instance;

        // ---------------- KEYS ----------------
        private const string SOUND_KEY = "SOUND";
        private const string MUSIC_KEY = "MUSIC";
        private const string VIBRATION_KEY = "VIBRATION";

        // ---------------- STATES ----------------
        public bool isSoundOn;
        public bool isMusicOn;
        public bool isVibrationOn;

        // ---------------- UI IMAGES ----------------
        [Header("UI Images")]
        public Image soundImage;
        public Image musicImage;
        public Image vibrationImage;

        // ---------------- SPRITES ----------------
        [Header("Sprites")]
        public Sprite soundOnSprite;
        public Sprite soundOffSprite;

        public Sprite musicOnSprite;
        public Sprite musicOffSprite;

        public Sprite vibrationOnSprite;
        public Sprite vibrationOffSprite;

        private void Awake()
        {
            // Singleton
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }

            LoadSettings();
            ApplyUI();
        }

        // ---------------- LOAD ----------------
        public void LoadSettings()
        {
            isSoundOn = PlayerPrefs.GetInt(SOUND_KEY, 1) == 1;
            isMusicOn = PlayerPrefs.GetInt(MUSIC_KEY, 1) == 1;
            isVibrationOn = PlayerPrefs.GetInt(VIBRATION_KEY, 1) == 1;
        }

        // ---------------- SOUND ----------------
        public void ToggleSound()
        {
            isSoundOn = !isSoundOn;

            PlayerPrefs.SetInt(SOUND_KEY, isSoundOn ? 1 : 0);
            PlayerPrefs.Save();

            ApplySound();
            ApplyUI();


           // MusicManager.Instance.ToggleMusic();
        }

        // ---------------- MUSIC ----------------
        public void ToggleMusic()
        {
            isMusicOn = !isMusicOn;

            PlayerPrefs.SetInt(MUSIC_KEY, isMusicOn ? 1 : 0);
            PlayerPrefs.Save();

            ApplyMusic();
            ApplyUI();
        }

        // ---------------- VIBRATION ----------------
        public void ToggleVibration()
        {
            isVibrationOn = !isVibrationOn;

            PlayerPrefs.SetInt(VIBRATION_KEY, isVibrationOn ? 1 : 0);
            PlayerPrefs.Save();

            ApplyUI();
        }

        // ---------------- APPLY SOUND ----------------
        void ApplySound()
        {
            // If you have SFX manager, control it here
           // Debug.Log("Sound: " + isSoundOn);
        }

        // ---------------- APPLY MUSIC ----------------
        void ApplyMusic()
        {
            AudioListener.volume = isMusicOn ? 1f : 0f;
           // Debug.Log("Music: " + isMusicOn);
        }

        // ---------------- APPLY UI ----------------
        public void ApplyUI()
        {
            if (soundImage != null)
                soundImage.sprite = isSoundOn ? soundOnSprite : soundOffSprite;

            if (musicImage != null)
                musicImage.sprite = isMusicOn ? musicOnSprite : musicOffSprite;

            if (vibrationImage != null)
                vibrationImage.sprite = isVibrationOn ? vibrationOnSprite : vibrationOffSprite;
        }

        // ---------------- VIBRATION CALL ----------------
        public void PlayVibration()
        {
            if (!isVibrationOn) return;
            Handheld.Vibrate();
        }
    }
}
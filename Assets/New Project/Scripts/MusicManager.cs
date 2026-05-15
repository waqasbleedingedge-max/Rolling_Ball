using UnityEngine;

namespace Rollance
{
    public class MusicManager : MonoBehaviour
    {
       
        [Header("Audio")]
        public AudioSource musicSource;

        [Header("Settings")]
        public bool playOnStart = true;

        private const string MUSIC_KEY = "MUSIC";
        private bool isMusicOn = true;

        // -------------------- UNITY --------------------

   

        void Start()
        {
            LoadSettings();

            if (playOnStart && isMusicOn)
                PlayMusic();
        }

        // -------------------- SETTINGS --------------------

        void LoadSettings()
        {
            isMusicOn = PlayerPrefs.GetInt(MUSIC_KEY, 1) == 1;
            ApplyState();
        }

        void SaveSettings()
        {
            PlayerPrefs.SetInt(MUSIC_KEY, isMusicOn ? 1 : 0);
            PlayerPrefs.Save();
        }

        // -------------------- CONTROL --------------------

        public void PlayMusic()
        {
            if (musicSource == null) return;

            if (!musicSource.isPlaying)
            {
                musicSource.loop = true;
                musicSource.Play();
            }
        }

        public void StopMusic()
        {
            if (musicSource == null) return;

            musicSource.Stop();
        }

        public void ToggleMusic()
        {
            isMusicOn = !isMusicOn;

            ApplyState();
            SaveSettings();
        }

        public void SetMusic(bool value)
        {
            isMusicOn = value;

            ApplyState();
            SaveSettings();
        }

        void ApplyState()
        {
            if (isMusicOn)
                PlayMusic();
            else
                StopMusic();
        }

        // -------------------- GET --------------------

        public bool IsMusicOn()
        {
            return isMusicOn;
        }
    }
}
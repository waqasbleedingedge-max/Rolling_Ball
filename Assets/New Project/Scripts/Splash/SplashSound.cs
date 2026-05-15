using UnityEngine;
using System.Collections;

namespace Rollance
{
    public class SplashSound : MonoBehaviour
    {
        [Header("Audio")]
        public AudioSource audioSource;
        public AudioClip firstSound;
        public AudioClip secondSound;

        [Header("Timing")]
        public float firstSoundDelay = 1f; // ⏳ delay before first sound

        private bool isRunning = false;

        private void Start()
        {
            if (PlayerPrefs.GetInt("MUSIC", 1) == 1)
            {
                PlaySplashSequence();
            }
        }

        public void PlaySplashSequence()
        {
            if (isRunning) return;

            StopAllCoroutines();
            StartCoroutine(PlaySounds());
        }

        IEnumerator PlaySounds()
        {
            isRunning = true;

            audioSource.Stop();

            // ⏳ Delay before first sound
            yield return new WaitForSeconds(firstSoundDelay);

            // 🔹 First sound (one time)
            audioSource.loop = false;
            audioSource.clip = firstSound;
            audioSource.Play();

            yield return new WaitForSeconds(firstSound.length);

            // 🔹 Second sound (loop)
            audioSource.clip = secondSound;
            audioSource.loop = true;
            audioSource.Play();
        }

        // Optional controls
        public void ToggleMusic(bool isOn)
        {
            PlayerPrefs.SetInt("MUSIC", isOn ? 1 : 0);

            if (isOn)
                PlaySplashSequence();
            else
                audioSource.Stop();
        }
    }
}
using UnityEngine;

namespace Rollance
{
    public class SoundManager : MonoBehaviour
    {
        public static SoundManager Instance;

        [Header("Audio Clips")]
        public AudioClip WinSound;
        public AudioClip FailedSound;
        public AudioClip ButtonSound;
        public AudioClip Collect;
        public AudioClip BreakBall;

        public AudioClip AddCoins;
        public AudioClip CollectCoin;
        public AudioClip BerralCollision;
        public AudioClip DestroBall;
        public AudioClip Hammer;
        
  

        [Header("Audio Source")]
        public AudioSource sfxSource;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);

                // 🔥 Ensure AudioSource exists
                if (sfxSource == null)
                    sfxSource = gameObject.AddComponent<AudioSource>();
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void Play_WinSound()
        {
            if (WinSound != null)
            {
                if(Settings.Instance.isSoundOn)
                {
                    sfxSource.PlayOneShot(WinSound);
                }
               
            }
        }

        public void Play_FailedSound()
        {
            if (FailedSound != null)
            {
                if (Settings.Instance.isSoundOn)
                {
                    sfxSource.PlayOneShot(FailedSound);
                }
            }
        }


        public void Play_ButtonClick()
        {
            if (ButtonSound != null)
            {
                if (Settings.Instance.isSoundOn)
                {
                    sfxSource.PlayOneShot(ButtonSound);
                }
            }
        }


        public void Play_Collect()
        {
            if (Collect != null)
            {
                if (Settings.Instance.isSoundOn)
                {
                    sfxSource.PlayOneShot(Collect);
                }
            }
        }


        public void Play_BreakBall()
        {
            sfxSource.PlayOneShot(BreakBall); 
        }
        public void Play_AddCoins()
        {
            sfxSource.PlayOneShot(AddCoins); 
        }
        public void Play_PickCoin()
        {
            sfxSource.PlayOneShot(CollectCoin); 
        }

        public void Play_BerralCollision()
        {
            sfxSource.PlayOneShot(BerralCollision);
        }
        public void Play_DestroBall()
        {
            sfxSource.PlayOneShot(DestroBall);
        }
        public void Play_Hammer()
        {
            sfxSource.PlayOneShot(Hammer);
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using MoreMountains.NiceVibrations;

namespace NA
{
    public class SoundsManager : SimpleSingleton<SoundsManager>
    {
        public float AllMusicVolium = .075f;

        [Header("Audio Source")]
        public AudioSource buttonClick;
        public AudioSource bgMM;
        public AudioSource bgMusic;
        public AudioSource bgMusic2;
        public AudioSource bgMusic3;
        public AudioSource ballLost;
        public AudioSource GenericSource;

        [Header("Audio Clip")]
        public AudioClip BallSwapSound;
        public AudioClip WheelSound, ClickBtn;


        IEnumerator Start()
        {
            yield return new WaitForSeconds(2.0f);
            SetSoundsVolume();
        }

        public void SetSoundsVolume()
        {
            if (PlayerPrefs.GetInt("music") == 0)
            {
                bgMM.volume = 1;
                bgMusic.volume = 1;
                bgMusic2.volume = 1;
                bgMusic3.volume = 1;
            }
            else
            {
                bgMM.volume = 0;
                bgMusic.volume = 0;
                bgMusic2.volume = 0;
                bgMusic3.volume = 0;
            }

            // Next
            if (PlayerPrefs.GetInt("sfx") == 0)
            {
                buttonClick.volume = 1;
            }
            else
            {
                buttonClick.volume = 0;
            }

        }

        public void ButtonClickPlay()
        {
            if (buttonClick.clip == null)
                buttonClick.clip = ClickBtn;

            buttonClick.Play();
            if (PlayerPrefs.GetInt("haptics") == 0)
            {

            }
        }

        public void PlayBGMusic()
        {
            int a = PlayerPrefs.GetInt("CurrentLevel");
            int b = a % 3;
            
            // Next
            if (a == 0)
            {
                PlayBGMusicStop2();
                PlayBGMusicStop3();
                bgMusic.Play();
            }
            else if (a == 1)
            {
                PlayBGMusicStop();
                PlayBGMusicStop3();
                bgMusic2.Play();
            }
            else if (a == 2)
            {
                PlayBGMusicStop();
                PlayBGMusicStop2();
                bgMusic3.Play();
            }
            PlayBGMusicStop2();
            PlayBGMusicStop3();
            bgMusic.Play();
        }

        public void PlayBGMusicStop()
        {
            bgMusic.Stop();
            bgMusic2.Stop();
            bgMusic3.Stop();
        }

        public void PlayBGMusic2()
        {
            PlayBGMusicStop3();
            bgMusic2.Play();
        }

        public void PlayBGMusicStop2()
        {
            bgMusic.Stop();
            bgMusic2.Stop();
            bgMusic3.Stop();
        }

        public void PlayBGMusic3()
        {
            PlayBGMusicStop2();
            bgMusic3.Play();

        }

        public void PlayBGMusicStop3()
        {
            bgMusic.Stop();
            bgMusic2.Stop();
            bgMusic3.Stop();
        }

        public void GenericFun(AudioClip a)
        {
            GenericSource.clip = a;
            GenericSource.Play();
        }
        public void SpinWheelSoundPlay()
        {
            GenericSource.PlayOneShot(WheelSound);

        }
        public void GameMusicActivation(bool value)
        {
            if (value)
            {
                bgMM.volume = AllMusicVolium;
                bgMusic.volume = AllMusicVolium;
                bgMusic2.volume = AllMusicVolium;
                bgMusic3.volume = AllMusicVolium;
            }
            else
            {
                bgMM.volume = 0;
                bgMusic.volume = 0;
                bgMusic2.volume = 0;
                bgMusic3.volume = 0;
            }
        }
        public void SpinWheelSound(bool value)
        {

            if (value)
                buttonClick.PlayOneShot(WheelSound);
            else
                buttonClick.Pause();
        }
    }
}
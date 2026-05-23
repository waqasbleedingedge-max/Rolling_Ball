using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManger_Custom : MonoBehaviour
{
    public static AudioManger_Custom Instance;
    public AudioSource SoundSource;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {
        SoundSource.Play();
    }
}

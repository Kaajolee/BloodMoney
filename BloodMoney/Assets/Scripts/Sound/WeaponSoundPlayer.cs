using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSoundPlayer : MonoBehaviour
{
    private static WeaponSoundPlayer _instance;
    public static WeaponSoundPlayer Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("WeaponSoundPlayer is null");
            }
            return _instance;
        }
    }
    private void Awake()
    {
        _instance = this;
    }

    public AudioClip gunshotClip;

    public int audioSourcePoolSize = 5;

    private AudioSource[] audioSources;

    private int currentIndex = 0;


    void Start()
    {
        audioSources = new AudioSource[audioSourcePoolSize];

        for (int i = 0; i < audioSourcePoolSize; i++)
        {
            audioSources[i] = gameObject.AddComponent<AudioSource>();
            audioSources[i].clip = gunshotClip;
            audioSources[i].volume = 0.2f;
        }
    }
    public AudioSource GetAudioSource()
    {
        return gameObject.GetComponent<AudioSource>();
    }
    public void SetAudioClip(AudioClip audioClip)
    {
        for (int i = 0; i < audioSourcePoolSize; i++)
        {
            audioSources[i].clip = audioClip;
        }
    }
    public void Play()
    {
        audioSources[currentIndex].Play();
        currentIndex = (currentIndex + 1) % audioSourcePoolSize;
    }
}

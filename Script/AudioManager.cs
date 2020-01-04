using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance = null;
    public AudioSource audioSource;

    public static string audioName;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public void ClearAudioSource ()
    {
        StopAudioSource();
        instance.audioSource = null;
        audioName = "";
    }

    public void StartAudioSource (AudioSource audio, string name, float volume = 0.5f)
    {
        ClearAudioSource();

        instance.audioSource = audio;
        instance.audioSource.volume = volume;
        audioName = name;

        if (instance.audioSource != null && !instance.audioSource.isPlaying)
        {
            instance.audioSource.Play();
        }
    }

    public void StopAudioSource ()
    {
        if (instance.audioSource != null && instance.audioSource.isPlaying)
        {
            instance.audioSource.Stop();
        }
    }

    public void PauseAudioSource()
    {
        if (instance.audioSource != null && instance.audioSource.isPlaying)
        {
            instance.audioSource.Pause();
        }
    }
}

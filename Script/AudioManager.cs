using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance = null;
    private static AudioSource audioSource;

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

    public static void SetAudioSource (AudioSource audio, string name, float volume = 0.5f) {
        audioSource = audio;
        audioSource.volume = volume;
        audioName = name;
    }

    public static void ClearAudioSource ()
    {
        StopAudioSource();
        audioSource = null;
        audioName = "";
    }

    public static void StartAudioSource ()
    {
        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    public static void StopAudioSource ()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }

    public static void PauseAudioSource()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Pause();
        }
    }
}

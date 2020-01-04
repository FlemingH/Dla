using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance = null;

    private AudioSource audioSource;

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

        audioSource = GameObject.Find("AudioPlayer").GetComponent<AudioSource>();
    }

    public void ClearAudioSource ()
    {
        StopAudioSource();
        audioName = "";
    }

    public void StartAudioSource (string path, string name, float volume = 0.5f)
    {
        ClearAudioSource();

        audioSource.clip = Resources.Load<AudioClip>(path + "/" + name);
        audioSource.volume = volume;
        audioName = name;

        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    public void StopAudioSource ()
    {
        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }

    public void PauseAudioSource()
    {
        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Pause();
        }
    }
}

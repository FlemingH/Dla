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
        audioSource.clip = null;
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
            StartCoroutine("AudioSourceVolume", new AudioNode(audioSource, audioSource.clip, 0, 0.1f, 3));
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
        StopCoroutine("AudioSourceVolume");
        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Pause();
        }
    }

    public void RestartAudioSource()
    {
        if (audioSource != null && !audioSource.isPlaying)
        {
            StartCoroutine("AudioSourceVolume", new AudioNode(audioSource, audioSource.clip, 0, 0.1f, 3));
        }
    }

    private IEnumerator AudioSourceVolume(AudioNode audioNode)
    {
        float initVolume = audioNode.audioSource.volume;
        float preTime = 1.0f / audioNode.durationTime;
        if (!audioNode.audioSource.isPlaying) audioNode.audioSource.Play();
        while (true)
        {
            initVolume += audioNode.volumeAdd * Time.deltaTime * preTime;
            if (initVolume > 0.3f || initVolume < 0)
            {
                initVolume = Mathf.Clamp01(initVolume);
                audioNode.audioSource.volume = initVolume;
                if (initVolume == 0) audioNode.audioSource.Stop();
                break;
            }
            else
            {
                audioNode.audioSource.volume = initVolume;
            }
            yield return 1;
        }
    }
}

public struct AudioNode
{
    public AudioSource audioSource;
    public float volumeAdd;
    public float durationTime;

    public AudioNode(AudioSource source, AudioClip clip, float m_initVolume, float m_volumeAdd, float m_durationTime)
    {
        audioSource = source;
        audioSource.playOnAwake = false;
        audioSource.volume = m_initVolume;
        audioSource.clip = clip;
        volumeAdd = m_volumeAdd;
        durationTime = m_durationTime;
    }
}
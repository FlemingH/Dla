using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance = null;

    private AudioSource audioSource;
    private bool isLoop = false;
    // to know if it is stop or pause
    private bool isPause = false;
    private float defaultMaxVolume = 0.3f;
    private float fadeTime = 1;
    private float curVolume = 0.0f;

    private void Update()
    {
        Timer.Instance.UpdateTimer();
    }

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

    public void StartAudioSource (string path, string name, bool loop = false)
    {
        audioSource.clip = Resources.Load<AudioClip>(path + "/" + name);
        isLoop = loop;

        if (audioSource != null && !audioSource.isPlaying)
        {
            StartCoroutine("AudioSourceVolumeStart", new AudioNode(audioSource, audioSource.clip, 0, 0.1f, fadeTime, isLoop));
        } else if (audioSource != null && audioSource.isPlaying)
        {
            FadeStopAudioSource();

            Timer.Instance.AddTimerTask(fadeTime + 2, () => {
                StopCoroutine("AudioSourceVolumeStart");
                StopCoroutine("AudioSourceVolumeStop");

                StartCoroutine("AudioSourceVolumeStart", new AudioNode(audioSource, audioSource.clip, 0, 0.1f, fadeTime, isLoop));
            }); 
        }
    }

    public void FadeStopAudioSource ()
    {
        StopCoroutine("AudioSourceVolumeStart");
        if (audioSource != null && audioSource.isPlaying)
        {
            StartCoroutine("AudioSourceVolumeStop", new AudioNode(audioSource, audioSource.clip, curVolume, 0.1f, fadeTime, false));
        }
    }

    public void PauseAudioSource()
    {
        if (audioSource != null && audioSource.isPlaying)
        {
            isPause = true;
            audioSource.Pause();
        }
    }

    public void RestartAudioSource()
    {
        if (audioSource != null && !audioSource.isPlaying && isPause)
        {
            isPause = false;
            StartCoroutine("AudioSourceVolumeStart", new AudioNode(audioSource, audioSource.clip, 0, 0.1f, fadeTime, isLoop));
        }
    }

    private IEnumerator AudioSourceVolumeStart (AudioNode audioNode)
    {
        float initVolume = audioNode.audioSource.volume;
        float preTime = 1.0f / audioNode.durationTime;
        if (!audioNode.audioSource.isPlaying) audioNode.audioSource.Play();
        while (true)
        {
            initVolume += audioNode.volumeAdd * Time.deltaTime * preTime;
            curVolume = initVolume;
            if (initVolume > defaultMaxVolume || initVolume < 0)
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

    private IEnumerator AudioSourceVolumeStop (AudioNode audioNode)
    {
        float initVolume = audioNode.audioSource.volume;
        float preTime = 1.0f / audioNode.durationTime;
        while (true)
        {
            initVolume -= audioNode.volumeAdd * Time.deltaTime * preTime;
            if (initVolume <= 0)
            {
                audioNode.audioSource.volume = 0;
                audioNode.audioSource.Stop();
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

    public AudioNode(AudioSource source, AudioClip clip, float m_initVolume, float m_volumeAdd, float m_durationTime, bool isLoop)
    {   
        audioSource = source;
        audioSource.playOnAwake = false;
        audioSource.volume = m_initVolume;
        audioSource.clip = clip;
        audioSource.loop = isLoop;
        volumeAdd = m_volumeAdd;
        durationTime = m_durationTime;
    }
}
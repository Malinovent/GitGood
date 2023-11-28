using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    #region SINGLETON
    public static AudioManager Singleton;

    private void Awake()
    {
        if (Singleton == null)
        {
            Singleton = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    #endregion

    private List<AudioSource> audioSources = new List<AudioSource>();

    [SerializeField] SoundEffect[] soundEffects;

    private void Start()
    {
        CreateAudioSource();
    }

    private AudioSource CreateAudioSource()
    {
        GameObject audioSourceGO = new GameObject();
        audioSourceGO.name = "AudioSource";
        audioSourceGO.transform.parent = this.transform;
        AudioSource newAudioSource = audioSourceGO.AddComponent<AudioSource>();
        audioSources.Add(newAudioSource);

        return newAudioSource;
    }

    public void PlaySoundEffect(string soundName)
    {
        foreach (SoundEffect sfx in soundEffects)
        {
            if(sfx.soundName == soundName)
            {
                PlaySoundEffect(sfx.audioClip);
            }
        }
    }

    public void PlaySoundEffect(AudioClip audioClip)
    {
        foreach(AudioSource audioSource in audioSources)
        {
            if(!audioSource.isPlaying)
            {
                audioSource.clip = audioClip;
                audioSource.Play();
                return;
            }
        }

        //Create new audiosource if all of them are playing
        AudioSource createdAudioSource = CreateAudioSource();
        createdAudioSource.clip = audioClip;
        createdAudioSource.Play();
    }
}

[System.Serializable]
public struct SoundEffect
{
    public string soundName;
    public AudioClip audioClip;


}
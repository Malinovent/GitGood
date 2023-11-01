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

    [SerializeField] AudioClip[] soundEffects;

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
        switch(soundName)
        {
            case "fireball":
                //play fireball
                PlaySoundEffect(0);
                break;
            case "iceball":
                PlaySoundEffect(1);
                //play iceball
                break;
        }
    }

    public void PlaySoundEffect(int SFXindex)
    {
        foreach(AudioSource audioSource in audioSources)
        {
            if(!audioSource.isPlaying)
            {
                audioSource.clip = soundEffects[SFXindex];
                audioSource.Play();
                return;
            }
        }

        AudioSource createdAudioSource = CreateAudioSource();
        createdAudioSource.clip = soundEffects[SFXindex];
        createdAudioSource.Play();
    }
}

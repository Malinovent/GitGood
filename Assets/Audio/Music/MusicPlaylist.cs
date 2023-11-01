using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicPlaylist : MonoBehaviour
{

    [SerializeField] private AudioClip[] musicPlaylist;

    private AudioSource audioSource;
    private int musicIndex = 0;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        PlayMusic(0);
    }

    private void Update()
    {
        
        PlayNextMusic();
        
    }

    public void PlayNextMusic()
    {

        if (!audioSource.isPlaying)
        {
            musicIndex++;
            if(musicIndex >= musicPlaylist.Length)
            {
                musicIndex = 0;
            }

            PlayMusic(musicIndex);
        }
    }

    public void PlayMusic(int musicIndex)
    {
        audioSource.clip = musicPlaylist[musicIndex];
        audioSource.Play();
    }

}

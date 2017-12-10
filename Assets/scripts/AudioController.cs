using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class AudioController : MonoBehaviour 
{
    public List<AudioClip> audioClips = new List<AudioClip>();

    public bool playOnStart = false;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = audioClips[Random.Range(0,audioClips.Count)];
        audioSource.loop = true;
        audioSource.volume = 0.2f;

        if (playOnStart)
        {
            audioSource.Play();
        }
    }

    public void Play()
    {
        audioSource.loop = false;
        audioSource.Play();
    }
}

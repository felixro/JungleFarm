using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonAction : MonoBehaviour 
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void hit()
    {
        transform.gameObject.SendMessage("randomSpin");

        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
}

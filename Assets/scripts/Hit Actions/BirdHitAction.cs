using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdHitAction : MonoBehaviour 
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void hit(bool isDrag = false)
    {
        transform.gameObject.SendMessage("changeDirection");

        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
}

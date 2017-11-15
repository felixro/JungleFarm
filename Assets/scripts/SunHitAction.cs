using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunHitAction : MonoBehaviour 
{
    private AudioSource audioSource;
    private Animator animator;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    public void hit()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }

        if (animator.enabled)
        {
            animator.enabled = false;
        }
        else
        {
            animator.enabled = true;    
        }
    }
}

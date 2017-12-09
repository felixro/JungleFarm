using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitingBodyAction : MonoBehaviour 
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
        if (animator.enabled)
        {
            animator.enabled = false;
        }
        else
        {
            animator.enabled = true;
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
    }
}

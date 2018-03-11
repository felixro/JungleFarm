using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bend : MonoBehaviour 
{
    Animator animator;

    public float bendAnimationLikelyhood = 0.5f;

	// Use this for initialization
	void Start () 
    {
        animator = GetComponent<Animator>();
        InvokeRepeating("maybePlayBendAnimation", 0, 5.0f);
	}

    void maybePlayBendAnimation()
    {
        if (Random.value <= bendAnimationLikelyhood)
        {
            animator.SetTrigger("bend");
        }
    }
}

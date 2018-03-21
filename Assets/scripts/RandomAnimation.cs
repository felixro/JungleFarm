using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAnimation : MonoBehaviour
{
    public List<CustomAnimation> customAnimations = new List<CustomAnimation>();

    Animator animator;

	void Start () 
    {
        animator = GetComponent<Animator>();

        InvokeRepeating("maybeTransitionToAnimation", 0, 5.0f);
	}

    void maybeTransitionToAnimation()
    {
        foreach(CustomAnimation curAnimation in customAnimations)
        {
            if (Random.value <= curAnimation._chanceOfFiring)
            {
                animator.SetTrigger(curAnimation._name);
            }
        }
    }
}

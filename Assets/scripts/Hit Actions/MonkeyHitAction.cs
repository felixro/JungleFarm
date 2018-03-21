using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyHitAction : MonoBehaviour 
{
    private AudioSource audioSource;
    private Rigidbody2D rigidbody;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    public void hit(bool isDrag = false)
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
            StartCoroutine(AddTemporaryForce());
        }
    }

    IEnumerator AddTemporaryForce()
    {
        Vector2 vector =  new Vector2(
            Random.Range(-400,400),
            Random.Range(200,600)
        );

        rigidbody.AddForce(vector);

        yield return new WaitForSeconds(1.0f);
    }
}

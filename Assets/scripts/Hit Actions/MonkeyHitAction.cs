using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyHitAction : MonoBehaviour 
{
    public float defaultThrust = 20f;

    private Rigidbody2D rb;
    private float thrust = 0f;
    private AudioSource audioSource;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        rb.AddRelativeForce(Vector2.up * thrust);
    }

    public void hit(bool isDrag = false)
    {
        transform.gameObject.SendMessage("randomSpin");

        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }

        StartCoroutine(AddTemporaryForce());
    }

    IEnumerator AddTemporaryForce()
    {
        thrust = defaultThrust;

        yield return new WaitForSeconds(1.0f);

        thrust = 0f;
    }
}

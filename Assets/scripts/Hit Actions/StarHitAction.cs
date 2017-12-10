using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarHitAction : MonoBehaviour 
{
    private AudioController audioController;
    private Rigidbody2D rb;
    private ParticleSystem ps;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        ps = GetComponentInChildren<ParticleSystem>();
        audioController = GetComponent<AudioController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void hit()
    {
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody2D>();
            rb.gravityScale = 0.3f;

            rb.AddForce(Vector2.up * 100f);
            rb.AddForce(
                new Vector2(
                    Random.Range(-1f, 1f), 0
                ) * 100f
            );

            var emission = ps.emission;
            emission.enabled = true;

            audioController.Play();
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "ObjectDestroyer")
        {
            // only destroy the rigidbody
            Destroy(rb);

            var emission = ps.emission;
            emission.enabled = false;

            spriteRenderer.enabled = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSparkle : MonoBehaviour 
{
    private SpriteRenderer spriteRenderer;

    private float creationTime = float.MaxValue;
    private float randomDelay;

    private float fadeInSpeed = 0.3f;
    private float fadeOutSpeed = 0.3f;

    private bool isFadingOut = false;

	void Start () 
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        randomDelay = Random.Range(0.0f, 5.0f);
	}
	
    void Update()
    {
        if (isFadingOut)
        {
            FadeOut();
            return;
        }

        if (creationTime + randomDelay <= Time.time)
        {
            FadeIn();
        }
    }
        
    public void Show()
    {
        creationTime = Time.time;
    }

    public void FadeIn()
    {
        isFadingOut = false;
        Color color = spriteRenderer.color;
        if (color.a < 1.0f)
        {
            spriteRenderer.color = new Color(color.r, color.g, color.b, color.a + (fadeInSpeed * Time.deltaTime));
        }
    }

    public void FadeOut()
    {
        isFadingOut = true;
        Color color = spriteRenderer.color;
        if (color.a >= 0.0f)
        {
            spriteRenderer.color = new Color(color.r, color.g, color.b, color.a - (fadeOutSpeed * Time.deltaTime));
        }
    }
}

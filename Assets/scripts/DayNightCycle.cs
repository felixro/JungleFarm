﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour 
{
    public SpriteRenderer moonSpriteRenderer;
    public SpriteRenderer sunSpriteRenderer;

    private SpriteRenderer spriteRenderer;

    private Color dayColor = Color.white;
    private Color nightColor = Color.black;
    private Color lerpedColor;

    float duration = 5;
    float smoothness = 0.02f;

    private bool changingColor = false;
    private bool isDay = true;

	void Start () 
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
	}
	
    void FixedUpdate()
    {
        if (!changingColor)
        {
            if (isDay && moonSpriteRenderer.isVisible)
            {
                isDay = false;
                StartCoroutine(ChangeFromToColor(dayColor, nightColor));
            }
            else if (!isDay && sunSpriteRenderer.isVisible)
            {
                isDay = true;
                StartCoroutine(ChangeFromToColor(nightColor, dayColor));
            }
        }
    }

	void Update () 
    {
        Debug.Log(sunSpriteRenderer.isVisible);
	}

    IEnumerator ChangeFromToColor(Color fromColor, Color toColor)
    {
        changingColor = true;
        float progress = 0; //This float will serve as the 3rd parameter of the lerp function.
        float increment = smoothness/duration; //The amount of change to apply.
        while(progress < 1)
        {
            lerpedColor = Color.Lerp(fromColor, toColor, progress);
            progress += increment;
            spriteRenderer.color = lerpedColor;
            yield return new WaitForSeconds(smoothness);
        }
        changingColor = false;
        yield return true;
    }
}

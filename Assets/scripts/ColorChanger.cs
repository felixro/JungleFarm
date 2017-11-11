using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour 
{
    private ParticleSystem[] allParticleSystems;

    void Start()
    {
        Color randomColor = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        GetComponent<Renderer>().material.color = randomColor;

        allParticleSystems = GetComponentsInChildren<ParticleSystem>(true);

        foreach(ParticleSystem ps in allParticleSystems)
        {
            var main = ps.main;
            main.startColor = randomColor;
        }
    }
}

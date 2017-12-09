using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitAction : MonoBehaviour 
{
    private ParticleSystem[] allParticleSystems;

    void Start()
    {
        allParticleSystems = GetComponentsInChildren<ParticleSystem>(true);
    }

    public void hit()
    {
        foreach(ParticleSystem ps in allParticleSystems)
        {
            if (ps.CompareTag("TrailPS"))
            {
                var main = ps.main;
                main.loop = false;
                ps.Stop();
            }
            else if (ps.CompareTag("DeathPS"))
            {
                ps.transform.position = transform.position;
                ps.transform.parent = null;
                ps.gameObject.SetActive(true);
            }

            ps.transform.parent = null;
            Destroy(ps.gameObject, 5.0f);
        }

        Destroy(gameObject);
    }
}

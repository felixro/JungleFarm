using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CustomAnimation
{
    public string _name;
    public float _chanceOfFiring;

    public CustomAnimation(
        string name, 
        float chanceOfFiring
    )
    {
        _name = name;
        _chanceOfFiring = chanceOfFiring;
    }
}

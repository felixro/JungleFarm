using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyHitAction : MonoBehaviour 
{
    public void hit()
    {
        Debug.Log("Hit the monkey...");
        transform.gameObject.SendMessage("randomSpin");
    }
}

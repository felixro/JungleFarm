using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLifecycle : MonoBehaviour 
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            Application.Quit();
        }
    }
}

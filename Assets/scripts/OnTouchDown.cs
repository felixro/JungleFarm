using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OnTouchDown : MonoBehaviour
{
    void Update () 
    {
        #if UNITY_EDITOR

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast (ray, out hit))
            {
                hitObject(hit.transform.gameObject);
            }
        }

        #elif UNITY_IOS || UNITY_ANDROID

        RaycastHit hit = new RaycastHit();
        for (int i = 0; i < Input.touchCount; ++i) 
        {
            Debug.Log("touchCount");
            if (Input.GetTouch(i).phase.Equals(TouchPhase.Began)) 
            {
                Debug.Log("touchPhase.Began");
                // Construct a ray from the current touch coordinates
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);

                if (Physics.Raycast(ray, out hit)) 
                {
                    hitObject(hit.transform.gameObject);
                }
            }
        }

        #endif
    }

    void hitObject(GameObject gameobject)
    {
        gameobject.SendMessage("hit");
    }
}
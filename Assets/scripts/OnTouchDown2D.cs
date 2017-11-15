using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OnTouchDown2D : MonoBehaviour
{
    void Update () 
    {
        #if UNITY_EDITOR

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(
                Camera.main.ScreenToWorldPoint(Input.mousePosition), 
                Vector2.zero
            );

            if(hit != null && hit.collider != null)
            {
                hitObject(hit.transform.gameObject);
            }
        }

        #elif UNITY_IOS || UNITY_ANDROID

        for (int i = 0; i < Input.touchCount; ++i) 
        {
            if (Input.GetTouch(i).phase.Equals(TouchPhase.Began)) 
            {
                Vector3 pos = Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position);

                // Construct a ray from the current touch coordinates
                RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);

                if (hit != null && hit.collider != null)
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
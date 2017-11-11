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

            if(hit.collider != null)
            {
                hitObject(hit.transform.gameObject);
            }
        }

        #elif UNITY_IOS || UNITY_ANDROID

        RaycastHit2D hit = new RaycastHit2D();
        for (int i = 0; i < Input.touchCount; ++i) 
        {
            if (Input.GetTouch(i).phase.Equals(TouchPhase.Began)) 
            {
                // Construct a ray from the current touch coordinates
                Ray2D ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);

                if (Physics2D.Raycast(ray, out hit))
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
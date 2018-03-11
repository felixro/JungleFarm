using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class OnTouchDown2D : MonoBehaviour
{
    void Update () 
    {
        #if UNITY_EDITOR

        if (Input.GetMouseButton(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(
                Camera.main.ScreenToWorldPoint(Input.mousePosition), 
                Vector2.zero
            );

            if(hit != null && hit.collider != null)
            {
                GameObject gameObject = hit.transform.gameObject;

                if (gameObject.CompareTag("ActionOnTouch"))
                {
                    hitObject(hit.transform.gameObject);   
                }
            }
        }

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

        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            SceneManager.LoadScene("menu-main", LoadSceneMode.Single);
            return;
        }

        for (int i = 0; i < Input.touchCount; ++i) 
        {
            // most objects have to be clicked on for the hit action to be triggered
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
            // some objects do not have to be clicked on but merely touched (e.g. stars)
            else if (Input.GetTouch(i).phase.Equals(TouchPhase.Moved))
            {
                Vector3 pos = Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position);

                // Construct a ray from the current touch coordinates
                RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);

                if (hit != null && hit.collider != null)
                {
                    GameObject gameObject = hit.transform.gameObject;

                    if (gameObject.CompareTag("ActionOnTouch"))
                    {
                        hitObject(hit.transform.gameObject);
                    }
                }
            }
        }

        #endif
    }

    void hitObject(GameObject gameobject, bool isDrag = false)
    {
        gameobject.SendMessage("hit", isDrag);
    }
}
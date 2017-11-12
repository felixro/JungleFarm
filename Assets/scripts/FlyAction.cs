using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyAction : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float frequency = 3.0f; // Speed of sine movement
    public float magnitude = 1.0f; // Size of sine movement
    public bool leftToRightDirection = true;

    private Vector3 axis;
    private Vector3 pos;

    private float borderOffset = 10f;
    private Rect border;

    void Start () 
    {
        pos = transform.position;
        axis = transform.up;
    }

    void Update()
    {
        if (transform.position.x + borderOffset <= border.x)
        {
            changeDirection();
        }

        if (transform.position.x + borderOffset >= border.width)
        {
            changeDirection();
        }

        pos += transform.right * Time.deltaTime * moveSpeed * (leftToRightDirection ? 1f : -1f);
        transform.position = pos + axis * Mathf.Sin (Time.time * frequency) * magnitude;
    }

    public void changeDirection()
    {
        // flip sprite
        leftToRightDirection = !leftToRightDirection;

        Vector3 curLocalScale = transform.localScale;

        transform.localScale = new Vector3(
            leftToRightDirection ? Mathf.Abs(curLocalScale.x) : Mathf.Abs(curLocalScale.x) * -1, 
            curLocalScale.y, 
            curLocalScale.z
        );
    }

    public void setBorder(Rect rect)
    {
        border = rect;
    }
}
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

    void Start () 
    {
        pos = transform.position;
        axis = transform.up;
    }

    void Update()
    {
        pos += transform.right * Time.deltaTime * moveSpeed * (leftToRightDirection ? 1f : -1f);
        transform.position = pos + axis * Mathf.Sin (Time.time * frequency) * magnitude;
    }

    public void changeDirection()
    {
        // flip sprite
        leftToRightDirection = !leftToRightDirection;
        transform.localScale = new Vector3(
            leftToRightDirection ? 1f : -1f, 
            1f, 
            1f
        );
    }
}
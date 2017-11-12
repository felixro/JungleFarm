using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyAction : MonoBehaviour
{
    public float MoveSpeed = 2f;

    public float frequency = 3.0f; // Speed of sine movement
    public float magnitude = 1.0f; // Size of sine movement

    private Vector3 axis;
    private Vector3 pos;

    private float horizontalDirection = 1f;

    void Start () 
    {
        pos = transform.position;
        axis = transform.up;
    }

    void Update()
    {
        pos += transform.right * Time.deltaTime * MoveSpeed * horizontalDirection;
        transform.position = pos + axis * Mathf.Sin (Time.time * frequency) * magnitude;
    }

    public void changeDirection()
    {
        // flip sprite
        horizontalDirection = -horizontalDirection;
        transform.localScale = new Vector3(horizontalDirection, 1f, 1f);
    }
}
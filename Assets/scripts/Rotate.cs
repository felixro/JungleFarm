using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour 
{
    public float rotateSpeed = 100f;
    public bool rotateX = false;
    public bool rotateY = false;
    public bool rotateZ = true;

    public bool clockWise = true;

    void Update()
    {
        if (clockWise)
        {
            if (rotateX)
            {
                transform.Rotate(-Vector3.right * Time.deltaTime * rotateSpeed);
            }

            if (rotateY)
            {
                transform.Rotate(-Vector3.up * Time.deltaTime * rotateSpeed);
            }

            if (rotateZ)
            {
                transform.Rotate(-Vector3.forward * Time.deltaTime * rotateSpeed);   
            }
        }
        else
        {
            if (rotateX)
            {
                transform.Rotate(Vector3.right * Time.deltaTime * rotateSpeed);
            }

            if (rotateY)
            {
                transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed);
            }

            if (rotateZ)
            {
                transform.Rotate(Vector3.forward * Time.deltaTime * rotateSpeed);   
            }
        }

    }
}

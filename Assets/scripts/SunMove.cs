using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunMove : MonoBehaviour 
{
    private LineRenderer lineRenderer;
    private Vector3[] positions;

    private int curPosition;
    private int nextPosition;
    private int nrOfPositions;
    private float speed = 0.5f;

	void Start () 
    {
        lineRenderer = GetComponent<LineRenderer>();

        positions = new Vector3[lineRenderer.positionCount];
        lineRenderer.GetPositions(positions);

        // initially move sun to the first vector in positions
        curPosition = 0;
        nextPosition = 1;
        nrOfPositions = positions.Length;
        transform.position = positions[curPosition];
	}

    void Update() 
    {
        float step = speed * Time.deltaTime;

        nextPosition = (curPosition + 1) % nrOfPositions;

        if(transform.position == positions[nextPosition])
        {
            curPosition++;

            if (curPosition >= positions.Length)
            {
                curPosition = -1;
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, positions[nextPosition], step);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitingBodyMove : MonoBehaviour 
{
    public int curPosition = 0;

    private LineRenderer lineRenderer;
    private Vector3[] positions;

    private int nextPosition;
    private int nrOfPositions;
    private float speed = 0.8f;

	void Start () 
    {
        lineRenderer = GetComponent<LineRenderer>();

        positions = new Vector3[lineRenderer.positionCount];
        lineRenderer.GetPositions(positions);

        // initially move sun to the first vector in positions
        nextPosition = curPosition + 1;
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour 
{
    public List<GameObject> birds;

    public int numberOfPrefabs = 1;

	void Start() 
    {
        for (int i=0;i<numberOfPrefabs;i++)
        {
            Instantiate();
        }
	}

    void Instantiate()
    {
        Vector3 position = new Vector3(
            Random.Range(
                transform.position.x, 
                transform.position.x
            ), 
            Random.Range(
                transform.position.y, 
                transform.position.y
            ), 
            0
        );

        GameObject instance = Instantiate(
            birds[Random.Range(0,birds.Count)],
            position, 
            Quaternion.identity
        );

        Physics2D.IgnoreCollision(instance.GetComponent<PolygonCollider2D>(), GetComponent<PolygonCollider2D>());
    }
}

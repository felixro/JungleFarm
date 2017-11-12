using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour 
{
    public List<GameObject> birds;

    public int numberOfPrefabs = 1;

    private Transform spawnAreaTransform;
    private Rect spawnArea;

	void Start() 
    {
        spawnAreaTransform = gameObject.transform.GetChild(0);

        Debug.Log(spawnAreaTransform.position);

        spawnArea = new Rect(
            transform.position.x - spawnAreaTransform.localScale.x/2,
            transform.position.y + spawnAreaTransform.localScale.y/2,
            spawnAreaTransform.localScale.x,
            spawnAreaTransform.localScale.y
        );

        Debug.Log(spawnArea);

        for (int i=0;i<numberOfPrefabs;i++)
        {
            Instantiate();
        }
	}

    void Instantiate()
    {
        Vector3 position = new Vector3(
            Random.Range(
                spawnAreaTransform.position.x - spawnArea.width/2, 
                spawnAreaTransform.position.x + spawnArea.width/2
            ), 
            Random.Range(
                spawnAreaTransform.position.y - spawnArea.height/2,
                spawnAreaTransform.position.y + spawnArea.height/2
            ), 
            0
        );

        GameObject instance = Instantiate(
            birds[Random.Range(0,birds.Count)],
            position, 
            Quaternion.identity
        );

        randomizeFlightParameters(instance);
    }

    void randomizeFlightParameters(GameObject instance)
    {
        FlyAction flyAction = instance.GetComponent<FlyAction>();

        if (Random.value > 0.5f)
        {
            flyAction.changeDirection();
        }

        flyAction.frequency = Random.Range(1f, 3f);
        flyAction.moveSpeed = Random.Range(1f, 4f);
        flyAction.magnitude = Random.Range(1f, 2.5f);
    }
}

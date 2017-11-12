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
            spawnAreaTransform.position.x - spawnAreaTransform.localScale.x/2,
            spawnAreaTransform.position.y - spawnAreaTransform.localScale.y/2,
            spawnAreaTransform.localScale.x,
            spawnAreaTransform.localScale.y
        );

        for (int i=0;i<numberOfPrefabs;i++)
        {
            Instantiate();
        }
	}

    void Instantiate()
    {
        Vector3 position = new Vector3(
            Random.Range(
                spawnArea.x, 
                spawnArea.x + spawnArea.width
            ), 
            Random.Range(
                spawnArea.y,
                spawnArea.y + spawnArea.height
            ), 
            0
        );

        GameObject instance = Instantiate(
            birds[Random.Range(0,birds.Count)],
            position, 
            Quaternion.identity
        );
            
        updateFlightParameters(instance);
    }

    void updateFlightParameters(GameObject instance)
    {
        FlyAction flyAction = instance.GetComponent<FlyAction>();

        if (Random.value > 0.5f)
        {
            flyAction.changeDirection();
        }

        flyAction.frequency = Random.Range(1f, 3f);
        flyAction.moveSpeed = Random.Range(1f, 4f);
        flyAction.magnitude = Random.Range(1f, 2.5f);

        flyAction.setBorder(spawnArea);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearController : MonoBehaviour 
{
    public List<GameObject> bears;

    public int numberOfPrefabs = 1;

    private Transform spawnAreaTransform;
    private Rect spawnArea;

	void Start() 
    {
        spawnAreaTransform = gameObject.transform.GetChild(0);

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
            bears[Random.Range(0,bears.Count)],
            position, 
            Quaternion.identity
        );
            
        updateParameters(instance);
    }

    void updateParameters(GameObject instance)
    {
        BearHitAction bearHitAction = instance.GetComponent<BearHitAction>();

        if (Random.value > 0.5f)
        {
            bearHitAction.changeDirection();
        }

        Vector3 curScale = instance.transform.localScale;
        instance.transform.localScale = curScale;

        bearHitAction.setBorder(spawnArea);
    }
}

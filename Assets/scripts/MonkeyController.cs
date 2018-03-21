using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyController : MonoBehaviour 
{
    public BorderController border;

    public GameObject prefab;

    public float borderOffset = 0.5f;
    public int numberOfPrefabs = 10;

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

        Instantiate(prefab, position, Quaternion.identity);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyController : MonoBehaviour 
{
    public BorderController border;

    public GameObject prefab;

    public float borderOffset = 0.5f;
    public int numberOfPrefabs = 10;

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
                transform.position.x - border.bounds.extents.x + borderOffset, 
                transform.position.x + border.bounds.extents.x - borderOffset
            ), 
            Random.Range(
                transform.position.y - border.bounds.extents.y + borderOffset, 
                transform.position.y + border.bounds.extents.y - borderOffset
            ), 
            0
        );

        Instantiate(prefab, position, Quaternion.identity);
    }
}

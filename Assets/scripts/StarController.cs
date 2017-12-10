using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarController : MonoBehaviour 
{
    public List<GameObject> starTypes;

    public int numberOfPrefabs = 5;

    private Transform spawnAreaTransform;
    private Rect spawnArea;

    private List<GameObject> instantiatedStars;

    private bool isDay = true;

    private float zPosition = 15f;

	void Start() 
    {
        spawnAreaTransform = gameObject.transform.GetChild(0);

        spawnArea = new Rect(
            spawnAreaTransform.position.x - spawnAreaTransform.localScale.x/2,
            spawnAreaTransform.position.y - spawnAreaTransform.localScale.y/2,
            spawnAreaTransform.localScale.x,
            spawnAreaTransform.localScale.y
        );

        GenerateStars();
	}

    public void changeToNight()
    {
        if (!isDay)
        {
            return;
        }

        isDay = false;
        Invoke("ShowStars", 5);
    }

    public void changeToDay()
    {
        if (isDay)
        {
            return;
        }

        isDay = true;

        foreach(GameObject star in instantiatedStars)
        {
            StarSparkle starSparkle = star.GetComponent<StarSparkle>();
            starSparkle.FadeOut();

            Invoke("ResetStars", 5f);
        }
    }

    private void ShowStars()
    {
        foreach(GameObject star in instantiatedStars)
        {
            star.GetComponent<Renderer>().enabled = true;
            StarSparkle starSparkle = star.GetComponent<StarSparkle>();
            starSparkle.Show();
            starSparkle.FadeIn();
        }
    }

    private void GenerateStars()
    {
        instantiatedStars = new List<GameObject>();

        for (int i=0;i<numberOfPrefabs;i++)
        {
            GameObject starObject = Instantiate(
                starTypes[Random.Range(0,starTypes.Count)]
            );

            ResetStar(starObject);

            instantiatedStars.Add(
                starObject
            );
        }
    }

    private void ResetStars()
    {
        foreach(GameObject curStar in instantiatedStars)
        {
            ResetStar(curStar);
        }
    }

    private void ResetStar(GameObject star)
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
            zPosition
        );

        star.transform.localPosition = position;

        float scale = Random.Range(0.5f, 2.5f);
        star.transform.localScale = new Vector3(scale, scale, 1.0f);
        star.GetComponent<Renderer>().enabled = false;
    }
        
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderController : MonoBehaviour 
{
    public Camera mainCamera;
    public GameObject borderPrefab;

    [HideInInspector]
    public Bounds bounds;

    void Start()
    {
        float screenAspect = (float)Screen.width / (float)Screen.height;
        float cameraHeight = mainCamera.orthographicSize * 2;
        bounds = new Bounds(
            mainCamera.transform.position,
            new Vector3(cameraHeight * screenAspect, cameraHeight, 0)
        );

        Color randomColor = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);

        instantiateLeftBorder(bounds, randomColor);
        instantiateRightBorder(bounds, randomColor);
        instantiateBottomBorder(bounds, randomColor);
        instantiateTopBorder(bounds, randomColor);
    }

    private void instantiateLeftBorder(Bounds bounds, Color color)
    {
        Vector3 position = new Vector3(
            transform.position.x - bounds.extents.x,
            transform.position.y,
            transform.position.z
        );

        GameObject border = Instantiate(borderPrefab, position, Quaternion.Euler(0, 0, 90));

        border.GetComponent<Renderer>().material.color = color;
    }

    private void instantiateRightBorder(Bounds bounds, Color color)
    {
        Vector3 position = new Vector3(
            transform.position.x + bounds.extents.x,
            transform.position.y,
            transform.position.z
        );

        GameObject border = Instantiate(borderPrefab, position, Quaternion.Euler(0, 0, 90));

        border.GetComponent<Renderer>().material.color = color;
    }

    private void instantiateBottomBorder(Bounds bounds, Color color)
    {
        Vector3 position = new Vector3(
            transform.position.x,
            transform.position.y - bounds.extents.y,
            transform.position.z
        );

        GameObject border = Instantiate(borderPrefab, position, Quaternion.identity);

        border.GetComponent<Renderer>().material.color = color;
    }

    private void instantiateTopBorder(Bounds bounds, Color color)
    {
        Vector3 position = new Vector3(
            transform.position.x,
            transform.position.y + bounds.extents.y,
            transform.position.z
        );

        GameObject border = Instantiate(borderPrefab, position, Quaternion.identity);

        border.GetComponent<Renderer>().material.color = color;
    }
}

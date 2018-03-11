using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuClick : MonoBehaviour 
{
    public Button startGameButton;

	void Start () 
    {
        startGameButton.onClick.AddListener(StartGame);
	}

    void Update () 
    {
        #if UNITY_IOS || UNITY_ANDROID

        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            Application.Quit();
            return;
        }

        #endif
    }


    void StartGame()
    {
        SceneManager.LoadScene("jungle-game", LoadSceneMode.Single);
    }
}

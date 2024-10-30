using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    private GameManager gameManager;


    // Start is called before the first frame update
    void Start()
    {

    }

    public void StartClick()
    {
        SceneManager.LoadScene(sceneName: "Game Scene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

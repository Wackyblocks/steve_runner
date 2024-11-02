using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour
{
    private GameManager gameManager;

    //button defs
    public Button easyModeButton;
    public Button mediumModeButton;
    public Button hardModeButton;
    public GameObject levelUnlock;

    // Start is called before the first frame update
    void Start()
    {
        int topScore = PlayerPrefs.GetInt("TopScore", 0);

        

        // check scores to unlock difficulties
        if (topScore >= 10) //unlock hardcore button
        {
            levelUnlock.gameObject.SetActive(false);
            hardModeButton.interactable = true;
            
        }
        else
        {
            hardModeButton.interactable = false;
            levelUnlock.gameObject.SetActive(true);
        }


        //reset score debug (uncomment)
        //PlayerPrefs.DeleteKey("TopScore");

        DisplayTopScore();
    }

    public void StartClick()
    {
        SceneManager.LoadScene(sceneName: "Game Scene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }


    //score check
    void DisplayTopScore()
{
    int topScore = PlayerPrefs.GetInt("TopScore", 0);
    Debug.Log("Top Score: " + topScore);
}
}

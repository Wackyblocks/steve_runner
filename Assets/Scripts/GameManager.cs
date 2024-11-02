using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    //UI
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI scoreText2;
    public TextMeshProUGUI scoreTextTop;
    public TextMeshProUGUI healthGUI;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public Button menuButton;

    public int score;
    public bool isGameActive;
    public PlayerController playerController;

    void Start()
    {
        //ui prep
        gameOverText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
        menuButton.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(false);
        scoreText2.gameObject.SetActive(true);
        scoreTextTop.gameObject.SetActive(false);
        healthGUI.gameObject.SetActive(true);

        //update health
        int health = playerController.health;
        healthGUI.text = "Health: " + health;

        //ref controller
        playerController = FindObjectOfType<PlayerController>();
    }


    // Update is called once per frame
    public void GameOver()
    {
        //display game over text
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        menuButton.gameObject.SetActive(true);
        scoreText.gameObject.SetActive(true);
        scoreText2.gameObject.SetActive(false);
        scoreTextTop.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    public void GoToMainMenu()
    {
        SceneManager.LoadScene(sceneName: "Title");
    }

    public void UpdateScore(int scoreToAdd)
    {

        score += scoreToAdd;

        //display score in UI
        scoreText.text = "You scored " + score + " points!";
        scoreText2.text = "Score " + score;
        

        //fetch top score
        int topScore = PlayerPrefs.GetInt("TopScore", 0);

        //save score in p.prefab if only top score
        if (score > topScore)
        {
            PlayerPrefs.SetInt("TopScore", score);
            PlayerPrefs.Save();
            Debug.Log("New top score: " + score);
        }
        //display top score
        scoreTextTop.text = "Top score: " + topScore;

        //display health
        int health = playerController.health;
        healthGUI.text = "Health: " + health;
    }

    public void StartGame()
    {
        //scoresetup
        isGameActive = true;
        score = 0;

        //ui prep
        gameOverText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);

        //refresh score
        UpdateScore(0);
    }

}

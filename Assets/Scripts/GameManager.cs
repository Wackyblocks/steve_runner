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
    public TextMeshProUGUI healthGUI;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public Button menuButton;

    public int score;
    public bool isGameActive;
    public PlayerController playerController;

    void Start()
    {
        gameOverText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
        menuButton.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(false);
        scoreText2.gameObject.SetActive(true);
        healthGUI.gameObject.SetActive(true);


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
        scoreText.text = "You scored " + score + " points!";
        scoreText2.text = "Score " + score;

        //display health
        int health = playerController.health;
        healthGUI.text = "Health: " + health;
    }

    public void StartGame()
    {
        //scoresetup
        isGameActive = true;
        score = 0;

        gameOverText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);


        UpdateScore(0);
    }

}

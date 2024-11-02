using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft: MonoBehaviour
{
    private float speed = 30;
    private float leftBound = -15;
    private float scoreBound = 0;
    private PlayerController playerControllerScript;
    private GameManager gameManager;

    private bool scoreUpdated = false;

    // Start is called before the first frame update
    void Start()
    {
        GameObject gameManagerObject = GameObject.Find("Game Manager");
        if (gameManagerObject != null)
        {
            gameManager = gameManagerObject.GetComponent<GameManager>();
        }

        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    { 
        if (playerControllerScript.gameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime* speed);
        }

        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }

        //add score when surpassing obstacle
        if (transform.position.x < scoreBound && gameObject.CompareTag("Obstacle") && !scoreUpdated)
        {
            gameManager.UpdateScore(1);
            scoreUpdated = true;
        }
    }
}

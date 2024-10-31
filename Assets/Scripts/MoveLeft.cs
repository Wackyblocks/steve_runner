using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft: MonoBehaviour
{
    private float speed = 30;
    private float leftBound = -15;
    private float scoreBound = 0;
    private PlayerController playerControllerScript;
    //private GameManager gameManager;



    // Start is called before the first frame update
    void Start()
    {
        //gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
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

        //add score
        else if (transform.position.x < scoreBound && gameObject.CompareTag("Obstacle"))
        {
            //gameManager.UpdateScore(1);
        }
    }
}

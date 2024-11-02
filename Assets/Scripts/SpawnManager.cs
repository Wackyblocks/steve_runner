using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private Vector3 spawnPos = new Vector3 (25, 0, 0);
    private PlayerController playerControllerScript;
    public DifficultyButton difficultyButton;

    private float startDelay = 2;

    private float minSpawnDelay = 2;
    private float maxSpawnDelay = 3;

    //obstacle pools for difficulties
    public GameObject[] easyObstacles;
    public GameObject[] mediumObstacles;
    public GameObject[] hardObstacles;

    //difficulty

    public static GameManager Instance { get; private set; }
    public string difficulty { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        //corotutine for spawn delay (seen in UI tutorial)
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        StartCoroutine(SpawnObstacle());

        //default difficulty
        difficulty = PlayerPrefs.GetString("Difficulty", "Easy");
        SetGameDifficulty(difficulty);
    }

    //random timer spawner
    IEnumerator SpawnObstacle()
    {
        yield return new WaitForSeconds(startDelay); //wait start delay

        while (!playerControllerScript.gameOver)
        {
            float spawnDelay = Random.Range(minSpawnDelay, maxSpawnDelay); //delay range
            yield return new WaitForSeconds(spawnDelay);

            //randomize spawn
            GameObject[] currentObstacles = ObstacleDifficulty();
            int prefabIndex = Random.Range(0, currentObstacles.Length);
            Instantiate(currentObstacles[prefabIndex], spawnPos, currentObstacles[prefabIndex].transform.rotation);
        }
    }

    void SetGameDifficulty(string difficulty)
    {
        switch (difficulty) //sets settings for various difficulties
        {
            case "Easy":

                minSpawnDelay = 2;
                maxSpawnDelay = 3;
                break;
            case "Medium":

                minSpawnDelay = 1.3f;
                maxSpawnDelay = 2;
                break;
            case "Hard":

                minSpawnDelay = 1;
                maxSpawnDelay = 1.6f;
                break;
        }
    }

    GameObject[] ObstacleDifficulty() //obstacle pools
    {
        switch (difficulty)
        {
            case "Medium":
                return mediumObstacles;
            case "Hard":
                return hardObstacles;
            case "Easy":
            default:
                return easyObstacles;
        }
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float jumpForce;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool gameOver = false;

    private GameManager gameManager;

    //particles
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;

    //anim
    private Animator playerAnim;

    //sound
    public AudioClip jumpSound;
    public AudioClip crashSound;
    public AudioClip steveHit;
    public AudioClip steveDeath;
    public AudioClip metalHit;
    private AudioSource playerAudio;

    //health
    public int health;
    public DifficultyButton difficultyButton;

    //difficulty

    public static GameManager Instance { get; private set; }
    public string difficulty { get; private set; }

    void Awake()
    {
        //gravity fix
        Physics.gravity = new Vector3(0, -20f, 0);
    }


    // Start is called before the first frame update
    void Start()
    {
        //default difficulty
        difficulty = PlayerPrefs.GetString("Difficulty", "Easy");
        SetGameDifficulty(difficulty);

        //player prep
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();

        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();

        //checks if gamemanager exists
        if (SceneManager.GetActiveScene().name == "Game Scene")
        { 
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        }
    }

    void SetGameDifficulty(string difficulty)
    {
        switch (difficulty) //sets settings for various difficulties
        {
            case "Easy":

                health = 3;
                break;
            case "Medium":

                health = 2;
                break;
            case "Hard":

                health = 1;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }
    }

    //collision
    private void OnCollisionEnter(Collision collision)
    {
        isOnGround = true;

        //checks ground collision for particles
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtParticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            //triggers for collision (hit)
            health --;
            Destroy(collision.gameObject);
            explosionParticle.Play();
            gameManager.UpdateScore(0);
            playerAudio.PlayOneShot(steveHit, 1.0f);
            playerAudio.PlayOneShot(crashSound, 0.7f);
            playerAudio.PlayOneShot(steveDeath, 1.0f);

            //check (death)
            if (health < 1)
            {
                PlayerGameOver();
                gameManager.GameOver();
            }
        }
    }

    void PlayerGameOver() 
    {
        //game over bool for detection
        gameOver = true;
        Debug.Log("Game Over");
        
        //set death anim
        playerAnim.SetInteger("DeathType_int", 1);
        playerAnim.SetBool("Death_b", true);

        //stop particles
        dirtParticle.Stop();
        playerAudio.PlayOneShot(crashSound, 1.0f);
        playerAudio.PlayOneShot(steveDeath, 1.0f);
        playerAudio.PlayOneShot(metalHit, 1.0f);

    }
}

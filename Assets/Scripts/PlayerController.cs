using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private AudioSource playerAudio;

    //health
    public int health;

    // Start is called before the first frame update
    void Start()
    {
        //setup health
        health = 3;
        //health == DifficultyButton;


        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();

        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();

        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    //gravity fix
    void Awake()
    {
        Physics.gravity = new Vector3(0, -20f, 0);
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

        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtParticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            //triggers for collision
            health --;
            Destroy(collision.gameObject);
            explosionParticle.Play();
            gameManager.UpdateScore(0);


            //check
            if (health < 1)
            {
                PlayerGameOver();
                gameManager.GameOver();
            }
        }
    }

    void PlayerGameOver() 
    {
        gameOver = true;
        Debug.Log("Game Over");
        playerAnim.SetBool("Death_b", true);
        playerAnim.SetInteger("DeathType_int", 1);
        
        dirtParticle.Stop();
        playerAudio.PlayOneShot(crashSound, 1.0f);
        
    }
}

using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour {

    public float acceleration = 10;
    public float speed;
    public globalTiles gameManager;
    

    public float bounceDuration;
    public float peakHeight = 2f;
    private float initialSpeed;
    private float calculatedGravity;

    // How many times the doubleTile has been bounced on. 0 is not bounced on, 1 is mid note playing, and 2 means it's over.
    private float doubleTileCount;
    private float wholeTileCount; // 0 is not bounced, 1 is mid play, 2 is mid play, 3 is mid play, 4 is complete

    public AudioSource wrongTileNoise;

    public GameObject loseMenuUI;

    public GameObject floor;

    float baseVal;

    bool hasRestart;




    private Rigidbody rb;

    void Start ()
    {
        //Ball movement variables
        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(0, -10, 0);
        calculatedGravity = (2 * peakHeight) / Mathf.Pow((bounceDuration / 2), 2);
        Physics.gravity = new Vector3(0f, -calculatedGravity, 0f);
        initialSpeed = Mathf.Sqrt(2 * Mathf.Abs(Physics.gravity.y) * peakHeight);
        rb.velocity = new Vector3(0f, initialSpeed, 0f);

        //Tile manager
        gameManager = FindObjectOfType<globalTiles>();
        doubleTileCount = 0;
        wholeTileCount = 0;

        baseVal = floor.transform.position.y - 5;

        Time.timeScale = 1f;
        hasRestart = false;
        //gameStart = true;
        

    }

    void Update ()
    {
        //Get key input

        float horizontalInput = Input.GetAxis ("Horizontal");
        float verticalInput = Input.GetAxis ("Vertical");

        //Move ball
        Vector3 newVelocity = rb.velocity;
        newVelocity.x = horizontalInput * speed;
        newVelocity.z = verticalInput * speed;
        rb.velocity = newVelocity;

        //if the ball is lower than certain y position, end game
        if (transform.position.y < baseVal)
        {
            Restart();
            hasRestart = true;

        }
      
    }

    void OnCollisionEnter(Collision collision)
    {
        //Movement

        // Calculate the new velocity after the bounce
        Vector3 newVelocity = Vector3.Reflect(rb.velocity, collision.contacts[0].normal);

        // Set the y-component of the new velocity to the initial speed (maintaining constant bounce height)
        newVelocity.y = initialSpeed;

        // Apply the new velocity to the Rigidbody
        rb.velocity = newVelocity;

        //Gameplay and tiles
        thisTile tileScript = collision.gameObject.GetComponent<thisTile>();
        if (tileScript != null)
        {
            gameManager.currentTile = tileScript;
            if (tileScript == gameManager.correctTile && !gameManager.isGameOver)
            {
                // We just bounced on a normal tile.
                if (!tileScript.isDoubleNote && !tileScript.isWholeNote)
                {
                    tileScript.Play();
                    gameManager.AdvanceSequence();
                }
                // We just bounced on a whole note/ double note tile
                else
                {
                    if (tileScript.isDoubleNote)
                    {
                        // Increase the number of bounces that the ball has been on this tile
                        doubleTileCount++;
                        // If this is the first bounce, play the sound
                        if (doubleTileCount == 1)
                        {
                            tileScript.Play();
 
                        }
                        // If this is the second bounce, do not play anymore sound, and advance the sequence.
                        else
                        {
                            gameManager.AdvanceSequence();
                            doubleTileCount = 0;
                        }
                    }

                    if (tileScript.isWholeNote)
                    {
                        wholeTileCount++;
                        if (wholeTileCount == 1)
                        {
                            tileScript.Play();
                        }
                        if(wholeTileCount == 4)
                        {
                            gameManager.AdvanceSequence();
                            wholeTileCount = 0;
                        }
                    }
                    
                }
                

            }
            // Bounced on the wrong tile
            else if (tileScript != gameManager.correctTile)
            {
                Restart();
            }

        }
    }

    void Restart()
    {
        if (!hasRestart)
        {
            wrongTileNoise.Play();
        }
        
        Time.timeScale = 0f; // Stop time
        loseMenuUI.SetActive(true);
    }
}
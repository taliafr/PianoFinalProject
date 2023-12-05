using UnityEngine;
using System.Collections;
using UnityEditor.Build.Content;
using System;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour {

    public float acceleration = 10;
    public float speed;
    public globalTiles gameManager;
    

    public float bounceDuration = 0.25f;
    public float peakHeight = 2f;
    private float initialSpeed;
    private float calculatedGravity;

    // How many times the doubleTile has been bounced on. 0 is not bounced on, 1 is mid note playing, and 2 means it's over.
    private float doubleTileCount;

    public AudioSource wrongTileNoise;

    public GameObject loseMenuUI;

    //private bool gameStart;




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
        DoubleNoteTile doubleTileScript = collision.gameObject.GetComponent<DoubleNoteTile>();
        if (tileScript != null)
        {
            gameManager.currentTile = tileScript;
            if (tileScript == gameManager.correctTile && !gameManager.isGameOver)
            {
                tileScript.Play();
                gameManager.AdvanceSequence();

            }
            // Bounced on the wrong tile
            else if (tileScript != gameManager.correctTile)
            {
                wrongTileNoise.Play();
                Time.timeScale = 0f; // Stop time
                loseMenuUI.SetActive(true);
            }

        }
        // We just bounced on a whole note/ double note tile
        else if (doubleTileScript != null) {
            gameManager.currentTile = doubleTileScript;
            if (doubleTileScript == gameManager.correctTile && !gameManager.isGameOver)
            {
                // Increase the number of bounces that the ball has been on this tile
                doubleTileCount++;
                // If this is the first bounce, play the sound
                if (doubleTileCount == 1)
                {
                    doubleTileScript.Play();
                }
                // If this is the second bounce, do not play anymore sound, and advance the sequence.
                else { 
                    gameManager.AdvanceSequence();
                    doubleTileCount = 0;
                }
                

            }
            // Bounced on the wrong tile
            else if (doubleTileScript != gameManager.correctTile)
            {
                wrongTileNoise.Play();
                Time.timeScale = 0f; // Stop time
                loseMenuUI.SetActive(true);
            }
        }
    }

    /*void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.GetComponent<thisTile>() != null)
        {
            // Call the Glow method on the Tile script directly
            thisTile tileScript = collision.gameObject.GetComponent<thisTile>();
            if (tileScript != null)
            {
                tileScript.stopGlow();
                
            }
        }
    }
    */
}
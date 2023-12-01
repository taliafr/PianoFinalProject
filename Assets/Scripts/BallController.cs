﻿using UnityEngine;
using System.Collections;
using UnityEditor.Build.Content;
using System;

public class BallController : MonoBehaviour {

    public float acceleration = 10;
    public float speed;
    public globalTiles gameManager;
    

    public float bounceDuration = 0.25f;
    public float peakHeight = 2f;
    private float initialSpeed;
    private float calculatedGravity;

    private bool gameStart;
    private bool gameEnd;

    private bool stopGlow;
    public float glowTimerBounceVal;
    private float glowTimerBounce;




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
        gameEnd = false;
        gameStart = false;
        

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

        //If the currentTile = the nextTile --> start the game
        if (collision.gameObject.GetComponent<thisTile>() != null)
        {
            gameManager.currentTile = collision.gameObject.GetComponent<thisTile>();
            if(gameManager.currentTile == gameManager.nextTile)
            {
                gameStart = true;

            }
        }


            if (gameStart)

        {
            if (collision.gameObject.GetComponent<thisTile>() != null)
            {
                /*if (collision.gameObject.GetComponent<thisTile>() == gameManager.correctTile) {
                    gameManager.AdvanceSequence();
                    gameManager.currentTile = collision.gameObject.GetComponent<thisTile>();

                }*/

                //What tile the ball hit

                thisTile tileScript = collision.gameObject.GetComponent<thisTile>();

                if (tileScript != null)
                {
                    //Tile glows and plays
                    tileScript.Glow();
                    tileScript.Play();
                }

            }
        }
    }

    void OnCollisionExit(Collision collision)
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
}
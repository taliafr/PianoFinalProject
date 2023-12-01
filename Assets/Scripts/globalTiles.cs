using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class globalTiles : MonoBehaviour
{

    // want to change so that correct tile and next tile is iterating based on player collision

    public Tile currentTile; //handled by player --> on collision tile becomes currentTile, turn off glow on old currentTile, turn off sound on old currentTile

    public Tile correctTile; 
    public Tile nextTile; 

    public Tile[] sequence;
    public int nextSeqIndex;

    //public float timer = 100;


    //public float timer; //how much time (seconds) before next note, want to change so that correct tile and next tile is iterating based on player collision

    //int correctCounter;
    //int nextCounter;
    public bool endGame;


    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // Called once at the beginning, only to make sure all other variables have been assigned first.
        if (correctTile == null)
        {
            // Starts the sequence by making the first tile glow
            correctTile = sequence[0];
            nextTile = sequence[1];
            nextSeqIndex = 1;
            correctTile.Glow();
        }
        
    }


    //Called by player 

    public void AdvanceSequence() {
        // Deactivates the tile that has just been correctly bounced on
        correctTile.stopGlow();
        // Activates the next tile in the sequence
        correctTile = nextTile;
        correctTile.Glow();
        nextSeqIndex++;
        nextTile = sequence[nextSeqIndex];
    }
}

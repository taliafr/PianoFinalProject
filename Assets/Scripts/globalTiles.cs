using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class globalTiles : MonoBehaviour
{

    // want to change so that correct tile and next tile is iterating based on player collision

    public Tile currentTile; //handled by player --> on collision tile becomes currentTile, turn off glow on old currentTile, turn off sound on old currentTile

    private Tile correctTile; 
    public Tile nextTile; 

    public Tile[] sequence;
    public int nextSeqIndex;

    public float timer = 100;


    //public float timer; //how much time (seconds) before next note, want to change so that correct tile and next tile is iterating based on player collision

    int correctCounter;
    int nextCounter;
    public bool endGame;


    void Start()
    {
        nextCounter = 0;
        nextTile = sequence[nextCounter];
        nextTile.Glow();

    }

    /*void Update()
    {
        if (correctTile == null) {

            correctTile = sequence[0];
            nextTile = sequence[1];
            nextSeqIndex = 1;
            correctTile.Glow();
        }

    }*/

    // Update is called once per frame

    void Update()
    {
        /*timer -= Time.deltaTime;
        if (timer <= 0) {
            correctCounter++;
            nextCounter++;
        }*/
        if (correctTile == null)
        {

            correctTile = sequence[0];
            nextTile = sequence[1];
            nextSeqIndex = 1;
            correctTile.Glow();
        }

        if (sequence.Length<nextCounter)
        {

            correctTile = sequence[correctCounter];
            endGame = true;
        }
        else
        {
            correctTile = sequence[correctCounter];
            nextTile = sequence[nextCounter];
        }

        nextTile.Glow();
        
    }


    //Called by player 

    public void AdvanceSequence() {
        correctTile.stopGlow();
        correctTile = nextTile;
        correctTile.Glow();
        nextSeqIndex++;
        nextTile = sequence[nextSeqIndex];
    }
}

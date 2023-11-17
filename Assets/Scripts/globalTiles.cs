using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class globalTiles : MonoBehaviour
{
    public Tile currentTile; //handled by player --> on collision tile becomes currentTile, turn off glow on old currentTile, turn off sound on old currentTile

    public Tile correctTile; 
    public Tile nextTile; 

    public Tile[] sequence;
    public float timer; //how much time (seconds) before next note

    int correctCounter;
    int nextCounter;
    public bool endGame;
    void Start()
    {
        correctCounter = 0;
        nextCounter = 1;

        correctTile = sequence[0];
        nextTile = sequence[1];

        correctTile.Glow();
        nextTile.Glow();

        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0) {
            correctCounter++;
            nextCounter++;
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
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class globalTiles : MonoBehaviour
{

    public Tile currentTile;
    public GameObject winMenuUI;

    // The index of the tile that should be glowing (i.e. is next in the sequence)
    int curSeqIndex;

    // The tile that should be glowing (i.e. is next in the sequence)
    public Tile correctTile; 

    // The sequence of tiles that make up the song
    public Tile[] sequence;

    // Whether or not the final tile has been reached
    public bool isGameOver;

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
            curSeqIndex = 0;
            correctTile = sequence[curSeqIndex];
            correctTile.Glow();
        }
        
    }


    //Called by player 
    public void AdvanceSequence() {
        // Deactivates the tile that has just been correctly bounced on
        if (curSeqIndex + 1 < sequence.Length && !correctTile.Equals(sequence[curSeqIndex+1])) {
            Debug.Log("Keep current tile");
            correctTile.stopGlow();
        }
        // Activates the next tile in the sequence
        curSeqIndex++;
        if (curSeqIndex < sequence.Length)
        {
            correctTile = sequence[curSeqIndex];
            correctTile.Glow();
        }
        else {
            if (!isGameOver) {
                EndGame();
            }
            isGameOver = true;
            
        }

    }

    // Ends the game, for example, by bringing up a 'Congrats' screen and redirecting to level selection
    void EndGame() {
        Time.timeScale = 0f; // Stop time
        winMenuUI.SetActive(true);
    }
}

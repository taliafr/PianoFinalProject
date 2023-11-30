using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//correct tile and next tile changed by global tiles, need to change so that it changes based on player collision 
//nextTile also changed by timer script -- iterates through same public array of tile objects + 1
    //if nextTile = thisTile
        //Tile.Start() -- light up color

//if currTile != corrTile
    //terminate game

//Tile has glow and no glow functions, play and stop play functions

//Need player to call 


public class thisTile : Tile
{

    private AudioSource thisNote;

    public Color thisColor;

    Color oldColor;
    Renderer rend;

    public bool play;
    public bool glow;

    public override void Play()
    {
        thisNote = GetComponent<AudioSource>();
        thisNote.Play();
        play = true;
    }

    public override void Glow()
    {
        rend.material.color = thisColor;
        glow = true;
    }

    public override void stopGlow()
    {
        rend.material.color = oldColor;
        glow = false;

    }

    public override void stopPlay()
    {
        thisNote.Stop();
        play = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        play = false;
        glow = false;

        //Set color and get rendere
     
        rend = GetComponent<Renderer>();
        thisNote = GetComponent<AudioSource>();
        oldColor = rend.material.color;
        float factor = 8;
        thisColor = oldColor * factor;

    }

    // Update is called once per frame
    void Update()
    {

        /*if (play == true)
        {
         thisNote.Play();
        }*/
    }
}

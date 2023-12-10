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
    public AudioSource chord;
    public AudioSource note;

    public Color thisColor;

    Color oldColor;
    Renderer rend;

    private float glowItensity;

    public bool play;
    public bool glow;

    public bool isDoubleNote;
    public bool isWholeNote;
    public bool isChord;

    public override void Play()
    {

        if (isChord)
        {
            note.Play();
            chord.Play();

        }
        else
        {
            note.Play();
        }
        play = true; //why do you change the boolean and call the void method
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
        note.Stop();
        play = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        play = false;
        glow = false;
        //Set color and get rendere
     
        rend = GetComponent<Renderer>();
        note = gameObject.GetComponent<AudioSource>();
        chord = gameObject.GetComponent<AudioSource>();

        oldColor = rend.material.color;
        glowItensity = 35;
        thisColor = oldColor * glowItensity;

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

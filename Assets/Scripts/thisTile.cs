using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Need currTile and corrTile globally accesible variables
//corrTile changed by timer script -- Iterates through public array of tile objects
//nextTile also changed by timer script -- iterates through same public array of tile objects + 1
    //if nextTile = thisTile
        //Tile.Start() -- light up color

//if currTile != corrTile
    //terminate game


public class thisTile : Tile
{

    public AudioSource thisNote;
    public Color thisColor;

    Color oldColor;
    Renderer rend;

    public bool play;

    public override void Play()
    {
        play = true;
    }

    public override void Glow()
    {
        rend.material.color = thisColor;
    }

    public override void stopGlow()
    {
        rend.material.color = oldColor;

    }

    public override void stopPlay()
    {
       play = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        play = false;

        //Set color and get rendere
        rend = GetComponent<Renderer>();
        oldColor = rend.material.color;

    }

    // Update is called once per frame
    void Update()
    {

        if (play)
        {
            thisNote.Play();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Abstract class
//Sound
//Color

public abstract class Tile : MonoBehaviour
{
    public abstract void Glow();
    public abstract void Play();
    public abstract void stopPlay();
    public abstract void stopGlow();
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenManager : MonoBehaviour
{

    // Name of the game scene to load
    public string gameSceneName = "SerafinaScene1";

    // Method to be called when the "Start" button is clicked
    public void StartGame()
    {
        SceneManager.LoadScene(gameSceneName);
    }
}

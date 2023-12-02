using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                Resume();
            else
                Pause();
        }
    }

    public void Resume()
    {
        Time.timeScale = 1f; // Resume normal time scale
        pauseMenuUI.SetActive(false);
        isPaused = false;
    }

    public void Pause()
    {
        Time.timeScale = 0f; // Stop time
        pauseMenuUI.SetActive(true);
        isPaused = true;
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f; // Resume normal time scale before reloading the scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ReturnToMainMenu()
    {
        Time.timeScale = 1f; // Resume normal time scale before loading the main menu scene
        SceneManager.LoadScene("LevelSelection"); 
    }
}

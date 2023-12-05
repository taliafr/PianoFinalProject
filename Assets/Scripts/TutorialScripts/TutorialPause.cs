using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialPause : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject instructionsUI;
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
        instructionsUI.SetActive(true);
        pauseMenuUI.SetActive(false);
        isPaused = false;
    }

    public void Pause()
    {
        Time.timeScale = 0f; // Stop time
        instructionsUI.SetActive(false);
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

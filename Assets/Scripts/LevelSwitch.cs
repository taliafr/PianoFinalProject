using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSwitch : MonoBehaviour
{
    public Dropdown dropdown;

    public void ChangeScene(string sceneName)
    {
        GameObject dropdownObject = GameObject.Find("DifficultyDropdown");

        string selectedDifficulty = "Easy";

        if (dropdownObject != null)
        {
            // Get the Dropdown component from the GameObject
            dropdown = dropdownObject.GetComponent<Dropdown>();

            // Check if the Dropdown component is found
            if (dropdown != null)
            {
                int selectedIndex = dropdown.value;
                selectedDifficulty = dropdown.options[selectedIndex].text;
            }
        }
        Debug.Log(selectedDifficulty);
        
        SceneManager.LoadScene(sceneName + selectedDifficulty);
        SceneManager.LoadScene(sceneName);
    }
}

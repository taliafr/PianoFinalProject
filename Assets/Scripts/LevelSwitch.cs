using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSwitch : MonoBehaviour
{
    public TMP_Dropdown dropdown;

    public void ChangeScene(string sceneName)
    {
        string selectedDifficulty = "";

        int selectedValue = dropdown.value;
        selectedDifficulty = dropdown.options[selectedValue].text;
        
        SceneManager.LoadScene(sceneName + selectedDifficulty);
    }
}

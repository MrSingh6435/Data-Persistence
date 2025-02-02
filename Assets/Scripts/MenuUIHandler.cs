using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using TMPro;

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField nameInputField;
    private string playerName;
    private void Start()
    {
        // Optional: Check if the input field is assigned
        if (nameInputField == null)
        {
            Debug.LogError("TMP_InputField is not assigned in the Inspector!");
        }
    }

    // Starting game when Player clicks on the Start Button
    public void StartNew()
    {
        playerName = nameInputField.text; 

        if (!string.IsNullOrEmpty(playerName))
        {
            // Store player name in PlayerPrefs to pass it between scenes
            PlayerPrefs.SetString("PlayerName", playerName);
            PlayerPrefs.Save(); // Ensure the name is saved

            // Load the main game scene
            SceneManager.LoadScene(1);
        }
        else
        {
            Debug.LogWarning("Player name is empty! Please enter a name.");
        }
    }



    // Quitting the game when player clicks on the Quit button
    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // Original code to quit Unity player
#endif
    }
}

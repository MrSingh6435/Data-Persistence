using System;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField nameInputField;
    public TextMeshProUGUI BestScoreText;
    private MainManager mainManager;
    private string bestPlayerName;
    private int bestScore;

    private void Start()
    {
        if (nameInputField == null)
        {
            Debug.LogError("TMP_InputField is not assigned in the Inspector!");
        }

        LoadPlayerData();
    }

    public void StartNew()
    {
        string playerName = nameInputField.text;

        if (!string.IsNullOrEmpty(playerName))
        {
            PlayerPrefs.SetString("PlayerName", playerName);
            PlayerPrefs.Save();
            SceneManager.LoadScene(1);
        }
        else
        {
            Debug.LogWarning("Player name is empty! Please enter a name.");
        }
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void LoadPlayerData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestPlayerName = data.playerName;
            bestScore = data.bestScore;
            BestScoreText.text = $"Best Score : {bestPlayerName} : {bestScore}";
        }
        else
        {
            bestPlayerName = "None";
            bestScore = 0;
            BestScoreText.text = $"Best Score : {bestPlayerName} : {bestScore}";
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class MainManager : MonoBehaviour
{
    public Brick BrickPrefab;
    public int LineCount = 6;
    public Rigidbody Ball;

    public Text ScoreText;
    public Text BestScore;
    public GameObject GameOverText;

    private bool m_Started = false;
    private int m_Points;

    private bool m_GameOver = false;
    private string currentPlayerName;
    private int bestScore;
    private string bestPlayerName;

    private void Start()
    {
        const float step = 0.6f;
        int perLine = Mathf.FloorToInt(4.0f / step);

        int[] pointCountArray = new[] { 1, 1, 2, 2, 5, 5 };
        for (int i = 0; i < LineCount; ++i)
        {
            for (int x = 0; x < perLine; ++x)
            {
                Vector3 position = new Vector3(-1.5f + step * x, 2.5f + i * 0.3f, 0);
                var brick = Instantiate(BrickPrefab, position, Quaternion.identity);
                brick.PointValue = pointCountArray[i];
                brick.onDestroyed.AddListener(AddPoint);
            }
        }

        currentPlayerName = PlayerPrefs.GetString("PlayerName", "Player");
        LoadPlayerData();
        UpdateBestScoreUI();
    }

    void DeleteJson()
    {
        string filePath = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
            Debug.Log("File deleted successfully.");
        }
        else
        {
            Debug.Log("File not found.");
        }
    }
    void Exit(){
        SceneManager.LoadScene(0);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F9))
        {
            DeleteJson();
        }

        if (Input.GetKeyDown(KeyCode.Escape)){
            Exit();
        }

        if (!m_Started)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_Started = true;
                float randomDirection = Random.Range(-1.0f, 1.0f);
                Vector3 forceDir = new Vector3(randomDirection, 1, 0);
                forceDir.Normalize();

                Ball.transform.SetParent(null);
                Ball.AddForce(forceDir * 2.0f, ForceMode.VelocityChange);
            }
        }
        else if (m_GameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    void AddPoint(int point)
    {
        m_Points += point;
        ScoreText.text = $"Score : {currentPlayerName} : {m_Points}";
    }

    public void GameOver()
    {
        m_GameOver = true;
        GameOverText.SetActive(true);

        if (m_Points > bestScore)
        {
            bestScore = m_Points;
            bestPlayerName = currentPlayerName;
            SavePlayerData();
        }

        UpdateBestScoreUI();
    }

    private void UpdateBestScoreUI()
    {
        BestScore.text = $"Best Score: {bestPlayerName} : {bestScore}";
    }

    [System.Serializable]
    public class SaveData
    {
        public string playerName;
        public int bestScore;
    }

    public void SavePlayerData()
    {
        SaveData data = new SaveData
        {
            playerName = bestPlayerName,
            bestScore = bestScore
        };

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
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
        }
        else
        {
            bestPlayerName = "None";
            bestScore = 0;
        }
    }
}

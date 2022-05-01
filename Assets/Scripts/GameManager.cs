using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static GameManager instance;
    FirebaseHandler firebaseHandler;

    float newestTime = 0;
    string[] topFiveUsernames = new string[] { "One", "Two", "Three", "Four", "Five" };
    float[] topFiveBestTimes = new float[] { 120, 90, 80, 60, 0 };

    string username = "newmember";

    bool highScoreAchieved = false;

    private void Awake()
    {
        DontDestroyOnLoad(this);

        if(instance == null)
        {
            instance = this;
        } else
        {
            Destroy(gameObject);
        }

        firebaseHandler = gameObject.GetComponent<FirebaseHandler>();
    }

    private void Update()
    {
        if (firebaseHandler.AreThereNewHighScores())
        {
            UpdateScoresFromDatabase();
            firebaseHandler.CollectedNewHighScores();
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        UpdateScoresFromDatabase();

        if (scene.buildIndex == 1)
        {
            highScoreAchieved = false;
        }
    }

    private void UpdateScoresFromDatabase()
    {
        string[] newNames = firebaseHandler.GetNames();
        string[] newScores = firebaseHandler.GetScores();
        for (int i = 0; i < newScores.Length; i++)
        {
            if (newNames[i] != null && newScores[i] != null)
            {
                topFiveUsernames[i] = newNames[i];
                topFiveBestTimes[i] = float.Parse(newScores[i]);
            }
        }
    }

    public void EndGame()
    {
        newestTime = FindObjectOfType<GameTimer>().GetTime();
        CompareTimes();
        SceneManager.LoadScene(2);
    }

    private void CompareTimes()
    {
        float originalBestTime = 0;
        string originalUsername = null;
        for (int i=0; i<topFiveBestTimes.Length; i++)
        {
            if (highScoreAchieved)
            {
                string nameStorage = topFiveUsernames[i];
                topFiveUsernames[i] = originalUsername;
                originalUsername = nameStorage;

                float timeStorage = topFiveBestTimes[i];
                topFiveBestTimes[i] = originalBestTime;
                originalBestTime = timeStorage;
            }
            else
            {
                if (topFiveBestTimes[i] <= newestTime)
                {
                    originalUsername = topFiveUsernames[i];
                    topFiveUsernames[i] = username;

                    //New high score
                    originalBestTime = topFiveBestTimes[i];
                    topFiveBestTimes[i] = newestTime;
                    highScoreAchieved = true;
                }
            }
        }

        //Prepare high scores for database
        string[] newNames = new string[topFiveBestTimes.Length];
        string[] newHighScores = new string[topFiveBestTimes.Length];
        for(int i=0; i< newHighScores.Length; i++)
        {
            newNames[i] = topFiveUsernames[i];
            newHighScores[i] = topFiveBestTimes[i].ToString();
        }

        firebaseHandler.UploadData(newNames, newHighScores);
    }

    public float GetNewestTime()
    {
        return newestTime;
    }

    public string ConvertTimeToString(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        float seconds = time % 60;
        return (minutes.ToString("00") + ":" + seconds.ToString("00"));
    }

    public string[] GetBestNames()
    {
        return topFiveUsernames;
    }

    public float[] GetBestTimes()
    {
        return topFiveBestTimes;
    }

    public string GetUsername()
    {
        return username;
    }

    public void UpdateUsername(string newUsername)
    {
        username = newUsername;
    }

    public bool WasHighScoreAchieved()
    {
        return highScoreAchieved;
    }
}

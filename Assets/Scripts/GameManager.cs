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
    float[] topFiveBestTimes = new float[] { 120, 90, 80, 70, 60 };
    //TODO on startup, get the best times from a database.

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

        firebaseHandler = gameObject.AddComponent<FirebaseHandler>();
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if(scene.buildIndex == 1)
        {
            highScoreAchieved = false;
        }
    }

    void Update()
    {

    }

    public void EndGame()
    {
        newestTime = FindObjectOfType<GameTimer>().GetTime();
        CompareTimes();
        //TODO send high scores to database
        SceneManager.LoadScene(2);
    }

    private void CompareTimes()
    {
        float originalBestTime = 0;
        for (int i=0; i<topFiveBestTimes.Length; i++)
        {
            if (highScoreAchieved)
            {
                float timeStorage = topFiveBestTimes[i];
                topFiveBestTimes[i] = originalBestTime;
                originalBestTime = timeStorage;
            }
            else
            {
                if (topFiveBestTimes[i] <= newestTime)
                {
                    //New high score
                    originalBestTime = topFiveBestTimes[i];
                    topFiveBestTimes[i] = newestTime;
                    highScoreAchieved = true;
                }
            }
        }

        string[] newHighScores = new string[topFiveBestTimes.Length];
        for(int i=0; i< newHighScores.Length; i++)
        {
            newHighScores[i] = ConvertTimeToString(topFiveBestTimes[i]);
        }

        firebaseHandler.UploadData(newHighScores);
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

    public float[] GetBestTimes()
    {
        return topFiveBestTimes;
    }

    public bool WasHighScoreAchieved()
    {
        return highScoreAchieved;
    }
}

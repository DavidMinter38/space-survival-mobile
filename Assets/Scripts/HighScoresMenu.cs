using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HighScoresMenu : MonoBehaviour
{
    [SerializeField]
    Text[] bestNamesTexts;

    [SerializeField]
    Text[] bestTimesTexts;

    void Start()
    {
        string[] bestNames = FindObjectOfType<GameManager>().GetBestNames();
        float[] bestTimes = FindObjectOfType<GameManager>().GetBestTimes();
        for(int i=0; i<bestTimesTexts.Length; i++)
        {
            bestNamesTexts[i].text = bestNames[i];
            bestTimesTexts[i].text = FindObjectOfType<GameManager>().ConvertTimeToString(bestTimes[i]);
        }
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }
}

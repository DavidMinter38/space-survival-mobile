using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HighScoresMenu : MonoBehaviour
{
    [SerializeField]
    Text[] bestTimesTexts;

    void Start()
    {
        float[] bestTimes = FindObjectOfType<GameManager>().GetBestTimes();
        for(int i=0; i<bestTimesTexts.Length; i++)
        {
            bestTimesTexts[i].text = FindObjectOfType<GameManager>().ConvertTimeToString(bestTimes[i]);
        }
    }

    void Update()
    {
        
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }
}

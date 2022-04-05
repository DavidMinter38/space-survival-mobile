using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultsMenu : MonoBehaviour
{
    [SerializeField]
    Text resultText;

    [SerializeField]
    Text newHighScoreText;

    public void OnEnable()
    {
        float resultTime = FindObjectOfType<GameManager>().GetNewestTime();
        resultText.text = "Your time: " + FindObjectOfType<GameManager>().ConvertTimeToString(resultTime);
        newHighScoreText.gameObject.SetActive(FindObjectOfType<GameManager>().WasHighScoreAchieved());
    }

    public void Retry()
    {
        SceneManager.LoadScene(1);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }
}

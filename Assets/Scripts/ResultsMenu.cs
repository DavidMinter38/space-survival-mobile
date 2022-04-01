using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultsMenu : MonoBehaviour
{
    [SerializeField]
    Text resultText;

    public void OnEnable()
    {
        resultText.text = "Your time: " + FindObjectOfType<GameManager>().GetNewestTime();
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

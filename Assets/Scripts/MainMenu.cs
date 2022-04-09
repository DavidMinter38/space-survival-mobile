using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    Text usernameText;

    private void Awake()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;

        usernameText.text = "Username: " + FindObjectOfType<GameManager>().GetUsername();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void OpenSettingsMenu()
    {
        SceneManager.LoadScene(4);
    }

    public void OpenHighScoreMenu()
    {
        SceneManager.LoadScene(3);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Awake()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
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

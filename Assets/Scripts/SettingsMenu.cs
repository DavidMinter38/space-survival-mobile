using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField]
    InputField usernameInputField;

    public void ChangeUsername()
    {
        if (usernameInputField.text != "")
        {
            FindObjectOfType<GameManager>().UpdateUsername(usernameInputField.text);
        }
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }
}

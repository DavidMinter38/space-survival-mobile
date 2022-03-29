using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    float timer = 0;
    int minutes = 0;
    float seconds = 0;

    [SerializeField]
    Text timeText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        minutes = Mathf.FloorToInt(timer / 60);
        seconds = timer % 60;
        timeText.text = (minutes.ToString("00") + ":" + seconds.ToString("00"));
    }

    public void EndGame()
    {
        SceneManager.LoadScene(2);
    }
}

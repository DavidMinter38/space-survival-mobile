using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    float timer = 0;
    int minutes = 0;
    float seconds = 0;
    string currentTime;

    [SerializeField]
    Text timeText;


    void Update()
    {
        timer += Time.deltaTime;
        minutes = Mathf.FloorToInt(timer / 60);
        seconds = timer % 60;
        currentTime = (minutes.ToString("00") + ":" + seconds.ToString("00"));
        timeText.text = currentTime;
    }

    public float GetTime()
    {
        return timer;
    }
}

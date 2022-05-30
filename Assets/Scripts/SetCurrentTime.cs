using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class SetCurrentTime : MonoBehaviour
{
    [SerializeField] private GameController game;
    private TMP_Text text;

    public String time;

    private int seconds = 0, minutes = 0, hours = 0;

    private float TIME_DELAY = 1f;
    private float elapsed = 0f;

    private void Start()
    {
        text = GetComponent<TMP_Text>();

        time = "00:00:00";

        text.text = time;
    }

    private void Update()
    {
        if (!game.IsRunning()) return;

        elapsed += Time.deltaTime;
        
        if (elapsed >= TIME_DELAY)
        {
            elapsed = elapsed % TIME_DELAY;
            SetTime();
        }

        text.text = time;
    }

    private void SetTime()
    {
        seconds += 1;
        minutes += seconds / 60;
        hours += minutes / 60;

        seconds = seconds > 59 ? 0 : seconds;
        minutes = minutes > 59 ? 0 : minutes;

        time = GetFormatedTime(hours) + ":" + GetFormatedTime(minutes) + ":" + GetFormatedTime(seconds);
    }

    private String GetFormatedTime(int unformattedTime)
    {
        return unformattedTime < 10 ? "0" + unformattedTime : "" + unformattedTime;
    }

    public void ResetOnLose()
    {
        time = "00:00:00";
        text.text = time;
        seconds = 0;
        minutes = 0;
        hours = 0;
        elapsed = 0f;
    }
}

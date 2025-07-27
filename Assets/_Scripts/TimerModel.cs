using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerModel : MonoBehaviour
{
    public event Action TimerChanged;

    public event Action TimerReached;

    public  float maxTime = 10f;
    public float currentTime;

    private bool runTimer;


    public void StartTime()
    {
        runTimer = true;
    }

    public void StopTime()
    {
        runTimer = false;
    }

    public void ResetTime()
    {
        currentTime = 0;
    }

    

    public void Counting()
    {
        if (!runTimer) return;

        currentTime += Time.deltaTime;
        if (currentTime >= maxTime)
        {
            TimerReached?.Invoke();
        }
        else
        {
            TimerChanged?.Invoke();
        }
    }
}
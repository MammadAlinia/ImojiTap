using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class TimerPresenter : MonoBehaviour
{
    
    [SerializeField] private TimerModel timerModelModel;

    [SerializeField] private Image timerFillImg;


    public event Action onTimerReached;
    public event Action onTimerChanged;

    private void Start()
    {
        if (timerModelModel != null)
        {
            timerModelModel.TimerChanged += OnTimerChanged;
            timerModelModel.TimerReached += OnTimeReached;
        }

        UpdateView();
    }

    private void OnDestroy()
    {
        if (timerModelModel != null)
        {
            timerModelModel.TimerChanged -= OnTimerChanged;
            timerModelModel.TimerReached -= OnTimeReached;
        }
    }

    public void StartCounting()
    {
        timerModelModel.StartTime();
    }

    private void Update()
    {
        timerModelModel.Counting();
    }

    public void StopCounting()
    {
        timerModelModel.StopTime();
    }

    public void ResetTime()
    {
        timerModelModel.ResetTime();
    }

    public void AddCurrentTime(int plus)
    {
        timerModelModel.currentTime += plus;
    }
    public void OnTimeReached()
    {
        onTimerReached?.Invoke();
    }

    private void UpdateView()
    {
        timerFillImg.fillAmount = GetFillAmount();
    }

    public float GetFillAmount()
    {
        return timerModelModel.currentTime / timerModelModel.maxTime;
    }

    private void OnTimerChanged()
    {
        onTimerChanged?.Invoke();
        UpdateView();
    }
}
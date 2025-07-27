using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    //لیست لول ها
    public List<LevelData> levels;
    public int currentLevel;


    public static LevelManager Instance;

    public GameObject gameOverPanel;

// تایمر
    [SerializeField] private TimerPresenter timerPresenter;

    private void Awake()
    {
        Instance = this;
    }

    public void StartGame()
    {
        ImojiManager.Instance.levelData = levels[0];
        ImojiManager.Instance.SpwanImoji();
        timerPresenter.StartCounting();
    }

    public void NextLevel()
    {
        
        currentLevel++;
        if (currentLevel >= levels.Count)
        {
            
            // تعویض لول و ساخت دوباره ایموجی های جدید
            ImojiManager.Instance.levelData = levels[^1];
            ImojiManager.Instance.SpwanImoji();
            return;
        }

        ImojiManager.Instance.levelData = levels[currentLevel];
        ImojiManager.Instance.SpwanImoji();
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
    }

    public void Retry()
    {
        gameOverPanel.SetActive(false);

        currentLevel = 0;
        ImojiManager.Instance.ResetIMojies();
        StartGame();
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreModel : MonoBehaviour
{
    public float currentScore = 0;
    public int bestScore = 0;

  

    private void Start()
    {
        bestScore = SaveManager.Load().bestScore;
    }

    public void AddScore(float plus)
    {
        currentScore += plus;
        if (currentScore > bestScore)
        {
            SaveManager.Save((int) currentScore);
            bestScore = (int) currentScore;
            
        }
    }

    public void ResetScore()
    {
        currentScore = 0;
    }

    public void UpdateScore()
    {
       
    }

    public int GetCurrentScore()
    {
        return (int) currentScore;
    }
}
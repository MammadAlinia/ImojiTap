using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScorePresenter : MonoBehaviour
{
    [SerializeField] private ScoreModel scoreModel;

    [SerializeField] private List<TextMeshProUGUI> scoreTMP, bestScoreTMP;

    public void AddScore(float pluse)
    {
        scoreModel.AddScore( pluse);
        UpdateView();
    }

    private void UpdateView()
    {
        scoreTMP.ForEach(x => x.SetText($"Score : {scoreModel.GetCurrentScore()}"));
        bestScoreTMP.ForEach(x => x.SetText($"BestScore : {scoreModel.bestScore}"));
    }

    public void ResetScore()
    {
        scoreModel.ResetScore();
    }
}
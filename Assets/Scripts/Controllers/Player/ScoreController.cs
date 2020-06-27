using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    private int _score = 0;
    public static event EventHandler<int> ScoreChanged;

    private void FixedUpdate()
    {
        int newScore = ((int)transform.position.x / 10);
        if (newScore > this._score)
        {
            SetScore(newScore);
        }
    }

    public int GetScore
    {
        get
        {
            return this._score;
        }
    }

    public void AddScore()
    {
        _score++;
        OnScoreChanged(_score);
    }
    public void SetScore(int val)
    {
        _score = val;
        OnScoreChanged(val);
    }

    public void UpdateBestScore()
    {
        if (_score > PlayerController.PlayerModel.BestScore)
        {
            PlayerController.PlayerModel.BestScore = (uint)_score;
        }
    }

    protected virtual void OnScoreChanged(int x)
    {
        ScoreChanged?.Invoke(this, x);
    }
}

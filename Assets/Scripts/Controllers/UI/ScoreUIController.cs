using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ScoreUIController : MonoBehaviour
{
    private TextMeshProUGUI scoreTMP;

    private void Awake()
    {
        ScoreController.ScoreChanged += HandleScoreIncreased;
        scoreTMP = GetComponent<TextMeshProUGUI>();
    }

    private void HandleScoreIncreased(object sender, int e)
    {
        this.scoreTMP.text = e.ToString();
    }
}

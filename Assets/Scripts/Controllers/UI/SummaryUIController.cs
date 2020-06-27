using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SummaryUIController : MonoBehaviour
{
    public TextMeshProUGUI scoreTMP;

    private void OnEnable()
    {
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreTMP.text = GameObject.FindGameObjectWithTag("Player").GetComponent<ScoreController>().GetScore.ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SummaryUIController : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI scoreTMP;
    [SerializeField]
    private TextMeshProUGUI bestScoreTMP;

    private void OnEnable()
    {
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreTMP.text = PlayerController.playerController.gameObject.GetComponent<ScoreController>().GetScore.ToString();
        bestScoreTMP.text = PlayerController.PlayerModel.BestScore.ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LeaderboardUIController : MonoBehaviour
{
    public UIController uiController;
    public TextMeshProUGUI personalScore;

    public void BackButtonClicked()
    {
        uiController.MainMenu();
    }

    private void OnEnable()
    {
        personalScore.text = PlayerController.PlayerModel.BestScore.ToString();
    }
}

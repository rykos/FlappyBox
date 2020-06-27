using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderboardUIController : MonoBehaviour
{
    public UIController uiController;

    public void BackButtonClicked()
    {
        uiController.MainMenu();
    }
}

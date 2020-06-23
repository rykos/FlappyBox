using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject gameUI;
    public GameObject summaryUI;
    public GameObject homeUI;
    //

    private void Awake()
    {
        PlayerController.OnDeath += OnPlayerDeath;
    }

    public void Play()
    {
        homeUI.SetActive(false);
        gameUI.SetActive(true);
        PlayerController.gameActive = true;
    }

    public void PlayAgain()
    {
        //Reset game to default state
        GameObject.Find("Player").GetComponent<PlayerController>().SetDefaultState();
        GameObject.Find("Map").GetComponent<MapController>().SetDefaultState();
        summaryUI.SetActive(false);
        gameUI.SetActive(true);
    }

    public void MainMenu()
    {
        //Redirect to main menu
    }

    private void OnPlayerDeath(object sender, EventArgs e)
    {
        gameUI.SetActive(false);
        summaryUI.SetActive(true);
    }
}

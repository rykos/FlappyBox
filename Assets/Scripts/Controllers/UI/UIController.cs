using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject gameUI;
    public GameObject summaryUI;
    public GameObject homeUI;
    public GameObject leaderboardUI;
    //

    private void Awake()
    {
        PlayerController.OnDeath += OnPlayerDeath;
    }

    public void Play()
    {
        DisableAll();
        gameUI.SetActive(true);
        GameObject.Find("Player").GetComponent<PlayerController>().SetDefaultState(true);
    }

    public void PlayAgain()
    {
        //Reset game to default state
        GameObject.Find("Map").GetComponent<MapController>().SetDefaultState();
        GameObject.Find("Player").GetComponent<PlayerController>().SetDefaultState(true);
        DisableAll();
        gameUI.SetActive(true);
    }

    public void MainMenu()
    {
        GameObject.Find("Map").GetComponent<MapController>().SetDefaultState();
        GameObject.Find("Player").GetComponent<PlayerController>().SetDefaultState();
        DisableAll();
        homeUI.SetActive(true);
    }

    public void Leaderboard()
    {
        DisableAll();
        leaderboardUI.SetActive(true);
    }

    private void OnPlayerDeath(object sender, EventArgs e)
    {
        DisableAll();
        summaryUI.SetActive(true);
    }

    private void DisableAll()
    {
        summaryUI.SetActive(false);
        gameUI.SetActive(false);
        leaderboardUI.SetActive(false);
        homeUI.SetActive(false);
    }
}

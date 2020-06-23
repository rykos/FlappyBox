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
        GameObject.Find("Map").GetComponent<MapController>().SetDefaultState();
        GameObject.Find("Player").GetComponent<PlayerController>().SetDefaultState(true);
        summaryUI.SetActive(false);
        gameUI.SetActive(true);
    }

    public void MainMenu()
    {
        GameObject.Find("Map").GetComponent<MapController>().SetDefaultState();
        GameObject.Find("Player").GetComponent<PlayerController>().SetDefaultState();
        summaryUI.SetActive(false);
        gameUI.SetActive(false);
        homeUI.SetActive(true);
    }

    private void OnPlayerDeath(object sender, EventArgs e)
    {
        gameUI.SetActive(false);
        summaryUI.SetActive(true);
    }
}

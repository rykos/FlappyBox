﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerModel PlayerModel;
    public static PlayerController playerController;
    public Rigidbody2D rb;
    //
    public static bool gameActive = false;
    private bool gameStarted = false;
    public static EventHandler OnDeath;
    public IController Controller
    {
        get { return this._controller; }
        set
        {
            this._controller = value;
            OnControllerChange();
        }
    }
    private IController _controller;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerController = this;
    }

    private void Update()
    {
        if (!gameActive) return;
        if (gameStarted)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Controller.Tap();
            }
            else if (Input.GetMouseButtonUp(0))
            {
                Controller.Release();
            }
            else if (Input.GetMouseButton(0))
            {
                Controller.Hold();
            }
            ////Outside of camera view
            if (Mathf.Abs(transform.position.y) > 4)
            {
                Die();
            }
        }
        else//
        {
            if (Input.GetMouseButtonDown(0))
            {
                gameStarted = true;
                Controller.Tap();
            }
        }
    }
    private void FixedUpdate()
    {
        if (gameStarted)
        {
            Controller.Tick();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            Die();
        }
    }

    private void Die()
    {
        OnDeath.Invoke(this, EventArgs.Empty);
        gameActive = false;
        rb.velocity = Vector2.zero;
        GetComponent<ScoreController>().UpdateBestScore();
    }

    private void OnControllerChange()
    {
        rb.velocity = Vector2.zero;
        transform.rotation = Quaternion.Euler(1, 1, 0);
    }

    public void SetDefaultState(bool gameState = false)
    {
        //Reset (position, score)
        transform.localPosition = Vector3.zero;
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0;
        rb.rotation = 0;
        GetComponent<ScoreController>().SetScore(0);
        gameActive = gameState;
        gameStarted = false;
    }
}

[SerializeField]
public static class PlayerSettings
{
    public static float PlayerHorizontalSpeed = 3;
    public static float velocity = 5;
    public static float ITime = 8;
    public static float gravity = 9.8f;
}
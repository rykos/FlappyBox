using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //public float PlayerHorizontalSpeed = 1;
    //public float velocity = 1;
    //public float ITime = 1;
    //public float gravity = 1;
    public static PlayerController playerController;
    public Rigidbody2D rb;
    //
    public static bool gameActive = false;
    public static EventHandler OnDeath;
    public IController controller;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerController = this;
    }

    private void Update()
    {
        if (gameActive)
        {
            if (Input.GetMouseButtonDown(0))
            {
                controller.Tap();
            }

            ////Outside of camera view
            //if (Mathf.Abs(transform.position.y) > 3.5f)
            //{
            //    Die();
            //}
        }
    }



    private void FixedUpdate()
    {
        controller.Tick();
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
    }

    public void SetDefaultState(bool gameState = false)
    {
        //Reset (position, score)
        transform.localPosition = Vector3.zero;
        GetComponent<ScoreController>().SetScore(0);
        gameActive = gameState;
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
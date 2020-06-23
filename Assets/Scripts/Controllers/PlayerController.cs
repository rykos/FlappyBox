using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float PlayerHorizontalSpeed = 1;
    public float velocity = 1;
    public float ITime = 1;
    public float gravity = 1;
    private Rigidbody2D rb;
    //
    public static bool gameActive = false;
    public static EventHandler OnDeath;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (gameActive)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Jump();
            }
            rb.velocity += new Vector2(0, -gravity*Time.deltaTime);
            Quaternion newQ = Quaternion.Euler(0, 0, Mathf.Clamp(rb.velocity.y * 10, -45, 45));
            transform.rotation = Quaternion.Lerp(transform.rotation, newQ, Time.deltaTime * ITime);
            //Outside of camera view
            if (Mathf.Abs(transform.position.y) > 3.5f)
            {
                Die();
            }
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector2(PlayerHorizontalSpeed, (Vector2.up * velocity).y);
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

    public void SetDefaultState()
    {
        //Reset (position, score)
        transform.localPosition = Vector3.zero;
        GetComponent<ScoreController>().SetScore(0);
        gameActive = true;
    }
}

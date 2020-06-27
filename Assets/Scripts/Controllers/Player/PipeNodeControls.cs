using Controllers.Map;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeNodeControls : IController
{
    public readonly float MaxDashTime = 1.5f;
    public readonly float DashCooldown = 1;
    private Rigidbody2D rb;
    private Transform transform;
    private NodeSettings settings;
    private float heldTime;
    private bool dashing = false;
    private float dashCD = 0;

    public PipeNodeControls(NodeSettings settings)
    {
        this.rb = PlayerController.playerController.rb;
        this.transform = PlayerController.playerController.transform;
        this.settings = settings;
    }

    public void Hold()
    {
        heldTime += Time.deltaTime;
        if (heldTime > 0.1f && dashCD < 0.01f)
        {
            if (heldTime > MaxDashTime)//Out of energy
            {
                DisableDash();
            }
            else
            {
                dashing = true;
                rb.velocity = new Vector2(this.settings.PlayerHorizontalSpeed * 2f, 0);
            }
        }
    }

    public void Release()
    {
        if (heldTime < 0.1f)
        {
            Jump();
        }
        DisableDash();
        heldTime = 0;
    }

    public void Tap()
    {

    }

    public void Tick()
    {
        if (!dashing)
        {
            DecreaseCD();
            rb.velocity = new Vector2(this.settings.PlayerHorizontalSpeed, rb.velocity.y);
            rb.velocity += new Vector2(0, -PlayerSettings.gravity * Time.deltaTime);
        }
        Quaternion newQ = Quaternion.Euler(0, 0, Mathf.Clamp(rb.velocity.y * 10, -45, 45));
        transform.rotation = Quaternion.Lerp(transform.rotation, newQ, Time.deltaTime * PlayerSettings.ITime);
    }

    private void DecreaseCD()
    {
        if (dashCD > 0)
        {
            dashCD -= Time.deltaTime;
        }
    }
    
    private void DisableDash()
    {
        if (dashing)
        {
            dashing = false;
            dashCD = DashCooldown;
            rb.velocity = Vector2.zero;
            Debug.Log("Disabled dash");
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector2(PlayerSettings.PlayerHorizontalSpeed, (Vector2.up * PlayerSettings.velocity).y);
    }
}

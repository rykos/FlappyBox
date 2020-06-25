using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeNodeControls : IController
{
    private Rigidbody2D rb;
    private Transform transform;

    public PipeNodeControls(Rigidbody2D rb, Transform transform)
    {
        this.rb = rb;
        this.transform = transform;
    }

    public void Tap()
    {
        rb.velocity = new Vector2(PlayerSettings.PlayerHorizontalSpeed, (Vector2.up * PlayerSettings.velocity).y);
    }

    public void Tick()
    {
        rb.velocity += new Vector2(0, -PlayerSettings.gravity * Time.deltaTime);
        Quaternion newQ = Quaternion.Euler(0, 0, Mathf.Clamp(rb.velocity.y * 10, -45, 45));
        transform.rotation = Quaternion.Lerp(transform.rotation, newQ, Time.deltaTime * PlayerSettings.ITime);
    }
}

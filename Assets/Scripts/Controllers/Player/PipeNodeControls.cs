using Controllers.Map;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeNodeControls : IController
{
    private Rigidbody2D rb;
    private Transform transform;
    private NodeSettings settings;

    public PipeNodeControls(NodeSettings settings) {
        this.rb = PlayerController.playerController.rb;
        this.transform = PlayerController.playerController.transform;
        this.settings = settings;
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

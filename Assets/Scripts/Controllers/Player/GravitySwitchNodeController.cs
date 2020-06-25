using Controllers.Map;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitySwitchNodeControls : IController
{
    private Rigidbody2D rb;
    private Transform transform;
    private NodeSettings settings;

    public GravitySwitchNodeControls(Rigidbody2D rb, Transform transform)
    {
        this.rb = rb;
        this.transform = transform;
    }
    public GravitySwitchNodeControls(NodeSettings settings)
    {
        this.rb = PlayerController.playerController.rb;
        this.transform = PlayerController.playerController.transform;
        this.settings = settings;
    }

    public void Tap()
    {
        rb.velocity += new Vector2(0, settings.PlayerVerticalSpeed);
    }

    public void Tick()
    {
        rb.velocity *= 0.98f;
        transform.position += new Vector3(settings.PlayerHorizontalSpeed, 0, 0);
    }
}

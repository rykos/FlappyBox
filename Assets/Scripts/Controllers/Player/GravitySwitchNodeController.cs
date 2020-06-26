using Controllers.Map;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class GravitySwitchNodeControls : IController
{
    private Rigidbody2D rb;
    private Transform transform;
    private NodeSettings settings;
    //
    private float gravity = 1;

    public GravitySwitchNodeControls(NodeSettings settings)
    {
        this.rb = PlayerController.playerController.rb;
        this.transform = PlayerController.playerController.transform;
        this.settings = settings;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    public void Hold()
    {
        
    }

    public void Release()
    {
        
    }

    public void Tap()
    {
        //rb.velocity += new Vector2(0, settings.PlayerVerticalSpeed);
        gravity *= -1;
    }

    public void Tick()
    {
        rb.velocity = new Vector2(settings.PlayerHorizontalSpeed, rb.velocity.y);//Horizontal
        rb.velocity += new Vector2(0, settings.PlayerVerticalSpeed * -gravity * Time.deltaTime);//Gravity
    }
}

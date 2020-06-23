using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class CameraController : MonoBehaviour
{
    public Transform player;
    private bool follow = true;

    private void Awake()
    {
        PlayerController.OnDeath += OnPlayerDeath;
    }

    private void Update()
    {
        if (follow)
        {
            transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
        }
    }

    private void OnPlayerDeath(object sender, EventArgs e)
    {
        //follow = false;
    }
}

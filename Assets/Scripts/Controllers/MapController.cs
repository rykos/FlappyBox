using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MapController : MonoBehaviour
{
    //0.8 ^ -3
    public GameObject Pipe;
    private Transform player;
    private List<Transform> pipes = new List<Transform>();
    private bool generateMap = true; 

    private void Awake()
    {
        PlayerController.OnDeath += OnPlayerDeath;
        this.player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        BuildPipe(new Vector2(4, 0));
    }

    private void Update()
    {
        if (generateMap)
        {
            if (player.position.x + 10 > pipes.Last().position.x)
            {
                BuildPipe();
                if (pipes.Count > 5)
                {
                    Destroy(pipes[0].gameObject);
                    pipes.RemoveAt(0);
                }
            }
        }
    }

    private void OnPlayerDeath(object sender, EventArgs e)
    {
        generateMap = false;
    }

    private void BuildPipe()
    {
        Vector3 newPos = pipes.Last().position + new Vector3(UnityEngine.Random.Range(5f, 7f), 0, 0);
        BuildPipe(new Vector3(newPos.x, UnityEngine.Random.Range(-3, -0.8f), 0));
    }
    private void BuildPipe(Vector2 pos)
    {
        GameObject newPipe = Instantiate(Pipe, transform);
        newPipe.transform.localPosition = pos;
        pipes.Add(newPipe.transform);
    }

    public void SetDefaultState()
    {
        for (int i = pipes.Count - 1; i > -1; i--) 
        {
            Destroy(pipes[i].gameObject);
            pipes.RemoveAt(i);
        }
        BuildPipe(new Vector2(4, 0));
        generateMap = true;
    }
}

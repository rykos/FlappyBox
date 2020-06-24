﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Controllers.Map;
using System.Linq;

public class PipeNode : MonoBehaviour, INode
{
    public GameObject Pipe;//Pipe prefab
    public float spaceBetweenPillars;//Horizontal
    public float spaceBetweenPipes;//Vertical
    //Y=1 Y=-3
    private List<Transform> pipes = new List<Transform>();
    private float _size;

    public void Build(Vector2 position, float size)
    {
        this._size = size;
        int c = 0;
        while (true)
        {
            if (c > 500) break;
            c++;
            if (!BuildPipe() || pipes.Last().localPosition.x + 6 > size)
            {
                break;
            }
        }
    }

    private bool BuildPipe()
    {
        if (pipes.Count == 0) BuildPipe(Vector2.zero);
        Vector3 newPos = pipes.Last().localPosition + new Vector3(Random.Range(spaceBetweenPillars, 6f), 0, 0);
        Debug.Log(newPos.x);
        if (newPos.x + 1 > _size + transform.position.x)
        {
            Debug.Log($"{newPos.x} > {transform.position.x}");
            return false;
        }
        BuildPipe(new Vector3(newPos.x, UnityEngine.Random.Range(-3, 1), 0));
        return true;
    }
    private void BuildPipe(Vector2 pos)
    {
        GameObject newPipe = Instantiate(Pipe, transform);
        newPipe.transform.localPosition = pos;
        pipes.Add(newPipe.transform);
    }
}
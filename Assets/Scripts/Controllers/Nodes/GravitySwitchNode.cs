﻿using Controllers.Map;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GravitySwitchNode : MonoBehaviour, INode
{
    public GameObject WallPrefab;

    private List<GameObject> builtWalls = new List<GameObject>();

    public float Size
    {
        get
        {
            return _size;
        }
    }
    private float _size;

    public void Build(Vector2 position, float size)
    {
        this._size = (int)size - ((int)size%2);
        BuildWall();
        while (builtWalls.Last().transform.localPosition.x < _size - 2)
        {
            BuildWall(this.builtWalls.Last().transform.localPosition + new Vector3(1, 0, 0));
        }
    }

    private void BuildWall(Vector2 pos = default)
    {
        var newWall = Instantiate(WallPrefab, transform);
        newWall.transform.localPosition = pos + new Vector2(1, 0);
        builtWalls.Add(newWall);
    }

    private void OnDrawGizmosSelected()
    {
        Vector3 offset = new Vector3(0, 3.5f);
        Debug.DrawLine(transform.position - offset, transform.position + new Vector3(_size, -3.5f));
        Debug.DrawLine(transform.position + offset, transform.position + new Vector3(_size, 3.5f));
        Debug.DrawLine(transform.position - offset, transform.position + offset);
        Debug.DrawLine(transform.position + new Vector3(_size, 0) - offset, transform.position + new Vector3(_size, 0) + offset);
    }

    private void PlayerTap()
    {
        
    }
}
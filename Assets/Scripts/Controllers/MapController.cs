using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Controllers.Map;

public class MapController : MonoBehaviour
{
    //0.8 ^ -3
    public List<GameObject> nodes;
    private List<GameObject> _builtNodes = new List<GameObject>();
    private Transform _player;
    private bool _generateMap = true; 

    private void Awake()
    {
        PlayerController.OnDeath += OnPlayerDeath;
        this._player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        BuildNewNode();
    }

    private void FixedUpdate()
    {
        if (_generateMap)
        {
            if (_player.position.x + 20 > _builtNodes.Last().transform.position.x)
            {
                BuildNewNode(_builtNodes.Last().transform.position + new Vector3(50, 0));
                if (_builtNodes.Count() > 3)
                {
                    DestroyOldestNode();
                }
            }
        }
    }

    private void BuildNewNode(Vector2 pos = default)
    {
        var newNode = Instantiate(nodes[UnityEngine.Random.Range(0, 2)], transform);
        newNode.transform.position = pos;
        _builtNodes.Add(newNode);
        (newNode.GetComponent<INode>()).Build(Vector2.zero, 50);
    }

    private void DestroyOldestNode()
    {
        Destroy(_builtNodes[0]);
        _builtNodes.RemoveAt(0);
    }

    private void OnPlayerDeath(object sender, EventArgs e)
    {
        _generateMap = false;
    }

    public void SetDefaultState()
    {
        _generateMap = true;
    }


}

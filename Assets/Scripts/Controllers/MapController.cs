using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Controllers.Map;

public class MapController : MonoBehaviour
{
    //0.8 ^ -3
    public GameObject SpacingNode;//Node used to space out game nodes
    public List<GameObject> nodes;
    //
    private List<GameObject> _builtNodes = new List<GameObject>();
    private Transform _player;
    private bool _generateMap = true;

    private void Awake()
    {
        PlayerController.OnDeath += OnPlayerDeath;
        this._player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        BuildNewNode();
        BuildSpacingNode();
    }

    private void FixedUpdate()
    {
        if (_generateMap)
        {
            if (_player.position.x + 20 > _builtNodes.Last().transform.position.x)
            {
                BuildNewNode(_builtNodes.Last().transform.position + new Vector3(_builtNodes.Last().GetComponent<INode>().Size, 0, 0));
                BuildSpacingNode();
                if (_builtNodes.Count() > 4)
                {
                    DestroyOldestNodes(2);
                }
            }
        }
    }

    private void BuildNewNode(Vector2 pos = default, GameObject node = null, float size = 0)
    {
        var newNode = Instantiate(node ?? GetRandomNode(), transform);
        newNode.transform.position = pos;
        _builtNodes.Add(newNode);
        (newNode.GetComponent<INode>()).Build(Vector2.zero, (size == 0) ? GetRandomSize() : size);
    }

    private void BuildSpacingNode()
    {
        BuildNewNode(_builtNodes.Last().transform.position + new Vector3(_builtNodes.Last().GetComponent<INode>().Size, 0, 0), this.SpacingNode, 10);
    }

    private GameObject GetRandomNode()
    {
        return nodes[UnityEngine.Random.Range(0, 2)];
    }
    private float GetRandomSize()
    {
        return UnityEngine.Random.Range(100, 150);
    }

    private void DestroyOldestNodes(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            Destroy(_builtNodes[i]);
        }
        _builtNodes.RemoveRange(0, amount);
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

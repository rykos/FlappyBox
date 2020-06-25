using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Controllers.Map;
using System.IO;

public class MapController : MonoBehaviour
{
    //0.8 ^ -3
    public GameObject SpacingNode;//Node used to space out game nodes
    public List<GameObject> nodes;
    //
    private List<GameObject> _builtNodes = new List<GameObject>();
    //private Dictionary<FloatRange, GameObject> _buildNodesRanges = new Dictionary<FloatRange, GameObject>();
    private List<FloatRange> _buildNodesRanges = new List<FloatRange>();
    private float controllerTreshold;
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
            //_buildNodes[0].transform.position.x => (_buildNodes[0].transform.position.x + _size) Node range
            if (_player.position.x + 10 > _builtNodes.Last().transform.position.x)//Generate new node when player is able to see last generated node
            {
                BuildNewNode(_builtNodes.Last().transform.position + new Vector3(_builtNodes.Last().GetComponent<INode>().Size, 0, 0));
                BuildSpacingNode();
                if (_builtNodes.Count() > 4)
                {
                    DestroyOldestNodes(2);
                }
            }
            if (_player.position.x + 8 > this.controllerTreshold)//Controller outdated, find new one
            {
                int index = this._buildNodesRanges.FindIndex(x => x.IsInRange(_player.position.x + 8));
                IController newController = _builtNodes[index].GetComponent<INode>().Controller;
                if (newController == null)
                {
                    index++;
                    newController = _builtNodes[index].GetComponent<INode>().Controller;
                };
                PlayerController.playerController.controller = newController;
                controllerTreshold = _buildNodesRanges[index].End;
                Debug.Log($"Changed controller to {newController.ToString()}");
            }
        }
    }

    private void BuildNewNode(Vector2 pos = default, GameObject node = null, float size = 0)
    {
        var newNode = Instantiate(node ?? GetRandomNode(), transform);
        newNode.transform.position = pos;
        float nodeSize = (size == 0) ? GetRandomSize() : size;
        (newNode.GetComponent<INode>()).Build(Vector2.zero, nodeSize);
        //
        _builtNodes.Add(newNode);
        _buildNodesRanges.Add(new FloatRange(pos.x, pos.x + nodeSize));
    }

    private void BuildSpacingNode()
    {
        Vector3 pos = _builtNodes.Last().transform.position + new Vector3(_builtNodes.Last().GetComponent<INode>().Size, 0, 0);
        BuildNewNode(pos, this.SpacingNode, 10);
    }

    private GameObject GetRandomNode()
    {
        return nodes[UnityEngine.Random.Range(0, nodes.Count)];
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
        _buildNodesRanges.RemoveRange(0, amount);
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

struct FloatRange
{
    public float Start;
    public float End;
    public FloatRange(float start, float end)
    {
        this.Start = start;
        this.End = end;
    }
    /// <summary>
    /// Return true if value is in range (exclusive)
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public bool IsInRange(float value)
    {
        if (value > Start && value < End)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
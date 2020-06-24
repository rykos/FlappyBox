using Controllers.Map;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GravitySwitchNode : MonoBehaviour, INode
{
    public GameObject WallPrefab;

    private List<GameObject> builtWalls = new List<GameObject>();

    private float _size;

    public void Build(Vector2 position, float size)
    {
        this._size = size;
        BuildWall();
        while (builtWalls.Last().transform.localPosition.x + 5 < size)
        {
            BuildWall(this.builtWalls.Last().transform.position + new Vector3(2, 0, 0));
        }
    }

    private void BuildWall(Vector2 pos = default)
    {
        var newWall = Instantiate(WallPrefab, transform);
        newWall.transform.localPosition = pos;
        builtWalls.Add(newWall);
    }

    private void Awake()
    {
        Build(Vector2.zero, 50);
    }
}

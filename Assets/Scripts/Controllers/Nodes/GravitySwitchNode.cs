using Controllers.Map;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GravitySwitchNode : MonoBehaviour, INode
{
    public GameObject WallPrefab;
    private List<GameObject> builtWalls = new List<GameObject>();
    [SerializeField]
    public NodeSettings settings;
    public List<GameObject> ObstaclePrefabs;
    private List<Transform> builtObstacles = new List<Transform>();

    public float Size
    {
        get
        {
            return _size;
        }
    }
    private float _size;
    public IController Controller { get { return new GravitySwitchNodeControls(settings); } }


    public void Build(Vector2 position, float size)
    {
        this._size = (int)size - ((int)size % 2);
        BuildScaffold();
        BuildObstacles();
    }

    private void BuildScaffold()
    {
        BuildWall();
        while (builtWalls.Last().transform.localPosition.x < _size - 2)
        {
            BuildWall(this.builtWalls.Last().transform.localPosition + new Vector3(1, 0, 0));
        }
    }

    private void BuildObstacles()
    {
        BuildObstacleAt(new Vector3(2, 0, 0));
        Vector3 newObstaclePos;
        while ((newObstaclePos = builtObstacles.Last().localPosition + new Vector3(Random.Range(6, 12), 0, 0)).x < Size)
        {
            BuildObstacleAt(newObstaclePos);
        }
    }

    private void BuildObstacleAt(Vector2 pos)
    {
        GameObject newObstacle = Instantiate(RandomObstacle(), transform);
        newObstacle.transform.localPosition = new Vector2(pos.x, (Random.Range(0, 2) * 2 - 1) * Random.Range(2.5f, 4f));
        builtObstacles.Add(newObstacle.transform);
    }

    private GameObject RandomObstacle()
    {
        return ObstaclePrefabs[Random.Range(0, ObstaclePrefabs.Count)];
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
}

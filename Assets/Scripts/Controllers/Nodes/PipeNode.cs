using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Controllers.Map;
using System.Linq;

public class PipeNode : MonoBehaviour, INode
{
    public GameObject Pipe;//Pipe prefab
    public float spaceBetweenPillars;//Horizontal
    public float spaceBetweenPipes;//Vertical
    public NodeSettings settings;
    //
    IController INode.Controller { get { return new PipeNodeControls(settings); } }
    private List<Transform> pipes = new List<Transform>();

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
        if (newPos.x + 1 > _size + transform.position.x)
        {
            return false;
        }
        BuildPipe(new Vector3(newPos.x, UnityEngine.Random.Range(-3f, 1f), 0));
        return true;
    }
    private void BuildPipe(Vector2 pos)
    {
        GameObject newPipe = Instantiate(Pipe, transform);
        newPipe.transform.localPosition = pos;
        pipes.Add(newPipe.transform);
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

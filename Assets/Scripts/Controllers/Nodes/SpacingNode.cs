using Controllers.Map;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpacingNode : MonoBehaviour, INode
{
    public GameObject WallPrefab;
    public float Size
    {
        get { return this._size; }
    }
    private float _size;

    public void Build(Vector2 position, float size)
    {
        this._size = size;
        var Wall = Instantiate(WallPrefab, transform);
        Wall.transform.localScale = new Vector3(_size / 2, 1, 1);
        Wall.transform.localPosition = new Vector3(_size / 2, 0, 0);
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

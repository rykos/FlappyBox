using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{
    [SerializeField]
    private Color FrontgroundColor;
    [SerializeField]
    private Color BackgroundColor;
    [SerializeField]
    private SpriteRenderer[] Frontground;
    [SerializeField]
    private SpriteRenderer[] Background;

    private void Awake()
    {
        Paint();
    }

    private void Paint()
    {
        if (FrontgroundColor != default)
        {
            foreach (var go in Frontground)
            {
                go.color = FrontgroundColor;
            }
        }
        if (BackgroundColor != default)
        {
            foreach (var go in Background)
            {
                go.color = BackgroundColor;
            }
        }
    }

    public void Recolor(Color front = default, Color back = default)
    {
        if (front != default) this.FrontgroundColor = front;
        if (back != default) this.BackgroundColor = back;
        Paint();
    }
}

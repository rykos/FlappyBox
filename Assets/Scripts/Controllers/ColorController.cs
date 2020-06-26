using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorController : MonoBehaviour
{
    public Color Color
    {
        get { return this._color; }
        private set
        {
            _color = value;
            RebuildColor();
        }
    }
    private Color _color;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        this.spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetColor(Color color)
    {
        this.Color = color;
    }

    public void AddColor(Color color)
    {
        this.Color += color;
    }

    public void SubtractColor(Color color)
    {
        this.Color -= color;
    }

    private void RebuildColor()
    {
        this.spriteRenderer.color = Color;
    }
}

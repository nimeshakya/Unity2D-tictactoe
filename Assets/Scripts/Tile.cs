using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public Color baseColor, offsetColor;
    [SerializeField]private SpriteRenderer _renderer;
    [SerializeField]private GameObject _hightlight;

    public Vector2 tilePos;

    public void ColorGrid(bool isOffset)
    {
        _renderer.color = isOffset ? offsetColor : baseColor;
    }

    private void OnMouseOver()
    {
        _hightlight.SetActive(true);
    }

    private void OnMouseExit()
    {
        _hightlight.SetActive(false);
    }
}

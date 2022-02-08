using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public Color baseColor, offsetColor;
    [SerializeField]private SpriteRenderer _renderer;
    [SerializeField]private GameObject _hightlight;

    public void ColorGrid(bool isOffset)
    {
        _renderer.color = isOffset ? offsetColor : baseColor;
    }

    private void OnMouseEnter()
    {
        _hightlight.SetActive(true);
    }

    private void OnMouseExit()
    {
        _hightlight.SetActive(false);
    }
}

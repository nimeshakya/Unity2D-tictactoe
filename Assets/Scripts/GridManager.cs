using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public int columns, rows;
    public Tile _tilePrefab;
    public GameObject cam;

    Dictionary<Vector2, Tile> _tiles;

    public void GenerateGrid()
    {
        _tiles = new Dictionary<Vector2, Tile>();
        for(int i = 0; i < columns; i++)
        {
            for(int j = 0; j < rows; j++)
            {
                var spawnedTile = Instantiate(_tilePrefab, new Vector3(i, j), Quaternion.identity);
                spawnedTile.name = $"Tile {i} {j}";
                spawnedTile.GetComponent<Tile>().tilePos = new Vector2(i, j); // store the position of the tile in tilePos var

                var isOffset = (i % 2 == 0 && j % 2 != 0) || (i % 2 != 0 && j % 2 == 0);
                spawnedTile.ColorGrid(isOffset);

                _tiles[new Vector2(i, j)] = spawnedTile;
            }
        }

        cam.transform.position = new Vector3((float)columns / 2 - 0.5f, (float)rows / 2 - 0.5f, -10.0f);
    }

    public Tile GetTileAtPos(Vector2 pos)
    {
        if (_tiles.TryGetValue(pos, out var tile))
            return tile;
        else return null;
    }
}

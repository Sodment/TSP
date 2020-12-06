using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CreateBigMap : MonoBehaviour
{
    public Tilemap tilemap;
    public TileBase tile;
    void Start()
    {
        Vector2Int vec = new Vector2Int(5000, 5000);
        Vector3Int[] positions = new Vector3Int[vec.x * vec.y];
        TileBase[] tileArray = new TileBase[positions.Length];

        for (int i = 0; i < positions.Length; i++)
        {
            positions[i] = new Vector3Int(i % vec.x, i / vec.y, 0);
            tileArray[i] = tile;

        }
        tilemap.SetTiles(positions, tileArray);
    }
}

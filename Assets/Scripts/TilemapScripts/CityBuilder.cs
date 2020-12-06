using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CityBuilder : MonoBehaviour
{
    public Tilemap tilemap;
    public Tile cityTile;
    public Tile uppperRight;
    public Tile uppperLeft;
    public Tile lowerRight;

    public void BuildCityOnMap()
    {
        foreach(Vector3Int pos in ListOfCities.instance.CityList)
        {
            tilemap.SetTile(pos, cityTile);
            tilemap.SetTile(new Vector3Int(pos.x, pos.y+1, pos.z), uppperLeft);
            tilemap.SetTile(new Vector3Int(pos.x+1, pos.y+1, pos.z), uppperRight);
            tilemap.SetTile(new Vector3Int(pos.x+1, pos.y, pos.z), lowerRight);
        }
    }
}

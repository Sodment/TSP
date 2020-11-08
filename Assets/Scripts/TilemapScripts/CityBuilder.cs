using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CityBuilder : MonoBehaviour
{
    public Tilemap tilemap;
    public Tile cityTile;

    public void BuildCityOnMap()
    {
        foreach(Vector3Int pos in ListOfCities.instance.CityList)
        {
            tilemap.SetTile(pos, cityTile);
        }
    }
}

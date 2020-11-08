using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CityGenerator : MonoBehaviour
{
    public Tilemap tilemap;
    public Tile cityTile;
    public int numberOfCities;

    public void GenerateListOfCities()
    {
        int i = 0;
        while(i < numberOfCities)
        {
            Vector3Int vector = new Vector3Int
            {
                x = Random.Range(-25, 25),
                y = Random.Range(-24, 25),
                z = 0
            };
            if (tilemap.GetTile(vector) != cityTile)
            {
                ListOfCities.instance.CityList.Add(vector);
                //Debug.Log(vector);
                tilemap.SetTile(vector, cityTile);
                i++;
            }
        }
    }
}

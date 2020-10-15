using UnityEngine;
using UnityEngine.Tilemaps;

public class PlaceCityOnTilemap : MonoBehaviour
{
    public Tilemap tileMap;
    private Tilemap tileMapComponent;

    public Tile cityTile;
    private Vector3Int mousePos;
    void Start()
    {
        tileMapComponent = tileMap.GetComponent<Tilemap>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = MouseOverPosition.instance.mouseOverPosition;
        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log("Pozycja: " + mouseOverPosition);
            ListOfCities.instance.CityList.Add(mousePos);
            tileMapComponent.SetTile(mousePos, cityTile);

        }
    }
}

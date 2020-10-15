using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class HighlightMouseOverTile : MonoBehaviour
{
    public Tilemap tileMap;
    public Tilemap highligthMap;
    private Tilemap tileMapComponent;
    private Tilemap highlightMapComponent;

    public Tile changer;
    public Tile highligther;

    private Vector3Int prevHigligthedVector;

    void Start()
    {
        tileMapComponent = tileMap.GetComponent<Tilemap>();
        highlightMapComponent = highligthMap.GetComponent<Tilemap>();
    }
    void Update()
    {
        Vector3Int mouseOverPosition = tileMap.WorldToCell(Camera.main.ScreenToWorldPoint(Input.mousePosition));

        if (prevHigligthedVector != mouseOverPosition)
        {
            highlightMapComponent.SetTile(prevHigligthedVector, null);
        }

        prevHigligthedVector = mouseOverPosition; 
        highlightMapComponent.SetTile(mouseOverPosition, highligther);

        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log("Pozycja: " + mouseOverPosition);
            tileMapComponent.SetTile(mouseOverPosition, changer);
            
        }
    }
}


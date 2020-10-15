using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class HighlightMouseOverTile : MonoBehaviour
{
    public Tilemap tilemap;
    public Tilemap highligthmap;
    private Tilemap tileMapComponent;
    private Tilemap highlightMapComponent;
    public Tile changer;
    public Tile highligther;
    public Vector3Int prevHigligthedVector;

    void Start()
    {
        tileMapComponent = tilemap.GetComponent<Tilemap>();
        highlightMapComponent = highligthmap.GetComponent<Tilemap>();
    }
    void Update()
    {
        Vector3Int mouseOverPosition = tilemap.WorldToCell(Camera.main.ScreenToWorldPoint(Input.mousePosition));

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


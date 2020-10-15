using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class HighlightMouseOverTile : MonoBehaviour
{
    public Tilemap highligthMap;
    private Tilemap highlightMapComponent;

    public Tile highligther;

    private Vector3Int mousePos;
    private Vector3Int prevHigligthedVector;

    void Start()
    {
        highlightMapComponent = highligthMap.GetComponent<Tilemap>();
    }
    void Update()
    {
        mousePos = MouseOverPosition.instance.mouseOverPosition;
        if (prevHigligthedVector != mousePos)
        {
            highlightMapComponent.SetTile(prevHigligthedVector, null);
        }

        prevHigligthedVector = mousePos; 
        highlightMapComponent.SetTile(mousePos, highligther);
    }
}


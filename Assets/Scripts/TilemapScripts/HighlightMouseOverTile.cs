using UnityEngine;
using UnityEngine.Tilemaps;

public class HighlightMouseOverTile : MonoBehaviour
{
    public Tilemap highligthMap;
    private Tilemap highlightMapComponent;

    public Tile highligther;

    private Vector3Int mousePos;
    private Vector3Int prevHigligthedVector;

    public bool highlightEnabled = false;

    void Start()
    {
        GameManager.instance.SwitchingToGraphSetting.AddListener(SwitchHiglither);
        GameManager.instance.QuittingGraphSetting.AddListener(SwitchHiglither);
        GameManager.instance.QuittingGraphSetting.AddListener(DeleteLastHighligther);
        highlightMapComponent = highligthMap.GetComponent<Tilemap>();
    }
    void Update()
    {
        if (highlightEnabled)
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

    void SwitchHiglither()
    {
        highlightEnabled = !highlightEnabled;
    }

    void DeleteLastHighligther()
    {
        highlightMapComponent.SetTile(prevHigligthedVector, null);
    }
}


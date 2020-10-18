using UnityEngine;
using UnityEngine.Tilemaps;

public class PlaceCityOnTilemap : MonoBehaviour
{
    public Tilemap tileMap;
    private Tilemap tileMapComponent;

    public Tile cityTile;
    private Vector3Int mousePos;

    public bool builderEnabled = false;
    void Start()
    {
        GameManager.instance.SwitchingToGraphSetting.AddListener(SwitchBuilder);
        GameManager.instance.QuittingGraphSetting.AddListener(SwitchBuilder);
        tileMapComponent = tileMap.GetComponent<Tilemap>();
    }

    // Update is called once per frame
    void Update()
    {
        if (builderEnabled)
        {
            mousePos = MouseOverPosition.instance.mouseOverPosition;
            if (Input.GetMouseButtonDown(0) && tileMapComponent.GetTile(mousePos) != null)
            {
                //Debug.Log("Pozycja: " + mouseOverPosition);
                ListOfCities.instance.CityList.Add(mousePos);
                tileMapComponent.SetTile(mousePos, cityTile);

            }
        }
    }

    void SwitchBuilder()
    {
        builderEnabled = !builderEnabled;
    }
}

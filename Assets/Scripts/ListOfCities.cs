using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListOfCities : MonoBehaviour
{
    public static ListOfCities instance;
    public List<Vector3Int> CityList = new List<Vector3Int>();

    private Vector3Int mousePos;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
            return;
        }
    }
    void Update()
    {
        mousePos = MouseOverPosition.instance.mouseOverPosition;
        if (Input.GetMouseButtonDown(0))
        {
            CityList.Add(mousePos);
            Debug.Log(CityList);
        }
    }
}

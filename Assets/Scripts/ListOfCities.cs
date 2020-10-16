using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListOfCities : MonoBehaviour
{
    public static ListOfCities instance;
    public List<Vector3Int> CityList = new List<Vector3Int>();
    public float distanceTraveled;

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
}

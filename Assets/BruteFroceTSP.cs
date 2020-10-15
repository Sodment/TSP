using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class BruteFroceTSP : MonoBehaviour
{
    private List<Vector3Int> cityCopy = new List<Vector3Int>();
    public List<Vector3Int> VisitedCities = new List<Vector3Int>();
    private Vector3Int currentCity;
    private Vector3Int nearestCity;
    private int startingCity;
    private int cityCopyLength;

    void Start()
    {
        GameManager.instance.SwitchingToSimulating.AddListener(CopyListOfCities);
        GameManager.instance.SwitchingToSimulating.AddListener(SetVariablesForSimulation);
        GameManager.instance.SwitchingToSimulating.AddListener(Path);

    }

    void Update()
    {
        
    }

    void CopyListOfCities()
    {
        cityCopy = ListOfCities.instance.CityList;
    }

    void SetVariablesForSimulation()
    {
        cityCopyLength = cityCopy.Count;
        startingCity = Random.Range(0, cityCopyLength);
        currentCity = cityCopy[startingCity];
    }

    void Path()
    {
        for (int i = 0; i < cityCopyLength; i++)
        {
            VisitedCities.Add(currentCity);
            cityCopy.Remove(currentCity);
            FindNearestCity();
        }

    }

    void FindNearestCity()
    {
        float minDistance = float.MaxValue;
        foreach(Vector3Int city in cityCopy)
        {
            float distanceToCity = Vector3Int.Distance(currentCity, city);
            if (distanceToCity < minDistance)
            {
                minDistance = distanceToCity;
                nearestCity = city;
            }
        }
    }
}

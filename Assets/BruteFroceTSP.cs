using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Transactions;
using UnityEngine;

public class BruteFroceTSP : MonoBehaviour
{
    private List<Vector3Int> cityCopy = new List<Vector3Int>();
    public List<Vector3Int> VisitedCities = new List<Vector3Int>();
    public Vector3Int currentCity;
    [SerializeField]
    private Vector3Int nearestCity;
    public int startingCity;
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
        cityCopy = new List<Vector3Int>(ListOfCities.instance.CityList);
    }

    void SetVariablesForSimulation()
    {
        cityCopyLength = cityCopy.Count;
        //startingCity = 0;
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
            currentCity = nearestCity;
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
                nearestCity = city;
                minDistance = distanceToCity;
            }
        }
    }
}

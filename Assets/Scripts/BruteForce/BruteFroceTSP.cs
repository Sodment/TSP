using System.Collections.Generic;
using UnityEngine;

public class BruteFroceTSP : MonoBehaviour
{
    private List<Vector3Int> cityCopy;
    public List<Vector3Int> VisitedCities = new List<Vector3Int>();
    public Vector3Int currentCity = Vector3Int.zero;
    private Vector3Int nearestCity;
    public int startingCity;
    private int cityCopyLength;

    void Start()
    {
        GameManager.instance.SwitchingToSimulating.AddListener(CopyListOfCities);
        GameManager.instance.SwitchingToSimulating.AddListener(SetVariablesForSimulation);
        GameManager.instance.SwitchingToSimulating.AddListener(Path);

    }

    void CopyListOfCities()
    {
        cityCopy = new List<Vector3Int>(ListOfCities.instance.CityList);
    }

    void SetVariablesForSimulation()
    {
        cityCopyLength = cityCopy.Count;
        startingCity = 0; //Random.Range(0, cityCopyLength);
        currentCity = ListOfCities.instance.CityList[startingCity];
    }

    void Path()
    {
        for (int i = 0; i < cityCopyLength; i++)
        {
            Debug.Log("Brute enforcer path: ");
            Debug.Log(ListOfCities.instance.CityList.IndexOf(currentCity));
            VisitedCities.Add(currentCity);
            cityCopy.Remove(currentCity);
            FindNearestCity();
            currentCity = nearestCity;
        }
        VisitedCities.Add(ListOfCities.instance.CityList[startingCity]);
        ListOfCities.instance.distanceTraveled = DistanceCalculator(VisitedCities);
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

    double DistanceCalculator(List<Vector3Int> list)
    {
        double distance = 0;
        for (int i = 1; i < list.Count; i++)
        {
            distance += Vector3Int.Distance(list[i - 1], list[i]);
        }
        return distance;
    }
}

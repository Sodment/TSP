using System.Collections.Generic;
using UnityEngine;

public class BruteForceMovment : MonoBehaviour
{
    public BruteFroceTSP intelligence;
    public List<Vector3Int> path = new List<Vector3Int>();
    public GameObject bruteEnforcer;
    private float speed = 5f;

    void Start()
    {
        GameManager.instance.SwitchingToSimulating.AddListener(SetPath);
        GameManager.instance.SwitchingToSimulating.AddListener(SetFirstLocation);
    }

    void Update()
    {
        float step = speed * Time.deltaTime;
        if (path.Count > 0 && transform.position == path[0])
        {
            path.Remove(path[0]);
        }
        if (path.Count > 0)
        {
            bruteEnforcer.transform.position = Vector3.MoveTowards(transform.position, path[0], step);
        }
    }
    void SetPath()
    {
        path = intelligence.VisitedCities;
    }

    void SetFirstLocation()
    {
        bruteEnforcer.transform.position = ListOfCities.instance.CityList[intelligence.startingCity];
    }
}

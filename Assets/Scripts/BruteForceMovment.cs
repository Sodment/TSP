using System.Collections.Generic;
using UnityEngine;

public class BruteForceMovment : MonoBehaviour
{
    public BruteFroceTSP intelligence;
    public List<Vector3Int> path = new List<Vector3Int>();
    public GameObject bruteEnforcer;
    private float speed = 5f;
    private Vector3Int startingCity;
    [SerializeField]
    private bool run;

    void Start()
    {
        
        GameManager.instance.SwitchingToSimulating.AddListener(SetPath);
        GameManager.instance.SwitchingToSimulating.AddListener(SwitchRunning);
        GameManager.instance.SwitchingToSimulating.AddListener(SetFirstLocation);
        GameManager.instance.QuittingSimulating.AddListener(SwitchRunning);
    }

    void Update()
    {
        if (run)
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
            if (path.Count == 0)
            {
                bruteEnforcer.transform.position = Vector3.MoveTowards(transform.position, startingCity, step);
            }
        }
    }
    void SetPath()
    {
        path = new List<Vector3Int>(intelligence.VisitedCities);
    }

    void SetFirstLocation()
    {
        startingCity = ListOfCities.instance.CityList[intelligence.startingCity];
        bruteEnforcer.transform.position = startingCity;
    }

    void SwitchRunning()
    {
        run = !run;
    }
}

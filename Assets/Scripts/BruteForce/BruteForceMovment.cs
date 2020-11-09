using System.Collections.Generic;
using UnityEngine;
public class BruteForceMovment : MonoBehaviour
{
    public BruteFroceTSP intelligence;
    public List<Vector3Int> path;
    public TrailRenderer trailRenderer;
    public GameObject bruteEnforcer;
    private Animator animator;
    private float speed = 15f;
    private int currentCityindex = 0;

    void Start()
    {
        GameManager.instance.QuittingGraphSetting.AddListener(SetPath);
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float step = speed * Time.deltaTime;
        if (path.Count > 0 && transform.position == path[currentCityindex] && currentCityindex < path.Count - 1)
        {
            currentCityindex++;
        }
        if (currentCityindex < path.Count)
        {
            animator.SetBool("Idle", false);
            bruteEnforcer.transform.position = Vector3.MoveTowards(transform.position, path[currentCityindex], step);
            transform.localScale = new Vector3(Mathf.Sign(path[currentCityindex].x - transform.position.x), 1, 1);
        }
        if(path.Count > 0 && bruteEnforcer.transform.position == path[0])
        {
            animator.SetBool("Idle", true);
        }
    }
    void SetPath()
    {
        path = new List<Vector3Int>(intelligence.VisitedCities);
        bruteEnforcer.transform.position = path[0];
        trailRenderer.Clear();
    }
}
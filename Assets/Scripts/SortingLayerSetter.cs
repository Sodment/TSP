using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingLayerSetter : MonoBehaviour
{
    public TrailRenderer trailRenderer;
    void Start()
    {
        trailRenderer.sortingLayerName = "Character";
    }
}

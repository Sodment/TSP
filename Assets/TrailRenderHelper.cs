using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailRenderHelper : MonoBehaviour
{
    public TrailRenderer trail;
    // Use this for initialization
    void Start()
    {
        trail.sortingLayerName = "Background";
        trail.sortingOrder = 2;
    }
}

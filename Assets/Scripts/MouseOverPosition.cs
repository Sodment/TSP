using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOverPosition : MonoBehaviour
{
    public  static MouseOverPosition instance;
    public Grid grid;
    public Vector3Int mouseOverPosition;
    private void Awake()
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

    // Update is called once per frame
    void Update()
    {
        mouseOverPosition = grid.WorldToCell(Camera.main.ScreenToWorldPoint(Input.mousePosition));
    }
}

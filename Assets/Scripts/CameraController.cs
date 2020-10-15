using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float moveSpeed;
    public float targetZoom;
    public float zoomSpeed;
    [SerializeField]
    private float zoomLerpSpeed = 20;

    public float minZoomDist;
    public float maxZoomDist;

    private Camera cam;

    void Move()
    {
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");
        Vector3 dir = transform.up * yInput + transform.right * xInput;
        transform.position += dir * moveSpeed * Time.deltaTime;
    }

    void Zoom()
    {
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");
        targetZoom -= scrollInput * zoomSpeed;
        targetZoom = Mathf.Clamp(targetZoom, minZoomDist, maxZoomDist);
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, targetZoom, Time.deltaTime*zoomLerpSpeed);
    }

    void Awake()
    {
        cam = Camera.main;
    }

    void Start()
    {
        targetZoom = cam.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Zoom();
    }
}

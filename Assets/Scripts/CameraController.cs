using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public static Camera cam;
    private int zoomSpeed = 5;
    private static int maxZoom = 10;
    private static int minZoom = 60;


    // Use this for initialization
    void Start() {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetAxis("Mouse ScrollWheel") < 0) // back
        {
            cam.orthographicSize+=zoomSpeed;
            if(cam.orthographicSize>60)
            {
                cam.orthographicSize = minZoom;
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") >0) // forward
        {
            cam.orthographicSize-=zoomSpeed;
            if(cam.orthographicSize<10)
            {
                cam.orthographicSize = maxZoom;
            }
        }
    }
}

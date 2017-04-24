using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public static Camera cam;
    private int zoomSpeed = 5;
    private static int maxZoom = 10;
    private static int minZoom = 60;
    public static Sprite background;

    private float CameraSpeed;
    private Vector3 goodPosition;


    // Use this for initialization
    void Start() {
        cam = Camera.main;
        background = GameObject.Find("Background").GetComponent<SpriteRenderer>().sprite;
        
    }

    // Update is called once per frame
    void Update() {
        zoomCamera();
        moveCamera();   
    }


    public void zoomCamera()
    {
        if (Input.GetAxis("Mouse ScrollWheel") < 0) // back
        {
            cam.orthographicSize += zoomSpeed;
            if (cam.orthographicSize > 60)
            {
                cam.orthographicSize = minZoom;
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0) // forward
        {
            cam.orthographicSize -= zoomSpeed;
            if (cam.orthographicSize < 10)
            {
                cam.orthographicSize = maxZoom;
            }
        }
    }

    public void moveCamera()
    {
        CameraSpeed = cam.orthographicSize / 50.0f;
        goodPosition = cam.transform.position;
        if (Input.GetKey("w"))
        {
            cam.transform.Translate(0, CameraSpeed, 0);
            limitCamera(goodPosition);
            if (Input.GetKey("d"))
            {
                cam.transform.Translate(CameraSpeed, CameraSpeed, 0);
                limitCamera(goodPosition);
            }
            else if (Input.GetKey("a"))
            {
                cam.transform.Translate(-CameraSpeed, CameraSpeed, 0);
                limitCamera(goodPosition);
            }
        }
        else if (Input.GetKey("s"))
        {
            cam.transform.Translate(0, -CameraSpeed, 0);
            limitCamera(goodPosition);
            if (Input.GetKey("d"))
            {
                cam.transform.Translate(CameraSpeed, -CameraSpeed, 0);
                limitCamera(goodPosition);
            }
            else if (Input.GetKey("a"))
            {
                cam.transform.Translate(-CameraSpeed, -CameraSpeed, 0);
                limitCamera(goodPosition);
            }
        }
        else if (Input.GetKey("a"))
        {
            cam.transform.Translate(-CameraSpeed, 0, 0);
            limitCamera(goodPosition);
        }
        else if (Input.GetKey("d"))
        {
            cam.transform.Translate(CameraSpeed, 0, 0);
            limitCamera(goodPosition);
        }
        
    }

    public void limitCamera(Vector3 goodPosition)
    {
        if(cam.transform.position.x <= 0 || cam.transform.position.y>=0 || cam.transform.position.x>=500 || cam.transform.position.y <= -280)
        {
            cam.transform.position = goodPosition;
        }
       
    }
}

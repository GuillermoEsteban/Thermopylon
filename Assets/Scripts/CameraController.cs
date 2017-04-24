using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public static Camera cam;
    private int zoomSpeed = 5;
    private static int maxZoom = 10;
    private static int minZoom = 60;
    public static Sprite background;


    // Use this for initialization
    void Start() {
        cam = Camera.main;
        background = GameObject.Find("Background").GetComponent<SpriteRenderer>().sprite;
    }

    // Update is called once per frame
    void Update() {
        zoomCamera();
        moveCamera();
        limitCamera();
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
        if (Input.GetKey("w"))
        {
            cam.transform.Translate(0,1,0);
            if (Input.GetKey("d"))
            {
                cam.transform.Translate(1, 1, 0);
            }
            else if (Input.GetKey("a"))
            {
                cam.transform.Translate(-1, 1, 0);
            }
        }
        else if (Input.GetKey("s"))
        {
            cam.transform.Translate(0, -1, 0);
            if (Input.GetKey("d"))
            {
                cam.transform.Translate(1, -1, 0);
            }
            else if (Input.GetKey("a"))
            {
                cam.transform.Translate(-1, -1, 0);
            }
        }
        else if (Input.GetKey("a"))
        {
            cam.transform.Translate(-1, 0, 0);
        }
        else if (Input.GetKey("d"))
        {
            cam.transform.Translate(1, 0, 0);
        }
    }

    public void limitCamera()
    {
        if((cam.transform.position.x + cam.pixelWidth/2)>= background.border.x)
        {
            //cam.transform.position(cam.transform.position.x-1,transform.position.y,transform.position.z);
        }
        else if ((cam.transform.position.x - cam.pixelWidth / 2) <= 0)
        {
            cam.transform.Translate(1, 0, 0);
        }
        else if ((cam.transform.position.y + cam.pixelHeight / 2) >= background.border.y)
        {
            cam.transform.Translate(0, -1, 0);
        }
        else if ((cam.transform.position.y - cam.pixelHeight / 2) <= 0)
        {
            cam.transform.Translate(0, 1, 0);
        }
    }
}

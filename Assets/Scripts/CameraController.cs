using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    //ZOOM DE LA CÀMERA
    public static Camera cam;
    private int zoomSpeed = 5;
    private static int maxZoom = 20;
    private static int minZoom = 115;
    public static Sprite background;
	private static int limitX = 1000;
	private static int limitY = 500;

    //MOVIMENT DE LA CÀMERA
    private float CameraSpeed;
    private Vector3 goodPosition;

    //CORRECCIÓ D'SCROLL EN EL MARGE
    bool correccioScrollMarge;
    bool marge;


    // Use this for initialization
    void Start() {
        cam = Camera.main;
        background = GameObject.Find("Background").GetComponent<SpriteRenderer>().sprite;

        correccioScrollMarge = false;
        marge = false;
        
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
            if (cam.orthographicSize > minZoom)
            {
                cam.orthographicSize = minZoom;
            }
            if (marge)
            {
                correccioScrollMarge = true;
            }
            else
            {
                correccioScrollMarge = false;
            }
        }
        else if (Input.GetAxis("Mouse ScrollWheel") > 0) // forward
        {
            cam.orthographicSize -= zoomSpeed;
            if (cam.orthographicSize < maxZoom)
            {
                cam.orthographicSize = maxZoom;
            }
            if (marge)
            {
                correccioScrollMarge = true;
            }
            else
            {
                correccioScrollMarge = false;
            }
        }
    }

    public void moveCamera()
    {
        CameraSpeed = cam.orthographicSize / 30.0f;
        goodPosition = cam.transform.position;
        if (Input.GetKey("w"))
        {
            cam.transform.Translate(0, CameraSpeed, 0);
            if (Input.GetKey("d"))
            {
                cam.transform.Translate(CameraSpeed, CameraSpeed, 0);
            }
            else if (Input.GetKey("a"))
            {
                cam.transform.Translate(-CameraSpeed, CameraSpeed, 0);
            }
        }
        else if (Input.GetKey("s"))
        {
            cam.transform.Translate(0, -CameraSpeed, 0);
            if (Input.GetKey("d"))
            {
                cam.transform.Translate(CameraSpeed, -CameraSpeed, 0);
            }
            else if (Input.GetKey("a"))
            {
                cam.transform.Translate(-CameraSpeed, -CameraSpeed, 0);
            }
        }
        else if (Input.GetKey("a"))
        {
            cam.transform.Translate(-CameraSpeed, 0, 0);
        }
        else if (Input.GetKey("d"))
        {
            cam.transform.Translate(CameraSpeed, 0, 0);   
        }
        limitCamera(goodPosition);

    }

    public void limitCamera(Vector3 goodPosition)
    {
        if(cam.transform.position.x - cam.orthographicSize * 1.8f <= 0 || cam.transform.position.y + cam.orthographicSize >= 0 || cam.transform.position.x + cam.orthographicSize * 1.8f >= limitX || cam.transform.position.y - cam.orthographicSize <= -limitY)
        {
            marge = true;
            zoomCamera();
            if (correccioScrollMarge)
            {
                if(cam.transform.position.x - cam.orthographicSize * 1.8f <= 0)
                {
                    goodPosition.x += 20;
                }
                if(cam.transform.position.y + cam.orthographicSize >= 0)
                {
                    goodPosition.y -= 10;
                }
                if(cam.transform.position.x + cam.orthographicSize * 1.8f >= 500)
                {
                    goodPosition.x -= 20;
                }
                if (cam.transform.position.y - cam.orthographicSize <= -280)
                {
                    goodPosition.y += 10;
                }
            }
            cam.transform.position = goodPosition;
            marge = false;
            correccioScrollMarge = false;
        }
    }
}

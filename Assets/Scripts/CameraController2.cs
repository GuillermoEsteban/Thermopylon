using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController2 : MonoBehaviour
{

    //ZOOM DE LA CÀMERA
    public static Camera cam;//variable de la pròpia càmera
    private int zoomSpeed = 5;//velocitat del zoom
    private static int maxZoom = 20;//el zoom màxim a que pot arribar
    private static int minZoom = 115;//el zoom mínim
    public static Sprite background;//l'sprite de background
    public static int limitX = 1040;//el límit en l'eix de les X
    public static int limitY = 588;// límit en l'eix de les Y

    //MOVIMENT DE LA CÀMERA
    private float CameraSpeed;//la velocitat de la càmera en moviment per l'escena.

    // Use this for initialization
    void Start()
    {
        cam = Camera.main;//la variable càmera és ara la de la MainCamera.

    }

    void Update()
    {
        zoomCamera();
        moveCamera();
    }


    public void zoomCamera()
    {
        if (Input.GetAxis("Mouse ScrollWheel") < 0) // back
        {
            cam.orthographicSize += zoomSpeed;//orthographicSize és una variable de la pròpia càmera ortogràfica, que indica la part de l'escena ques es pot veure.
                                              //augmentarà un zoomSpeed si tirem l'scroll enrera.
            if (cam.orthographicSize > minZoom)//si arribem als límits es quedarà amb...
            {
                cam.orthographicSize = minZoom;//...aquest valor.
            }
        }
        else if (Input.GetAxis("Mouse ScrollWheel") > 0) // el mateix que l'anterior però al revés
        {
            cam.orthographicSize -= zoomSpeed;
            if (cam.orthographicSize < maxZoom)
            {
                cam.orthographicSize = maxZoom;
            }
        }
    }

    public void moveCamera()
    {
        CameraSpeed = cam.orthographicSize / 30.0f;//el moviment de la càmera canvia segons l'ortographicSize. Així quan més gran sigui més gran serà la velocitat.

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
    }

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

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
    private Vector3 goodPosition;//la posició dins dels límits.

    //CORRECCIÓ D'SCROLL EN EL MARGE
    bool correccioScrollMarge;//booleà per saber si es necessita corregir l'scroll en cas que la posició de la càmera estigui en un marge
    bool marge;//si està en un marge de mapa.


    // Use this for initialization
    void Start() {
        cam = Camera.main;//la variable càmera és ara la de la MainCamera.
        background = GameObject.Find("Background").GetComponent<SpriteRenderer>().sprite;//la variable background és el mapa Background.

        correccioScrollMarge = false;//les dues variables comencen en false, donada la posició de la càmera inicial.
        marge = false;
        
    }

    void Update() {
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
            if (marge)
            {
                correccioScrollMarge = true;//si estem en un marge aleshores necessitarà una correcció del zoom.
            }
            else
            {
                correccioScrollMarge = false;
            }
        }
        else if (Input.GetAxis("Mouse ScrollWheel") > 0) // el mateix que l'anterior però al revés
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
        CameraSpeed = cam.orthographicSize / 30.0f;//el moviment de la càmera canvia segons l'ortographicSize. Així quan més gran sigui més gran serà la velocitat.
        goodPosition = cam.transform.position;//comencem dient que la posició correcta és l'actual.
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
        limitCamera(goodPosition);//limitem la càmera passant la variable goodPosition.

    }

    public void limitCamera(Vector3 goodPosition)
    {   //en el cas que la posició de la càmera estigui fora del mapa:
        if(cam.transform.position.x - cam.orthographicSize * 1.8f <= 0 || cam.transform.position.y + cam.orthographicSize >= 0 || cam.transform.position.x + cam.orthographicSize * 1.8f >= limitX || cam.transform.position.y - cam.orthographicSize <= -limitY)
        {
            marge = true;//canviem la variable marge a true...
            zoomCamera();//...i tornem a cridar la funció del zoom, que ara tindrà marge=true i retornarà correccioScrollMarge=true:
            if (correccioScrollMarge)
            {
                if(cam.transform.position.x - cam.orthographicSize * 1.8f <= 0)
                {
                    goodPosition.x += 20;//aleshores per cada costat sobrepassat retornarà a goodPosition inicial +/- un canvi en l'eix.
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
            cam.transform.position = goodPosition;//i la goodPosition serà aquesta última.
            marge = false;//tornem a posar les variables a false.
            correccioScrollMarge = false;
        }
    }
}

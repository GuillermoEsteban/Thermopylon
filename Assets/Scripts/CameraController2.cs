using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController2 : MonoBehaviour
{

    //ZOOM DE LA CÀMERA
    public static Camera cam;//variable de la pròpia càmera
    private int zoomSpeed = 5;//velocitat del zoom
    private float maxZoom;//el zoom màxim a que pot arribar
    private float minZoom;//el zoom mínim

    //MOVIMENT DE LA CÀMERA
    private float CameraSpeed;//la velocitat de la càmera en moviment per l'escena.
    private Vector3 goodPosition;//la posició dins dels límits.
    public static float limitX;//el límit en l'eix de les X
    public static float limitY;// límit en l'eix de les Y

    //CORRECCIÓ D'SCROLL EN EL MARGE
    bool correccioScrollMarge;//booleà per saber si es necessita corregir l'scroll en cas que la posició de la càmera estigui en un marge
    bool marge;//si està en un marge de mapa.


    // Use this for initialization
    void Awake()
    {
        cam = Camera.main;//la variable càmera és ara la de la MainCamera.
        correccioScrollMarge = false;//les dues variables comencen en false, donada la posició de la càmera inicial.
        marge = false;
        maxZoom = 5.0f;

        limitX=GameObject.Find("NewMap").GetComponent<RandomMap2>().getLimitX();
        limitY = GameObject.Find("NewMap").GetComponent<RandomMap2>().getLimitY();

        minZoom = (limitX + 60.1f) / (2 * cam.aspect) - 1.0f;
        cam.orthographicSize = minZoom;
        cam.GetComponent<Rigidbody2D>().position = new Vector2((limitX + 60.1f) / 2 - 60.1f, 0);

		/*
		GameObject RainHitBox = (GameObject)Instantiate(Resources.Load("RainHitbox"), new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);
		RainHitBox.transform.parent = transform;
		RainHitBox.transform.position = transform.position;
		RainHitBox.GetComponent<BoxCollider> ().size = new Vector3(288,288,1);

		GameObject RainParticles = (GameObject)Instantiate(Resources.Load("RainParticles"), new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);
		RainParticles.transform.parent = transform;
		RainParticles.transform.position = transform.position + new Vector3(288,288,-10);
		*/
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
        CameraSpeed = cam.orthographicSize / 20.0f;//el moviment de la càmera canvia segons l'ortographicSize. Així quan més gran sigui més gran serà la velocitat.
        goodPosition = cam.transform.position;//comencem dient que la posició correcta és l'actual.
        if (Input.GetKey("w"))
        {
            cam.transform.Translate(0, CameraSpeed, 0);
            if (Input.GetKey("d"))
            {
                cam.transform.Translate(CameraSpeed / 2, CameraSpeed / 2, 0);
            }
            else if (Input.GetKey("a"))
            {
                cam.transform.Translate(-CameraSpeed / 2, CameraSpeed / 2, 0);
            }
        }
        else if (Input.GetKey("s"))
        {
            cam.transform.Translate(0, -CameraSpeed, 0);
            if (Input.GetKey("d"))
            {
                cam.transform.Translate(CameraSpeed / 2, -CameraSpeed / 2, 0);
            }
            else if (Input.GetKey("a"))
            {
                cam.transform.Translate(-CameraSpeed / 2, -CameraSpeed / 2, 0);
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
        if (cam.transform.position.x - cam.orthographicSize * cam.aspect <= -60.1f || cam.transform.position.y + cam.orthographicSize >= limitY + 150 || cam.transform.position.x + cam.orthographicSize * cam.aspect >= limitX || cam.transform.position.y - cam.orthographicSize <= -(limitY + 150))
        {
            marge = true;//canviem la variable marge a true...
            zoomCamera();//...i tornem a cridar la funció del zoom, que ara tindrà marge=true i retornarà correccioScrollMarge=true:
            if (correccioScrollMarge)
            {
                if (cam.transform.position.x - cam.orthographicSize * cam.aspect <= -60.1f)
                {
                    goodPosition.x += cam.aspect*zoomSpeed*2;//aleshores per cada costat sobrepassat retornarà a goodPosition inicial +/- un canvi en l'eix.
                    cam.transform.position = goodPosition;//i la goodPosition serà aquesta última.
                    if (cam.transform.position.x + cam.orthographicSize * cam.aspect >= limitX)
                    {
                        cam.orthographicSize = minZoom;
                    }
                }
                if (cam.transform.position.y + cam.orthographicSize >= (limitY + 150))
                {
                    goodPosition.y -= cam.aspect * zoomSpeed*2;
                }
                if (cam.transform.position.x + cam.orthographicSize * cam.aspect >= limitX)
                {
                    goodPosition.x -= cam.aspect * zoomSpeed*2;
                    cam.transform.position = goodPosition;//i la goodPosition serà aquesta última.
                    if (cam.transform.position.x - cam.orthographicSize * cam.aspect <= -60.1f)
                    {
                        cam.orthographicSize = minZoom;
                    }
                }
                if (cam.transform.position.y - cam.orthographicSize <= -(limitY + 150))
                {
                    goodPosition.y += cam.aspect * zoomSpeed*2;
                }
            }
            cam.transform.position = goodPosition;//i la goodPosition serà aquesta última.
            marge = false;//tornem a posar les variables a false.
            correccioScrollMarge = false;
        }
    }
}


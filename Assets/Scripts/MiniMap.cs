using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
	//ZOOM DE LA CÀMERA
	public static Camera cam;//variable de la pròpia càmera
	private int zoomSpeed = 5;//velocitat del zoom

	private float size;

	private float limitX;//el límit en l'eix de les X
	private float limitY;// límit en l'eix de les Y


	// Use this for initialization
	void Awake()
	{
		cam = GameObject.Find("miniMapCamera(Clone)").GetComponent<Camera>();

        limitX =GameObject.Find("NewMap").GetComponent<RandomMap2>().getLimitX();
		//limitY = GameObject.Find("NewMap").GetComponent<RandomMap2>().getLimitY();//en principi limitY no ens caldria

		size = (limitX) / (2* cam.aspect) -100;
		cam.orthographicSize = size;
		cam.GetComponent<Rigidbody2D>().position = new Vector2((limitX) / 2 , 0);

	}

}
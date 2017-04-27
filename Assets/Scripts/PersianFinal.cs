/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersianFinal : MonoBehaviour {

	// Use this for initialization
	//MOVIMENT**********************************
	private Vector3 destiny;
	public float speed;
	private Vector3 relativePosition;

	//angles:
	private float angle;
	private Vector3 vectorDirector;
	private Vector3 puntAnterior;
	private Vector3 puntNou;
	private float posY;

	//Canvi de sprites
	public Animator anim;

	//ATTACKS***********************************

	//parent henomotia:
	public Persian_Group persian_group;


	void Start ()
	{
		//obtenim el punt inicial:
		puntAnterior = transform.parent.position;
		puntNou = transform.parent.position;


		//busquem la henomotia del parent de l'espartà per a després poder saber si és la que l'usuari controla.
		persian_group = this.gameObject.GetComponentInParent<Persian_Group>();
	}

	// Update is called once per frame
	void Update ()
	{
		AngleUpdate();
		changeWeapon();
	}

	public void AngleUpdate()
	{
		//només si no s'utilitza l'escut s'hauria de poder caminar:
		destiny = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		vectorDirector = (destiny - puntAnterior);
		posY = vectorDirector.y;
				//calculem l'angle
		angle = Vector3.Angle(Vector3.right, vectorDirector.normalized);
			
		puntNou = transform.parent.position;
	}

	public void setRelativePosition(Vector3 relativePosition)
	{
		this.relativePosition = relativePosition;
	}

	public Vector3 getRelativePosition()
	{
		return relativePosition;
	}
}
*/
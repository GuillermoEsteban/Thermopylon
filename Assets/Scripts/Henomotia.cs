using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Henomotia: MonoBehaviour {
	
	//ENUMS
	enum Formation { circle , square , delta }	//Enum de las tres formaciones
	enum Weapon { XIPHOS, JAVELIN, ASPIS, SHIELD}	//Enum de las tres armas

	//ATRIBUTOS
	private List<Spartan> SpartanList;	//Lista que alberga todos los espartanos
	private int numSpartan;	//Número de espartanos de la henomotia
	private float posX, posY; 	//Posicición X e Y de la henomotia
	private Formation formation;	//Formación de la henomotia
	private float speed;	//Velocidad de la henomotia
	private float []direction;	//Vector dirección de la henomotia
	private Weapon weapon;		//Definimos el arma de la henomotia

	//START
	void Start ()
	{
		numSpartan = 36;

		//Inicializamos la lista henomotia
		SpartanList = new List<Spartan>();
		for(int i=0; i<numSpartan;i++)
		{
			SpartanList.Add((Spartan)Instantiate(Resources.Load("Spartan"), new Vector3(i * 2.0f, 0.0f, 0.0f), Quaternion.identity));         
		}

	}

	//MÉTODOS
	public void MoveHenomotia()
	{
		for(int i=0; i<numSpartan;i++)
		{
			SpartanList [i].moveToPosition (1.0f,1.0f);       
		}
	}

	public void ChangeWeapon()
	{
		
	}

	public void ChangeFormation()
	{

	}

	public bool isAlive()
	{
		return true;
	}

}

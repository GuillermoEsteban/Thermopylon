using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Henomotia: MonoBehaviour {
	
	//ENUMS
	private enum Formation { circle , square , delta }	//Enum de las tres formaciones
	private enum Weapon { XIPHOS, JAVELIN, ASPIS, SHIELD}	//Enum de las tres armas

	//ATRIBUTOS
	List<Spartan> SpartanList;	//Lista que alberga todos los espartanos
	int numSpartan;	//Número de espartanos de la henomotia
	float posX, posY; 	//Posicición X e Y de la henomotia
	Formation formation;	//Formación de la henomotia
	float speed;	//Velocidad de la henomotia
	float []direction;	//Vector dirección de la henomotia
	Weapon weapon;		//Definimos el arma de la henomotia

	//START
	void Start ()
	{
		numSpartan = 36;

		//Inicializamos la lista henomotia
		SpartanList = new List<Spartan>();
		for(int i=0; i<numSpartan;i++)
		{
			SpartanList.Add((Spartan)Instantiate(Resources.Load("Spartan"), new Vector3(i * 2f, 0, 0), Quaternion.identity));         
		}

	}

	//MÉTODOS
	void MoveHenomotia()
	{
		for(int i=0; i<numSpartan;i++)
		{
			SpartanList [i].moveToPosition (1,1);       
		}
	}

	void ChangeWeapon()
	{
		
	}

	void ChangeFormation()
	{

	}

	bool isAlive()
	{
		return true;
	}

}

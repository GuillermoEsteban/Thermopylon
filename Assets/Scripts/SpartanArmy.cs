using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpartanArmy : MonoBehaviour {

	public List<GameObject> HenomotiaList;	//Lista que alberga todos los espartanos
	private int numHenomotia;	//Número de espartanos de la henomotia 

	public int startingSpartan;
	public int currentSpartan;


	void start()
	{
		numHenomotia = 9;

		HenomotiaList = new List<GameObject>();

		for (int i = 0; i < numHenomotia; i++)
		{

			HenomotiaList.Add((GameObject)Instantiate(Resources.Load("Henomotia"), new Vector3(0.0f,0.0f, 0.0f), Quaternion.identity));
			HenomotiaList[i].transform.parent= transform;
		}

	}


}
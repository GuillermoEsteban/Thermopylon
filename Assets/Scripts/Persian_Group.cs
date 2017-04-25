using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Persian_Group : MonoBehaviour {

	private List<GameObject> PersianList;	//Lista que alberga todos los espartanos
	private int numPersian;
	private float speed;
	private const int filas =9;
	private const float dist = 3;

	// Use this for initialization
	void Start () 
	{
		numPersian = 36;
		speed = 5.0f;

		//Inicializamos la lista henomotia
		PersianList = new List<GameObject>();

		for (int i = 0; i < numPersian; i++)
		{

			PersianList.Add((GameObject)Instantiate(Resources.Load("Persians"), new Vector3(0.0f,0.0f, 0.0f), Quaternion.identity));
		}
			
	}
	
	// Update is called once per frame
	void Update () {
		
	}



	public void initializePersianPos()
	{
		float col = numPersian / filas;   //filas es una constante que vale 9, ya que siempre queremos 9 filas.
		Vector3 PersianPos = new Vector3((col * dist) * 0.5f, (filas * dist)*0.5f, 0.0f); //calculamos la posición del primer espartano.
		Vector3 cont = new Vector3(0.0f,0.0f,0.0f); //creamos un contador de tipo vector.
			
		for (int i = 0,j = 0;i<numPersian;i++,j++)
		{
			if(j==filas)    //cuando la j llega a 9 es decir a la ultima fila saltamos de columna hacia atrás mediante la variable cont.
			{
				j = 0;
				cont.y = 0.0f;
				cont.z = 0.0f;
				cont.x -= dist;
			}
			PersianList[i].transform.position = transform.position + PersianPos + cont;   //la posición de cada persa se ve determinada por el centro de la henomotia + la posicion relativa al centro sacada de sumar la posición del primer espartano y el contador. 
			cont.y -= dist;
			cont.z -= 0.1f;
		}
	}

	/*
	public void MoveHenomotia()
	{
		if(this.gameObject.name== selectedHenomotia)
		{
			if (Input.GetMouseButtonDown(1))
			{
				destiny = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				destiny = new Vector3(destiny.x, destiny.y, 0.0f);
				vectorDirector = destiny - transform.position;

				for (int i = 0; i < numSpartan; i++)
				{
					SpartanList[i].GetComponent<Spartan>().setDestiny(vectorDirector);
				}
			}
			transform.position = Vector3.MoveTowards(transform.position, destiny, speed * Time.deltaTime);
		}
	}
*/
}
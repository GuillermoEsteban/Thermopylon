using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Persian_Group : MonoBehaviour {

	private List<GameObject> PersianList;	//Lista que alberga todos los espartanos
	private int numPersian;
	private float speed;
	private const int filas =9;
	private const float dist = 3;


	//walk cap a una henomotia:
	public GameObject henomotia;
	public GameObject henomotia_1;
	private Vector2 posicioHenomotia;
	private Vector2 posicioHenomotia_comparacio;
	public float persianSpeed;

	Vector2 vectorDirector;
	Vector2 vectorDirector_comparacio;
	Vector2 posicioActual;
	Vector2 posicioAnterior;

	private static float minDistance=1000.0f; //de moment és 1000, fins que el Guillermo acabi lo de les posicions de les Henomoties.
	private float angle;
	private float posY;

	private Vector3 destiny;
	Quaternion hRotation;
	Vector3 destVector;


	// Use this for initialization
	void Start () 
	{
		numPersian = 36;
		speed = 5.0f;

		//Inicializamos la lista henomotia
		PersianList = new List<GameObject>();

		for (int i = 0; i < numPersian; i++)
		{

			PersianList.Add((GameObject)Instantiate(Resources.Load("Persian"), new Vector3(0.0f,0.0f, 0.0f), Quaternion.identity));
            PersianList[i].transform.parent = transform;
		}
		initializePersianPos ();


		destiny = transform.position;


	}
	
	// Update is called once per frame
	void Update () 
	{
		moveToSpartans();
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

	public void moveToSpartans()
	{
		posicioHenomotia = henomotia.transform.position;
		posicioHenomotia_comparacio = henomotia_1.transform.position;
		vectorDirector = posicioHenomotia - posicioActual;
		vectorDirector_comparacio = posicioHenomotia_comparacio - posicioActual;

		//de moment comparem entre les dues distàncies del persa a les henomoties i seguim la més propera.
		if (vectorDirector.magnitude >= vectorDirector_comparacio.magnitude)
		{
			vectorDirector = vectorDirector_comparacio;
			destiny = vectorDirector;
			posicioHenomotia = posicioHenomotia_comparacio;
		}
		if (vectorDirector.magnitude <= minDistance)
		{
			posY = vectorDirector.y;
			//calculem l'angle i canviem l'sprite.
			angle = Vector3.Angle(Vector3.right, vectorDirector.normalized);
			transform.position = Vector2.MoveTowards(posicioActual, posicioHenomotia, persianSpeed);

			posicioActual = transform.position;


			posicioAnterior = transform.position; 
		}


		destiny = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		destiny = new Vector3(destiny.x, destiny.y, 0.0f);
		destVector = destiny - transform.position;
		hRotation = Quaternion.FromToRotation(transform.right,destVector);
		hRotation = new Quaternion(0.0f, 0.0f, hRotation.z,hRotation.w);      


		transform.position = Vector3.MoveTowards(transform.position, destiny, speed * Time.deltaTime);
		transform.rotation = Quaternion.RotateTowards(transform.rotation, hRotation, 10 * Time.deltaTime);
	}

}




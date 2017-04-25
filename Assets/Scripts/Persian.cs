using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Persian : MonoBehaviour {

	private List<GameObject> PersianList;	//Lista que alberga todos los espartanos
	private int numPersian;	//Número de espartanos de la henomotia
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

    //Canvi de sprites
    public Animator anim;

    // Use this for initialization
    void Start () {

		numPersian = 36;
		speed = 5.0f;

        //creem la variable animació per més comoditat:
        anim = GetComponent<Animator>();

        anim.SetBool("moving", false);
        henomotia = GameObject.Find("Henomotia");
        henomotia_1 = GameObject.Find("Henomotia(1)");

        persianSpeed = .15f; //*Time.deltaTime;

        posicioActual = transform.position;
        posicioAnterior = transform.position;

		initializePersianPos ();
    }
	
	// Update is called once per frame
	void Update () {
        moveToSpartans();
	}

    //funció per canviar la imatge de l'sprite segons l'angle:
    public void changeSprite()
    {
        if (anim.GetBool("moving")){ 
            if (angle < 22.5f)
            {
                anim.SetBool("walk_1", false);
                anim.SetBool("walk_2", false);
                anim.SetBool("walk_3", true);
                anim.SetBool("walk_4", false);
                anim.SetBool("walk_5", false);
                anim.SetBool("walk_6", false);
                anim.SetBool("walk_7", false);
                anim.SetBool("walk_8", false);
            }
            else if (22.5f <= angle && angle < 67.5f && posY > 0)
            {
                anim.SetBool("walk_1", false);
                anim.SetBool("walk_2", false);
                anim.SetBool("walk_3", false);
                anim.SetBool("walk_4", true);
                anim.SetBool("walk_5", false);
                anim.SetBool("walk_6", false);
                anim.SetBool("walk_7", false);
                anim.SetBool("walk_8", false);
            }
            else if (67.5f <= angle && angle < 112.5f && posY > 0)
            {

                anim.SetBool("walk_1", false);
                anim.SetBool("walk_2", false);
                anim.SetBool("walk_3", false);
                anim.SetBool("walk_4", false);
                anim.SetBool("walk_5", true);
                anim.SetBool("walk_6", false);
                anim.SetBool("walk_7", false);
                anim.SetBool("walk_8", false);
            }
            else if (112.5f <= angle && angle < 157.5f && posY > 0)
            {
                anim.SetBool("walk_1", false);
                anim.SetBool("walk_2", false);
                anim.SetBool("walk_3", false);
                anim.SetBool("walk_4", false);
                anim.SetBool("walk_5", false);
                anim.SetBool("walk_6", true);
                anim.SetBool("walk_7", false);
                anim.SetBool("walk_8", false);
            }
            else if (angle > 157.5f)
            {
                anim.SetBool("walk_1", false);
                anim.SetBool("walk_2", false);
                anim.SetBool("walk_3", false);
                anim.SetBool("walk_4", false);
                anim.SetBool("walk_5", false);
                anim.SetBool("walk_6", false);
                anim.SetBool("walk_7", true);
                anim.SetBool("walk_8", false);
            }
            else if (22.5f <= angle && angle < 67.5f && posY < 0)
            {
                anim.SetBool("walk_1", false);
                anim.SetBool("walk_2", true);
                anim.SetBool("walk_3", false);
                anim.SetBool("walk_4", false);
                anim.SetBool("walk_5", false);
                anim.SetBool("walk_6", false);
                anim.SetBool("walk_7", false);
                anim.SetBool("walk_8", false);
            }
            else if (67.5f <= angle && angle < 112.5f && posY < 0)
            {

                anim.SetBool("walk_1", true);
                anim.SetBool("walk_2", false);
                anim.SetBool("walk_3", false);
                anim.SetBool("walk_4", false);
                anim.SetBool("walk_5", false);
                anim.SetBool("walk_6", false);
                anim.SetBool("walk_7", false);
                anim.SetBool("walk_8", false);
            }
            else if (112.5f <= angle && angle < 157.5f && posY < 0)
            {
                anim.SetBool("walk_1", false);
                anim.SetBool("walk_2", false);
                anim.SetBool("walk_3", false);
                anim.SetBool("walk_4", false);
                anim.SetBool("walk_5", false);
                anim.SetBool("walk_6", false);
                anim.SetBool("walk_7", false);
                anim.SetBool("walk_8", true);
            }
        }
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
			PersianList[i].transform.position = transform.position + PersianPos + cont;   //la posición de cada epersa se ve determinada por el centro de la henomotia + la posicion relativa al centro sacada de sumar la posición del primer espartano y el contador. 
			cont.y -= dist;
			cont.z -= 0.1f;
		}
	}
}
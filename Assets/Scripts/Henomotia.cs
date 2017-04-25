using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Henomotia: MonoBehaviour {
	
	//ENUMS
	enum Formation { circle , square , delta }	//Enum de las tres formaciones
	enum Weapon { XIPHOS, JAVELIN, ASPIS, SHIELD}	//Enum de las tres armas

	//ATRIBUTOS
	private List<GameObject> SpartanList;	//Lista que alberga todos los espartanos
	private int numSpartan;	//Número de espartanos de la henomotia
	private Formation formation;	//Formación de la henomotia
	private float speed;	//Velocidad de la henomotia
    private Vector3 destiny;
	private Weapon weapon;  //Definimos el arma de la henomotia
    private Vector3 vectorDirector;
    private const int filas =9;
    private const float dist = 3;

    //SELECCIONAR HENOMOTIA:
    private string selectedHenomotia;

    


	//START
	void Start ()
	{

		numSpartan = 36;
        speed = 5.0f;

        //Inicializamos la lista henomotia
        SpartanList = new List<GameObject>();

        for (int i = 0; i < numSpartan; i++)
        {
            
            SpartanList.Add((GameObject)Instantiate(Resources.Load("Spartan_Sprite"), new Vector3(0.0f,0.0f, 0.0f), Quaternion.identity));
        }

        initializeSpartanPos();

        destiny = transform.position;

        //inicialitzem la Henomotia com la base:
        selectedHenomotia = "Henomotia";
    }

	void Update()
	{
        MoveHenomotia();
        if (Input.GetKeyDown("c"))
            Debug.Log("circleFormation");
        else if (Input.GetKeyDown("x"))
            SquareFormation();
        else if(Input.GetKeyDown("v"))
            Debug.Log("DeltaFormation");
    }

	//MÉTODOS

    public void initializeSpartanPos()
    {
        float col = numSpartan / filas;   //filas es una constante que vale 9, ya que siempre queremos 9 filas.
        Vector3 spartPos = new Vector3((col * dist) * 0.5f, (filas * dist)*0.5f, 0.0f); //calculamos la posición del primer espartano.
        Vector3 cont = new Vector3(0.0f,0.0f,0.0f); //creamos un contador de tipo vector.

        for (int i = 0,j = 0;i<numSpartan;i++,j++)
        {
            if(j==filas)    //cuando la j llega a 9 es decir a la ultima fila saltamos de columna hacia atrás mediante la variable cont.
            {
                j = 0;
                cont.y = 0.0f;
                cont.z = 0.0f;
                cont.x -= dist;
            }
            SpartanList[i].transform.position = transform.position + spartPos + cont;   //la posición de cada espartano se ve determinada por el centro de la henomotia + la posicion relativa al centro sacada de sumar la posición del primer espartano y el contador. 
            cont.y -= dist;
            cont.z -= 0.1f;
        }
    }

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

    //seleccionar un collider:
    //canvia el nom selectedHenomotia.
    private void OnMouseDown()
    {
        selectedHenomotia = GetComponent<Rigidbody2D>().name;
        Debug.Log(selectedHenomotia);
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

    void OnCollisionStay2D(Collision2D collision)
    {
		for (int i = 0; i < numSpartan; i++) 
		{
            SpartanList[i].GetComponent<Spartan>().setDestiny(new Vector3(0.0f, 0.0f, 0.0f));
		}
	}

    public void SquareFormation()
    {
        Debug.Log("squareFormation");
        float col = numSpartan / filas;   //filas es una constante que vale 9, ya que siempre queremos 9 filas.
        Vector3 spartPos = new Vector3((col * dist) * 0.5f, (filas * dist) * 0.5f, 0.0f); //calculamos la posición del primer espartano.
        Vector3 cont = new Vector3(0.0f, 0.0f, 0.0f); //creamos un contador de tipo vector.

        for (int i = 0, j = 0; i < numSpartan; i++, j++)
        {
            if (j == filas)    //cuando la j llega a 9 es decir a la ultima fila saltamos de columna hacia atrás mediante la variable cont.
            {
                j = 0;
                cont.y = 0.0f;
                cont.x -= dist;
            }
            SpartanList[i].GetComponent<Spartan>().setDestiny((transform.position + spartPos + cont) - (SpartanList[i].transform.position)); 
            cont.y -= dist;
        }
    }

    //public void CircleFormation()
    //{
    //    //Constante radio
    //    const int r = 10;
    //    //Radio de la circunferencia de la henomotia
    //    float radius = r;
    //    //Contador
    //    int i;
    //    //Angulo auxiliar que marca la dirección de los espartanos
    //    float auxAngle = 0;

    //    if (SpartanList.Count == numSpartan)
    //    {
    //        for (i = 0; i < 4; i++, auxAngle += (360 / 4))
    //        {
    //            radius /= 3;
    //            SpartanList[i].moveToPosition((Vector2(radius * Math.Cos(auxAngle), radius * Math.Sin(auxAngle)) + transform.position) - SpartanList[i].transform.position);
    //        }
    //        auxAngle = 0;
    //        radius = r;

    //        for (i = 0; i < 16; i++, auxAngle += (360 / 8))
    //        {
    //            radius /= 3 * 2;
    //            SpartanList[i].moveToPosition((Vector2(radius * Math.Cos(auxAngle), radius * Math.Sin(auxAngle)) + transform.position) - SpartanList[i].transform.position);
    //        }

    //        radius = r;
    //        auxAngle = 45 / 2;
    //        for (i = 0; i < 24; i++, auxAngle += (360 / 8))
    //        {
    //            SpartanList[i].moveToPosition((Vector2(radius * Math.Cos(auxAngle), radius * Math.Sin(auxAngle)) + transform.position) - SpartanList[i].transform.position);
    //        }

    //        auxAngle = 0;
    //        for (i = 0; i < 36; i++, auxAngle += (360 / 16))
    //        {
    //            SpartanList[i].moveToPosition((Vector2(radius * Math.Cos(auxAngle), radius * Math.Sin(auxAngle)) + transform.position) - SpartanList[i].transform.position);
    //        }
    //    }
    //}

}
/*






public void DeltaFormation()
{
    //Constante del tamaño de la henomotia
    const float width = 3;
    const float heigth = 5.5;
    //Divisiones entre espartanos
    int HeigthDivision = heigth / 5.5;
    int WidthDivision = width / 3;
    int z = 0; //Contador de espartanos

    float i, j;

    for (i = heigth, j = -width; z < 11; z++, i - HeigthDivision)
    {
        SpartanList[z].moveToPosition(Vector2(i, j));
    }
    for (i = heigth, j = -width + WidthDivision; z < 20; z++, i - HeigthDivision)
    {
        SpartanList[z].moveToPosition(Vector2(i, j));
    }
    for (i = heigth, j = -width + (WidthDivision * 2); z < 27; z++, i - HeigthDivision)
    {
        SpartanList[z].moveToPosition(Vector2(i, j));
    }
    for (i = heigth, j = -width + (WidthDivision * 3); z < 32; z++, i - HeigthDivision)
    {
        SpartanList[z].moveToPosition(Vector2(i, j));
    }
    for (i = heigth, j = -width + (WidthDivision * 4); z < 35; z++, i - HeigthDivision)
    {
        SpartanList[z].moveToPosition(Vector2(i, j));
    }
    for (i = heigth, j = -width + (WidthDivision * 5); z < 36; z++, i - HeigthDivision)
    {
        SpartanList[z].moveToPosition(Vector2(i, j));
    }
}
*/
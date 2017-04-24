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

        transform.position = new Vector3((Mathf.Floor(Mathf.Sqrt(numSpartan)) * 3.0f)*0.5f, (Mathf.Floor(Mathf.Sqrt(numSpartan)) * 3.0f) * 0.5f, 0.0f);

        destiny = transform.position;
    }

	void Update()
	{
        MoveHenomotia();
	}

	//MÉTODOS

    public void initializeSpartanPos()
    {
        int x = 0;
        int y = 0;
        float posZ = 0.0f;

        for (int i=0; i<numSpartan;i++)
        {
            SpartanList[i].transform.position = new Vector3(x * 3.0f, y * 3.0f,posZ);

            if (x >= Mathf.Floor(Mathf.Sqrt(numSpartan))-1)
            {
                x = -1;
                y++;
                posZ += 1.0f;
            }
            x++;
        }
    }

	public void MoveHenomotia()
	{
        if (Input.GetMouseButtonDown(1))
        {
            destiny = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            destiny = new Vector3(destiny.x, destiny.y, 0.0f);
            vectorDirector = destiny - transform.position;

            for(int i=0; i<numSpartan;i++)
            {
                SpartanList[i].GetComponent<Spartan>().setDestiny(vectorDirector);
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, destiny, speed * Time.deltaTime);
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




/*
public void CircleFormation()
{
	//Constante radio
	const int r= 10;
	//Radio de la circunferencia de la henomotia
	float radius = r;
	//Contador
	int i;
	//Angulo auxiliar que marca la dirección de los espartanos
	float auxAngle = 0;

	if (SpartanList.Count == numSpartan) 
	{
		for(i = 0; i<4;i++ , auxAngle += (360/4))
		{
			radius /= 3;
			SpartanList[i].moveToPosition((Vector2 (radius * Math.Cos (auxAngle), radius * Math.Sin (auxAngle)) + transform.position) - SpartanList[i].transform.position);
		}
		auxAngle = 0;
		radius = r;

		for(i = 0; i<16;i++ , auxAngle += (360/8))
		{
			radius /= 3 * 2;
			SpartanList[i].moveToPosition((Vector2 (radius * Math.Cos (auxAngle), radius * Math.Sin (auxAngle)) + transform.position) - SpartanList[i].transform.position);
		}

		radius = r;
		auxAngle = 45/2;
		for(i = 0; i<24;i++ , auxAngle += (360/8))
		{
			SpartanList[i].moveToPosition((Vector2 (radius * Math.Cos (auxAngle), radius * Math.Sin (auxAngle)) + transform.position) - SpartanList[i].transform.position);
		}

		auxAngle = 0;
		for(i = 0; i<36;i++ , auxAngle += (360/16))
		{
			SpartanList[i].moveToPosition((Vector2 (radius * Math.Cos (auxAngle), radius * Math.Sin (auxAngle)) + transform.position) - SpartanList[i].transform.position);
		}
	}
}



public void SquareFormation()
{
	//Constante del tamaño de la henomotia
	const float width= 4.5;
	const float heigth= 2;
	//Divisiones entre espartanos
	int HeigthDivision = heigth/2;
	int WidthDivision = width/4.5;
	int z = 0; //Contador espartanos


	for (float  i= heigth; i >= -heigth; i -= HeigthDivision) 
	{
		for (float j = -width; j <= width; j += WidthDivision, z++) 
		{
			SpartanList[z].moveToPosition(Vector2(i , j));
		}
	}
}

public void DeltaFormation()
{
	//Constante del tamaño de la henomotia
	const float width= 3;
	const float heigth= 5.5;
	//Divisiones entre espartanos
	int HeigthDivision = heigth/5.5;
	int WidthDivision = width/3;
	int z = 0; //Contador de espartanos

	float i, j;

	for(i=heigth, j=-width; z<11; z++, i-HeigthDivision)
	{
		SpartanList[z].moveToPosition(Vector2(i , j));
	}
	for(i=heigth, j=-width+WidthDivision; z<20; z++, i-HeigthDivision)
	{
		SpartanList[z].moveToPosition(Vector2(i , j));
	}
	for(i=heigth, j=-width+(WidthDivision*2); z<27; z++, i-HeigthDivision)
	{
		SpartanList[z].moveToPosition(Vector2(i , j));
	}
	for(i=heigth, j=-width+(WidthDivision*3); z<32; z++, i-HeigthDivision)
	{
		SpartanList[z].moveToPosition(Vector2(i , j));
	}
	for(i=heigth, j=-width+(WidthDivision*4); z<35; z++, i-HeigthDivision)
	{
		SpartanList[z].moveToPosition(Vector2(i , j));
	}
	for(i=heigth, j=-width+(WidthDivision*5); z<36; z++, i-HeigthDivision)
	{
		SpartanList[z].moveToPosition(Vector2(i , j));
	}
}*/

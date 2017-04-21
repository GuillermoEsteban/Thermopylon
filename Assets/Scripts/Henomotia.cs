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
		numSpartan = 13;

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
        for(int i=0; i<numSpartan;i++)
        {
            SpartanList[i].transform.position = new Vector3(x * 3.0f, y * 3.0f,0.0f);

            if (x >= Mathf.Floor(Mathf.Sqrt(numSpartan))-1)
            {
                x = -1;
                y++;
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

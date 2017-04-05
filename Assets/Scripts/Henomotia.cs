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
	private Formation formation;    //Formación de la henomotia
    private Vector2 direction; //Vector dirección de la henomotia
    public float speed; 
    private Weapon weapon;		//Definimos el arma de la henomotia

	//START
	void Start ()
	{
		numSpartan = 5;

		//Inicializamos la lista henomotia
		SpartanList = new List<GameObject>();
		for(int i=0; i<numSpartan;i++)
		{
			SpartanList.Add((GameObject)Instantiate(Resources.Load("Spartan"), new Vector3(i * 2.0f, 0.0f,0.0f), Quaternion.identity));   
		}

        direction = transform.position;
        speed = 5.0f;
    }

	void Update()
	{
        moveHenomotia();
    }

    //MÉTODOS
    public void moveHenomotia()
    {
        if (Input.GetMouseButtonDown(1))
        {
            direction = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
        }
        for (int i=0;i<numSpartan;i++)
        {
            SpartanList[i].GetComponent<Spartan>().moveToPosition(direction);
        }
        transform.position = Vector2.MoveTowards(transform.position, direction, speed * Time.deltaTime);
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

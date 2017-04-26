using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Henomotia: MonoBehaviour {
	
	//ENUMS
	enum Formation { circle , square , delta }	//Enum de las tres formaciones

    //això ja està en cada espartà!
	enum Weapon { XIPHOS, JAVELIN, ASPIS, SHIELD}	//Enum de las tres armas

	//ATRIBUTOS
	private List<GameObject> SpartanList;	//Lista que alberga todos los espartanos
	private int numSpartan;	//Número de espartanos de la henomotia
	private Formation formation;	//Formación de la henomotia
	private float speed;	//Velocidad de la henomotia
    private Vector3 destiny;
	private Weapon weapon;  //Definimos el arma de la henomotia
    private const int filas =9;
    private const float dist = 3;
    Quaternion hRotation;
    Vector3 destVector;

	private bool enabled = true;

    //SELECCIONAR HENOMOTIA:
    private static string selectedHenomotia;


	//START
	void Start ()
	{
		numSpartan = 36;
        speed = 5.0f;

		gameObject.GetComponent<CircleCollider2D>().enabled = false;
		gameObject.GetComponent<PolygonCollider2D>().enabled = false;
		gameObject.GetComponent<BoxCollider2D>().enabled = true;

        formation = Formation.square;

        //Inicializamos la lista henomotia
        SpartanList = new List<GameObject>();

        for (int i = 0; i < numSpartan; i++)
        {
            
            SpartanList.Add((GameObject)Instantiate(Resources.Load("Spartan_Sprite"), new Vector3(0.0f,0.0f, 0.0f), Quaternion.identity));
            SpartanList[i].transform.parent= transform;
        }

        initializeSpartanPos();

        destiny = transform.position;

        //inicialitzem la Henomotia com la base:
        selectedHenomotia = "Henomotia";

        gameObject.GetComponent<CircleCollider2D>().enabled = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }

	void Update()
	{
        MoveHenomotia();

        if (selectedHenomotia == name)
        {
            if (Input.GetKeyDown("c"))
                CircleFormation();
            else if (Input.GetKeyDown("x"))
                SquareFormation();
            else if (Input.GetKeyDown("v"))
                DeltaFormation();
        }
        updateFormation();
    }

	//MÉTODOS

    public void initializeSpartanPos()
    {
        float col = numSpartan / filas;   //filas es una constante que vale 9, ya que siempre queremos 9 filas.
        Vector3 spartPos = new Vector3((col * dist * 0.5f)-1.8f, ((filas * dist)*0.5f)-1, 0.0f); //calculamos la posición del primer espartano.
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
            SpartanList[i].transform.position= spartPos + cont + transform.position;
            SpartanList[i].GetComponent<Spartan>().setRelativePosition(spartPos + cont);   //la posición de cada espartano se ve determinada por el centro de la henomotia + la posicion relativa al centro sacada de sumar la posición del primer espartano y el contador. 
            cont.y -= dist;
            cont.z -= 0.1f;
        }
    }

	public void MoveHenomotia()
	{
        if (SpartanList[0].GetComponent<Spartan>().getShieldUp()==false && formation != Formation.circle)
        {
            if (correctHenomotia() && Input.GetMouseButtonDown(1))
            {
                destiny = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                destiny = new Vector3(destiny.x, destiny.y, 0.0f);
                //destVector = destiny - transform.position;
                //hRotation = Quaternion.FromToRotation(transform.right,destVector);
                //hRotation = new Quaternion(0.0f, 0.0f, hRotation.z,hRotation.w);      
            }

            transform.rotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);

            transform.position = Vector3.MoveTowards(transform.position, destiny, speed * Time.deltaTime);
            //transform.rotation = Quaternion.RotateTowards(transform.rotation, hRotation, 10 * Time.deltaTime);
        }
    }

    //seleccionar un collider:
    //canvia el nom selectedHenomotia.
    private void OnMouseDown()
    {
        selectedHenomotia = GetComponent<Rigidbody2D>().name;
        Debug.Log(selectedHenomotia);
    }

    public bool correctHenomotia()
    {
        return this.gameObject.name == selectedHenomotia;
    }

	public void ChangeFormation()
	{

	}

	public bool isAlive()
	{
		return true;
	}

    public void SquareFormation()
    {
        formation = Formation.square;

		gameObject.GetComponent<CircleCollider2D>().enabled = false;
		gameObject.GetComponent<PolygonCollider2D>().enabled = false;
		gameObject.GetComponent<BoxCollider2D>().enabled = true; 


        float col = numSpartan / filas;
        Vector3 spartPos = new Vector3((col * dist) * 0.5f, (filas * dist) * 0.5f, 0.0f);
        Vector3 cont = new Vector3(0.0f, 0.0f, 0.0f);
        for (int i = 0, j = 0; i < numSpartan; i++, j++)
        {
            if (j == filas)
            {
                j = 0;
                cont.y = 0.0f;
                cont.x -= dist;
            }
            SpartanList[i].GetComponent<Spartan>().setRelativePosition(spartPos + cont);
            cont.y -= dist;
        }
    }

    public void updateFormation()
    {
        for(int i=0;i<numSpartan;i++)
        {
            SpartanList[i].transform.position = Vector3.MoveTowards(SpartanList[i].transform.position, transform.position + SpartanList[i].GetComponent<Spartan>().getRelativePosition(), speed * Time.deltaTime);
        }
    }

    public void CircleFormation()
    {

        formation = Formation.circle;

        
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
		gameObject.GetComponent<PolygonCollider2D>().enabled = false;
		gameObject.GetComponent<CircleCollider2D>().enabled = true;



        Vector3 relativePosition;
        float radi;
        float angle= 0.0f;
        float threshold1,threshold2,threshold3;
        float n;
        int spartansLeft=0;

        if (numSpartan < 20)
        {
            radi = (numSpartan * 10.0f) / 20.0f;
            n = 360.0f / numSpartan;
            for (int i = 0; i < numSpartan; i++)
            {
                relativePosition = new Vector3(radi * Mathf.Cos(angle * Mathf.Deg2Rad), radi * Mathf.Sin(angle * Mathf.Deg2Rad), 0.0f);
                SpartanList[spartansLeft].GetComponent<Spartan>().setRelativePosition(relativePosition);
                angle = (angle + n) % 360;
                spartansLeft++;
            }
        }
        else
        {
            radi = 10.0f;
            threshold1 = Mathf.Floor((4.0f / 7.0f) * numSpartan);
            n = 360.0f / threshold1;

            for (int i = 0; i < threshold1; i++)
            {
                relativePosition = new Vector3(radi * Mathf.Cos(angle * Mathf.Deg2Rad), radi * Mathf.Sin(angle * Mathf.Deg2Rad), 0.0f);
                SpartanList[spartansLeft].GetComponent<Spartan>().setRelativePosition(relativePosition);
                angle = (angle + n) % 360;
                spartansLeft++;
            }

            radi -= 3;
            threshold2 = Mathf.Floor((1.0f / 2.0f) * threshold1);
            n = 360.0f / threshold2;

            for (int i = 0; i < threshold2; i++)
            {
                relativePosition = new Vector3(radi * Mathf.Cos(angle * Mathf.Deg2Rad), radi * Mathf.Sin(angle * Mathf.Deg2Rad), 0.0f);
                SpartanList[spartansLeft].GetComponent<Spartan>().setRelativePosition(relativePosition);
                angle = (angle + n) % 360;
                spartansLeft++;
            }

            radi -= 3;
            threshold3 = numSpartan - threshold1 - threshold2;
            n = 360.0f / threshold3;

            for (int i = 0; i < threshold3; i++)
            {
                relativePosition = new Vector3(radi * Mathf.Cos(angle * Mathf.Deg2Rad), radi * Mathf.Sin(angle * Mathf.Deg2Rad), 0.0f);
                SpartanList[spartansLeft].GetComponent<Spartan>().setRelativePosition(relativePosition);
                angle = (angle + n) % 360;
                spartansLeft++;
            }
        }
    }


    public void DeltaFormation()
    {
        formation = Formation.delta;

		gameObject.GetComponent<CircleCollider2D>().enabled = false;
		gameObject.GetComponent<BoxCollider2D>().enabled = false;
		gameObject.GetComponent<PolygonCollider2D>().enabled = true;

        Vector3 relativePosition;
        Vector3 frstSpartPos = new Vector3(12.0f, 0.0f , 0.0f);
        Vector3 vectorLeft = new Vector3(-8.0f,6.0f,0.0f);
        Vector3 vectorRight = new Vector3(-8.0f, -6.0f, 0.0f);
        float spartansToPlace = Mathf.Floor(numSpartan / 2.0f);
        float leftSpartans= numSpartan - spartansToPlace;
        float landa = 0.2f;
        int cont = 1;

        relativePosition = frstSpartPos;
        SpartanList[0].GetComponent<Spartan>().setRelativePosition(relativePosition);

        for (int i=0; i<spartansToPlace-1;i++)
        {
            if(i%2==0)
            {
                relativePosition = frstSpartPos + (landa * vectorLeft);
            }
            else
            {
                relativePosition = frstSpartPos + (landa * vectorRight);
                landa += 0.2f;
            }
            SpartanList[cont].GetComponent<Spartan>().setRelativePosition(relativePosition);
            cont++;
        }

        landa = 0.2f;
        spartansToPlace = leftSpartans;
        frstSpartPos = frstSpartPos + new Vector3(-6.0f,0.0f,0.0f);
        relativePosition = frstSpartPos;
        SpartanList[cont].GetComponent<Spartan>().setRelativePosition(relativePosition);
        cont++;

        for (int i=0;i<spartansToPlace-1;i++)
        {
            if (i % 2 == 0)
            {
                relativePosition = frstSpartPos + (landa * vectorLeft);
            }
            else
            {
                relativePosition = frstSpartPos + (landa * vectorRight);
                landa += 0.2f;
            }
            SpartanList[cont].GetComponent<Spartan>().setRelativePosition(relativePosition);
            cont++;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Persian(Clone)")
        {
            foreach (GameObject spartan in SpartanList)
            {
                SpriteRenderer renderer = spartan.GetComponent<SpriteRenderer>();
                renderer.color = new Color(1, 0, 0, 0.5f);
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Persian(Clone)")
        {
            foreach (GameObject spartan in SpartanList)
            {
                SpriteRenderer renderer = spartan.GetComponent<SpriteRenderer>();
                renderer.color = new Color(1, 1, 1, 1);
            }
        }
    }



}

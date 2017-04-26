using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Persian : MonoBehaviour {

    //walk cap a una henomotia:
    private static List<GameObject> HenomotiaList;
    private Vector3 posicioHenomotia;
    private Vector3 posicioHenomotia_comparacio;
    private float persianSpeed;

    Vector3 vectorDirector;
    Vector3 vectorDirector_comparacio;

    Vector3 posicioActual;
    Vector3 posicioAnterior;

    public static float minDistance=10000.0f; 
    private float angle;
    private float posY;
    
    //Canvi de sprites
    public Animator anim;

// Use this for initialization
void Start ()
    {

        HenomotiaList = new List<GameObject>();

        //creem la variable animació per més comoditat:
        anim = GetComponent<Animator>();

        anim.SetBool("moving", false);
        for(int i = 0; i <= 8;i++)
        {
            HenomotiaList.Add(GameObject.Find("Henomotia ("+i.ToString()+")"));
        }

        persianSpeed = .15f; //*Time.deltaTime;

        posicioActual = GetComponent<Rigidbody2D>().transform.position;
        posicioAnterior = GetComponent<Rigidbody2D>().transform.position;
    }
	
	// Update is called once per frame
	void Update ()
    {
        moveToSpartans();
	}

	public void moveToSpartans()
	{
        closestHenomotia();

		if (vectorDirector.magnitude <= minDistance)
		{
			posY = vectorDirector.y;
			//calculem l'angle i canviem l'sprite.
			angle = Vector3.Angle(Vector3.right, vectorDirector.normalized);
			transform.position = Vector3.MoveTowards(posicioActual, posicioHenomotia, persianSpeed);

			posicioActual = transform.position;

			if (posicioActual == posicioAnterior)
			{
				anim.SetBool("moving", false);
			}
			else anim.SetBool("moving", true);

			changeSprite();

			posicioAnterior = GetComponent<Rigidbody2D>().transform.position; 
		}
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

    public void closestHenomotia()
    {
        posicioHenomotia = HenomotiaList[0].transform.position;
        vectorDirector = posicioHenomotia - posicioActual;
        for (int i =1; i <= 8; i++)
        { 
            posicioHenomotia_comparacio = HenomotiaList[i].transform.position;
            vectorDirector_comparacio = posicioHenomotia_comparacio - posicioActual;

            if (vectorDirector.magnitude > vectorDirector_comparacio.magnitude)
            {
                vectorDirector = vectorDirector_comparacio;
                posicioHenomotia = posicioHenomotia_comparacio;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        bool isHenomotia = false;
        for(int i=0; i<=8; i++)
        {
            if (collision.gameObject.name == "Henomotia (" + i.ToString() + ")")
            {
                isHenomotia=true;
            }   
        }
        if (isHenomotia)
        {
            Destroy(gameObject);
        }
        
    }

}
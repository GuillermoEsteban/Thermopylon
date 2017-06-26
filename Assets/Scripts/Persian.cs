using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Persian : MonoBehaviour {

    //walk cap a una henomotia:
    private Vector3 posicioHenomotia;
    private Vector3 posicioHenomotia_comparacio;//l'utilitzarem per comparar les dues posicions.
	public float persianSpeed;//la rapidesa dels perses, pública perquè podem modificar-ho com vulguem.

    Vector3 vectorDirector;//serà el vector que va de la posició de cada persa a la de l'henomotia.
    Vector3 vectorDirector_comparacio;//el comparem amb un altre.

    Vector3 posicioActual;//la posició actual del persa
    Vector3 posicioAnterior;//la posició al frame anterior

    public static float minDistanceHenomotia=100.0f; //la distància mínima en què el persa anirà cap a l'enomotia
    public static float minDistanceSpartan = 10.0f; //la distància mínima en què el persa anirà cap als espartans
    private float angle;//angle de l'eix x al vector de moviment de cada persa
    private float posY;//si el persa va amunt en l'eix de les y o avall.


    //walk cap a un espartà:
    private int numberHenomotia;

	private Rigidbody2D rb;
    
    //Canvi de sprites
    public Animator anim;//variable de l'animator per a poder-hi accedir.

// Use this for initialization
void Start ()
    {
        anim = GetComponent<Animator>(); //agafem l'Animator propi de cada persa.

        anim.SetBool("moving", false); //comencen sense moure's.
        anim.SetBool("death", false);
        anim.SetBool("attack", false);

        persianSpeed = 300; //inicialitzem la velocitat dels perses a 300, però està subjecte a canvis.

        posicioActual = GetComponent<Rigidbody2D>().transform.position;//adquirim la posició del rigidbody, que serà la mateixa per l'actual i l'anterior.
        posicioAnterior = GetComponent<Rigidbody2D>().transform.position;

		rb = GetComponent<Rigidbody2D>();

        //inicialitzem el número de la henomotia: per defecte serà la 0 la que està més aprop.
        numberHenomotia = 0;
        vectorDirector=new Vector3(1000,1000,1000);
    }
	
	void FixedUpdate ()
    {
        if (SpartanArmy.HenomotiaList.Count != 0)
        {
           moveTo();
        }
       
	}

	private void moveTo()
	{
        if (vectorDirector.magnitude <= minDistanceSpartan && SpartanArmy.HenomotiaList[numberHenomotia].gameObject.transform.name=="Henomotia ("+numberHenomotia.ToString() + ")")
        {
            closestSpartan();
        }
        else
        {
            closestHenomotia();
        }
        
		if (vectorDirector.magnitude <= minDistanceHenomotia)//si la distància del persa a la henomotia és més petita que la distància que li hem definit:
		{
			posY = vectorDirector.y;//agafem la y d'aquest vector per a saber si és positiu o negatiu.
			angle = Vector3.Angle(Vector3.right, vectorDirector.normalized);//calculem l'angle, que va del vector cap a la dreta al vectorDirector normalitzat (unitari)

			//rb.MovePosition(posicioActual + (posicioHenomotia - posicioActual).normalized * Time.deltaTime * 10);
            if(SpartanArmy.HenomotiaList[numberHenomotia].gameObject.transform.name == "Henomotia (" + numberHenomotia.ToString() + ")")
			    rb.velocity = ((posicioHenomotia - posicioActual).normalized * Time.deltaTime * persianSpeed);

			posicioActual = GetComponent<Rigidbody2D>().transform.position;//la posició actual del rigidbody.

			if (posicioActual == posicioAnterior)// si és la mateixa, aleshores vol dir que no s'ha mogut i per tant la variable moving és falsa.
			{
				anim.SetBool("moving", false);
			}
			else anim.SetBool("moving", true);//sinó, és que es mou.

			changeSprite();//canviem l'sprite ara que sabem les dades 'angle', 'posY' i 'moving'.

			posicioAnterior = GetComponent<Rigidbody2D>().transform.position; //un cop hem fet el que volíem, tornem a agafar la posició actual com a l'anterior per tornar a entrar el loop.
		}
	}
    //funció per canviar la imatge de l'sprite segons l'angle:
    private void changeSprite()
    {
        if (anim.GetBool("moving")){ //sempre que no s'estigui movent:
            if (angle < 22.5f)//aquesta funció bàsicament utilitza la variable 'angle' per a posar un booleà de l'animator true o false. En cada if posarem un true i la resta false.
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
            else if (112.5f <= angle && angle < 157.5f && posY < 0)//la vuitena posició
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

    
    private void closestSpartan()
    {
        bool first_pass = true;
        List<GameObject> closest_henomotia = new List<GameObject>();
        closest_henomotia.AddRange(SpartanArmy.HenomotiaList[numberHenomotia].GetComponent<Henomotia>().SpartanList);
       
        foreach (GameObject spartan in closest_henomotia)
        {
            if (spartan != null)
            {
                if (first_pass)
                {
                    posicioHenomotia = closest_henomotia[0].GetComponent<Rigidbody2D>().transform.position;//primer la posició de l'espartà és la del 0.
                    vectorDirector = posicioHenomotia - posicioActual;
                    first_pass = false;
                }
                posicioHenomotia_comparacio = spartan.transform.position;//fem el mateix per a les comparacions per a cada henomotia.
                vectorDirector_comparacio = posicioHenomotia_comparacio - posicioActual;

                if (vectorDirector.magnitude > vectorDirector_comparacio.magnitude)//si la distància entre l'henomotia inicial és més gran que la de la comparació:
                {
                    vectorDirector = vectorDirector_comparacio;//aleshores canviem les dues variables per a les de la comparació
                    posicioHenomotia = posicioHenomotia_comparacio;//d'aquesta manera ens quedaran les variables finals com a les més properes a cada persa.
                }
            }
        }
    }

    private void closestHenomotia()//funció per a trobar l'henomotia més propera.
    {
        posicioHenomotia = SpartanArmy.HenomotiaList[0].transform.position;//primer la posició de l'henomotia és la de la 1
        vectorDirector = posicioHenomotia - posicioActual;//el vector serà el de la posició del persa a la henomotia 1
        for (int i =1; i < SpartanArmy.HenomotiaList.Count -1; i++)//per a les 8 següents henomoties:
        { 
            if(SpartanArmy.HenomotiaList[i] != null)
            {
                posicioHenomotia_comparacio = SpartanArmy.HenomotiaList[i].transform.position;//fem el mateix per a les comparacions per a cada henomotia.
                vectorDirector_comparacio = posicioHenomotia_comparacio - posicioActual;

                if (vectorDirector.magnitude > vectorDirector_comparacio.magnitude)//si la distància entre l'henomotia inicial és més gran que la de la comparació:
                {
                    vectorDirector = vectorDirector_comparacio;//aleshores canviem les dues variables per a les de la comparació
                    posicioHenomotia = posicioHenomotia_comparacio;//d'aquesta manera ens quedaran les variables finals com a les més properes a cada persa.
                    numberHenomotia = i;
                }
            } 
        }
    }

    public void death_anim()
    {
        //gameObject.GetComponent<Collider2D>().isTrigger = true;
        gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        anim.SetBool("death", true);
        Invoke("death", 0.5f);
    }
    public void death()
    {
        Instantiate(Resources.Load("deadPersian") as GameObject, gameObject.transform.position + new Vector3(0, 0, 20), gameObject.transform.rotation);
        Destroy(gameObject);
        SpartanArmy.persiansKilled++;
    }

    public void dontAttack()
    {
        anim.SetBool("attack", false);
    }

}
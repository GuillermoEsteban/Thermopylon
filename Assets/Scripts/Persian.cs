using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Persian : MonoBehaviour {

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
        //creem la variable animació per més comoditat:
        anim = GetComponent<Animator>();

        anim.SetBool("moving", false);
        henomotia = GameObject.Find("Henomotia");
        henomotia_1 = GameObject.Find("Henomotia(1)");

        //persianSpeed = .15f; //*Time.deltaTime;

        posicioActual = transform.position;
        posicioAnterior = transform.position;
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
            posicioHenomotia = posicioHenomotia_comparacio;
        }
        if (vectorDirector.magnitude <= minDistance)
        {
            posY = vectorDirector.y;
            //calculem l'angle i canviem l'sprite.
            angle = Vector3.Angle(Vector3.right, vectorDirector.normalized);
            transform.position = Vector2.MoveTowards(posicioActual, posicioHenomotia, persianSpeed);

            posicioActual = transform.position;

            if (posicioActual == posicioAnterior)
            {
                anim.SetBool("moving", false);
            }
            else anim.SetBool("moving", true);

            changeSprite();

            posicioAnterior = transform.position; 
        }
    }
}

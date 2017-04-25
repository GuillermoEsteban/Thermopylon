﻿using UnityEngine;
using System.Collections;
using System;



public class Spartan : MonoBehaviour {

    // Use this for initialization
    //MOVIMENT**********************************
	private Vector3 destiny;
    public float speed;
    //angles:
    private float angle;
    private Vector3 vectorDirector;
    private Vector3 puntAnterior;
    private Vector3 puntNou;
    private float posY;
    //Canvi de sprites
    public Animator anim;

    //ATTACKS***********************************
    private  enum Weapon { XIPHOS, JAVELIN, ASPIS, SHIELD}
    Weapon myWeapon;
    

	void Start ()
    {
		destiny=transform.position;
        speed = 5.0f;

        //obtenim el punt inicial:
        puntAnterior = transform.position;
        puntNou = transform.position;

        //l'arma per defecte serà l'Aspis, la llança.
        myWeapon = Weapon.ASPIS;

        //creem la variable animació per més comoditat:
        anim = GetComponent<Animator>();
        
        anim.SetBool("moving", false);
    }
	
	// Update is called once per frame
	void Update ()
    {
		moveToPosition();
        //Press S for shield, D for Javelin, A for Aspis, W for Xiphos
        //changeWeapon();

	}

	public void moveToPosition()
	{
		if (Input.GetMouseButtonDown (1))
		{
            vectorDirector = (destiny - puntAnterior);
            posY = vectorDirector.y;
            //calculem l'angle i canviem l'sprite.
            angle = Vector3.Angle(Vector3.right, vectorDirector.normalized);
        }

        transform.position = Vector3.MoveTowards(transform.position, destiny, speed * Time.deltaTime);  //movemos el espartano a la posición definida en destiny.
        puntNou = transform.position;

        if (puntNou == puntAnterior)
        {
            anim.SetBool("moving", false);
        }
        else anim.SetBool("moving", true);

        changeSprite(angle, posY);


        puntAnterior = transform.position;
    }

    public void setDestiny(Vector3 direction)   //calcula la posición destino del espartano sumando el vector entrante a la posición relativa del espartano.
    {
        destiny = transform.position + direction;
    }

    public Vector3 getDestiny()
    {
        return destiny;
    }

    //funció per canviar la imatge de l'sprite segons l'angle:
     public void changeSprite(float angle, float posY)
    {
        if(angle<22.5f && anim.GetBool("moving"))
        {
                anim.SetBool("anim0", false);
                anim.SetBool("anim1", false);
                anim.SetBool("anim2", true);
                anim.SetBool("anim3", false);
                anim.SetBool("anim4", false);
                anim.SetBool("anim5", false);
                anim.SetBool("anim6", false);
                anim.SetBool("anim7", false);
        }
        else if(22.5f<=angle && angle<67.5f && posY>0 && anim.GetBool("moving"))
        {
                anim.SetBool("anim0", false);
                anim.SetBool("anim1", false);
                anim.SetBool("anim2", false);
                anim.SetBool("anim3", true);
                anim.SetBool("anim4", false);
                anim.SetBool("anim5", false);
                anim.SetBool("anim6", false);
                anim.SetBool("anim7", false);
        }
        else if (67.5f <= angle && angle < 112.5f && posY > 0 && anim.GetBool("moving"))
        {

                anim.SetBool("anim0", false);
                anim.SetBool("anim1", false);
                anim.SetBool("anim2", false);
                anim.SetBool("anim3", false);
                anim.SetBool("anim4", true);
                anim.SetBool("anim5", false);
                anim.SetBool("anim6", false);
                anim.SetBool("anim7", false);  
        }
        else if (112.5f <= angle && angle < 157.5f && posY > 0 && anim.GetBool("moving"))
        {
                anim.SetBool("anim0", false);
                anim.SetBool("anim1", false);
                anim.SetBool("anim2", false);
                anim.SetBool("anim3", false);
                anim.SetBool("anim4", false);
                anim.SetBool("anim5", true);
                anim.SetBool("anim6", false);
                anim.SetBool("anim7", false);
        }
        else if (angle>157.5f && anim.GetBool("moving"))
        {
                anim.SetBool("anim0", false);
                anim.SetBool("anim1", false);
                anim.SetBool("anim2", false);
                anim.SetBool("anim3", false);
                anim.SetBool("anim4", false);
                anim.SetBool("anim5", false);
                anim.SetBool("anim6", true);
                anim.SetBool("anim7", false);
        }
        else if (22.5f <= angle && angle < 67.5f && posY < 0 && anim.GetBool("moving"))
        {
                anim.SetBool("anim0", false);
                anim.SetBool("anim1", true);
                anim.SetBool("anim2", false);
                anim.SetBool("anim3", false);
                anim.SetBool("anim4", false);
                anim.SetBool("anim5", false);
                anim.SetBool("anim6", false);
                anim.SetBool("anim7", false);
        }
        else if (67.5f <= angle && angle < 112.5f && posY < 0 && anim.GetBool("moving"))
        {

                anim.SetBool("anim0", true);
                anim.SetBool("anim1", false);
                anim.SetBool("anim2", false);
                anim.SetBool("anim3", false);
                anim.SetBool("anim4", false);
                anim.SetBool("anim5", false);
                anim.SetBool("anim6", false);
                anim.SetBool("anim7", false);
        }
        else if (112.5f <= angle && angle < 157.5f && posY < 0 && anim.GetBool("moving"))
        {
                anim.SetBool("anim0", false);
                anim.SetBool("anim1", false);
                anim.SetBool("anim2", false);
                anim.SetBool("anim3", false);
                anim.SetBool("anim4", false);
                anim.SetBool("anim5", false);
                anim.SetBool("anim6", false);
                anim.SetBool("anim7", true);
        }
    }


   private void changeWeapon()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myWeapon = Weapon.SHIELD;
            Debug.Log(myWeapon);
        }
        else if (Input.GetKey("a"))
        {
            myWeapon = Weapon.ASPIS;
            Debug.Log(myWeapon);
        }
        else if (Input.GetKey("w"))
        {
            myWeapon = Weapon.XIPHOS;
            Debug.Log(myWeapon);
        }
        else if (Input.GetKey("d"))
        {
            myWeapon = Weapon.JAVELIN;
            Debug.Log(myWeapon);
        } 
    }

   
        
        
     
    
    //Aquesta funció donarà errors de moment, ja que s'ha d'implementar la classe dels Perses i també buscar com tractar els colliders.

/*
    bool inContact(Spartan Spartan, PersianClass Persian)
    {
        if (true)//colliders
        {
            return true;
        }
    }
*/

}


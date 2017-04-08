

using UnityEngine;
using System.Collections;
using System;



public class Spartan : MonoBehaviour {

    // Use this for initialization
    //MOVIMENT**********************************
	private Vector2 direction;
    public float speed;
    //angles:
    float angle;
    private Vector2 vectorDirector;
    private Vector2 puntAnterior;
    private Vector2 puntNou;
    float posY;
    //Canvi de sprites
    public Animator anim;
    private bool moving;

    //ATTACKS***********************************
    private  enum Weapon { XIPHOS, JAVELIN, ASPIS, SHIELD}
    Weapon myWeapon;
    

	void Start ()
    {
		direction=transform.position;
        speed = 5.0f;

        //obtenim el punt inicial:
        puntAnterior = transform.position;
        puntNou = transform.position;

        //l'arma per defecte serà l'Aspis, la llança.
        myWeapon = Weapon.ASPIS;

        //creem la variable animació per més comoditat:
        anim = GetComponent<Animator>();
        moving = false;
        anim.SetBool("moving", false);
    }
	
	// Update is called once per frame
	void Update ()
    {
		moveToPosition();
        //Press S for shield, D for Javelin, A for Aspis, W for Xiphos
        changeWeapon();

	}

	public void moveToPosition()
	{
		if (Input.GetMouseButtonDown (1))
		{
			direction = Camera.main.ScreenToWorldPoint (Input.mousePosition);
            

            vectorDirector = (direction - puntAnterior);
            posY = vectorDirector.y;
            //calculem l'angle i canviem l'sprite.
            angle = Vector2.Angle(Vector2.right, vectorDirector.normalized);
        }

        transform.position = Vector2.MoveTowards(transform.position, direction, speed * Time.deltaTime);
        puntNou = transform.position;

        if (puntNou == puntAnterior)
        {
            anim.SetBool("moving", false);
        }
        else anim.SetBool("moving", true);

        changeSprite(angle, posY);


        puntAnterior = transform.position;
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
        if (Input.GetKey("s"))
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


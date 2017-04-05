

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
    float posY;
    //Canvi de sprites
    private SpriteRenderer spriteR;
    private Sprite[] sprites;

    //ATTACKS***********************************
    private  enum Weapon { XIPHOS, JAVELIN, ASPIS, SHIELD}
    //Weapon at start is the spear (aspis)
    Weapon myWeapon;
    

	void Start ()
    {
		direction=transform.position;
        speed = 5.0f;

        //obtenim el punt inicial:
        puntAnterior = transform.position;

        //get first sprite:
        spriteR = gameObject.GetComponent<SpriteRenderer>();
        sprites = Resources.LoadAll<Sprite>("Sprites/spartans_walking");


       myWeapon = Weapon.ASPIS;
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
            
            changeSprite(angle,posY);

		}
		transform.position = Vector2.MoveTowards (transform.position, direction, speed * Time.deltaTime);
        puntAnterior = transform.position;
    }

    //funció per canviar la imatge de l'sprite segons l'angle:
     public void changeSprite(float angle, float posY)
    {
        if(angle<22.5f)
        {
            spriteR.sprite = sprites[2];
        }
        else if(22.5f<=angle && angle<67.5f && posY>0)
        {
            spriteR.sprite = sprites[3];
        }
        else if (67.5f <= angle && angle < 112.5f && posY > 0)
        {
            spriteR.sprite = sprites[4];
        }
        else if (112.5f <= angle && angle < 157.5f && posY > 0)
        {
            spriteR.sprite = sprites[5];
        }
        else if (angle>157.5f)
        {
            spriteR.sprite = sprites[6];
        }
        else if (22.5f <= angle && angle < 67.5f && posY < 0)
        {
            spriteR.sprite = sprites[1];
        }
        else if (67.5f <= angle && angle < 112.5f && posY < 0)
        {
            spriteR.sprite = sprites[0];
        }
        else if (112.5f <= angle && angle < 157.5f && posY < 0)
        {
            spriteR.sprite = sprites[7];
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


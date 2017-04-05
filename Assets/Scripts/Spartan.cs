

using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

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
    private enum Weapon { XIPHOS, JAVELIN, ASPIS, SHIELD}
    private Weapon myWeapon;

    private const int N_HOPLITES_ROW = 9;

	void Start ()
    {
		direction=transform.position;
        speed = 5.0f;

        //obtenim el punt inicial:
        puntAnterior = transform.position;

        //get first sprite:
        spriteR = gameObject.GetComponent<SpriteRenderer>();
        sprites = Resources.LoadAll<Sprite>("Sprites/spartans_walking");

       /* for(int i=0;i<N_HOPLITES_ROW; ++i)
        {
            mov[i] = XIPHOS;
        }*/
    }
	
	// Update is called once per frame
	void Update ()
    {
		moveToPosition();
        
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
    static int numberSprites = 8;
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

   

    /*
    void changeSword()
    {
        //primer provarem amb un input que després haurem de canviar.
        if(Input.GetKeyDown(KeyCode.S))
        {
            sword = true;
            Debug.Log("SOWRD ON");
            //aquí haurem de cridar la funció d'animàtica perq canviin l'arma i continuin lluitant amb les animacions de l'espasa.
        }
    }

    void changeSpear()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            spear = true;
            Debug.Log("SPEAR ON");
        }
    }

    void changeShield()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            shield = true;
            Debug.Log("SHIELD ON");
        }
    }
    
    //Aquesta funció donarà errors de moment, ja que s'ha d'implementar la classe dels Perses i també buscar com tractar els colliders.

    bool inContact(Spartan Spartan, PersianClass Persian)
    {
        if (true)//colliders
        {
            return true;
        }
    }
*/

}




using UnityEngine;
using System.Collections;
using System;

public class Spartan : MonoBehaviour {

    // Use this for initialization
    //MOVIMENT**********************************
	private Vector2 direction;
    public float speed;

    //ATTACKS***********************************
    private enum Weapon { XIPHOS, JAVELIN, ASPIS, SHIELD}
    private Weapon myWeapon;

    private const int N_HOPLITES_ROW = 9;

	void Start ()
    {
        //Debug.Log("Per provar els canvis d'arma: SWORD (S), SPEAR (D) SHIELD(F)");
		direction=transform.position;
        speed = 2.0f;

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

		}
		transform.position = Vector2.MoveTowards (transform.position, direction, speed * Time.deltaTime);	
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


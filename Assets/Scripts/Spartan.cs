

using UnityEngine;
using System.Collections;
using System;

public class Spartan : MonoBehaviour {

    // Use this for initialization
    //MOVIMENT**********************************
    float xPos,yPos;
    private float[] direction;
    public float speed;

    //ATTACKS***********************************
    private enum Weapon { XIPHOS, JAVELIN, ASPIS, SHIELD}
    private Weapon myWeapon;

    public Movement mov;//Hauríem de saber com tractar directament la instància dels espartans ja creats, o sinó crear-los aquí mateix!
    private const int N_HOPLITES_ROW = 9;

	void Start ()
    {
        Debug.Log("Per provar els canvis d'arma: SWORD (S), SPEAR (D) SHIELD(F)");
        direction = new float[2];
        speed = 0.5f;

       /* for(int i=0;i<N_HOPLITES_ROW; ++i)
        {
            mov[i] = XIPHOS;
        }*/
    }
	
	// Update is called once per frame
	void Update ()
    {
	    if(Input.GetMouseButtonDown(0))
        {
            moveToPosition(Input.mousePosition.x, Input.mousePosition.y);
        }
	}

    public void moveToPosition(float x, float y)
    {
        float modulo;
        direction[0] = x - xPos;
        direction[1] = y - yPos;
        modulo = (float)Math.Sqrt(Math.Pow(direction[0], 2) + Math.Pow(direction[1], 2));
    }

    float getPositionX()
    {
        return xPos;
    }

    float getPositionY()
    {
        return yPos;
    }

    void setPositionX(float x)
    {
        xPos = x;
    }

    void setPositionY(float y)
    {
        yPos = y;
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


}


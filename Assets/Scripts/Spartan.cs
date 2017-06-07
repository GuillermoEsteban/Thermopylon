using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


public class Spartan : MonoBehaviour {

    // Use this for initialization
    //MOVIMENT**********************************
	private Vector3 destiny;
    public float speed;
    private Vector3 relativePosition;

    //angles:
    private float angle;
    private Vector3 vectorDirector;
    private Vector3 puntAnterior;
    private Vector3 puntNou;
    private float posY;

    //Canvi de sprites
    private Animator anim;
    private float randomTime;

    //ATTACKS***********************************
    private  enum Weapon { XIPHOS, JAVELIN, ASPIS, SHIELD}
    Weapon myWeapon;

    //escut:
    private bool firstShield;

    //parent henomotia:
    public Henomotia henomotia;


    void Start ()
    {
        //obtenim el punt inicial:
        puntAnterior = transform.parent.position;
        puntNou = transform.parent.position;

        //l'arma per defecte serà l'Aspis, la llança.
        myWeapon = Weapon.ASPIS;

        //creem la variable animació per més comoditat:
        anim = GetComponent<Animator>();
        anim.speed = Random.Range(0.9f, 1.0f);

        anim.SetBool("moving", false);
        anim.SetBool("shieldUp", false);
        anim.SetBool("arrow_death", false);
        anim.SetBool("anim2", true);
        //anim.SetBool("attack", false);
        

        //inicialització escut:
        firstShield = false;

        //busquem la henomotia del parent de l'espartà per a després poder saber si és la que l'usuari controla.
        henomotia = gameObject.GetComponentInParent<Henomotia>();

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (henomotia.correctHenomotia())
        {
            AngleUpdate();
            changeWeapon();
        }
    }

	public void AngleUpdate()
	{
        //només si no s'utilitza l'escut s'hauria de poder caminar:
        if (anim.GetBool("shieldUp") == false && anim.GetBool("arrow_death")==false)
        {
            if (Input.GetMouseButtonDown (1))
		    {
                destiny = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                destiny = new Vector3(destiny.x, destiny.y,0.0f);
                vectorDirector = (destiny - puntAnterior);
                posY = vectorDirector.y;
                //calculem l'angle
                angle = Vector3.Angle(Vector3.right, vectorDirector.normalized);
            }

            puntNou = transform.parent.position;

            if (puntNou == puntAnterior)
            {
                anim.SetBool("moving", false);
            }
            else anim.SetBool("moving", true);

            changeSprite(angle, posY);
            puntAnterior = puntNou;
        }

        else if (anim.GetBool("shieldUp") == true)
        {
            //Component.GetComponent<Rigidbody2D>().RigidbodyConstraints2D.FreezeAll;
        }
    }

    public void setRelativePosition(Vector3 relativePosition)
    {
        this.relativePosition = relativePosition;
    }

    public Vector3 getRelativePosition()
    {
        return relativePosition;
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
        if (Input.GetKeyDown(KeyCode.Space) && firstShield == false)
        {
            myWeapon = Weapon.SHIELD;
            anim.SetBool("shieldUp", true);
            firstShield = true;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && firstShield == true)
        {
            myWeapon = Weapon.ASPIS;
            anim.SetBool("shieldUp", false);
            firstShield = false;
        }

        else if (Input.GetKey("1"))
        {
            myWeapon = Weapon.ASPIS;
            Debug.Log(myWeapon);
        }
        else if (Input.GetKey("2"))
        {
            myWeapon = Weapon.XIPHOS;
            Debug.Log(myWeapon);
        }
        else if (Input.GetKey("3"))
        {
            myWeapon = Weapon.JAVELIN;
            Debug.Log(myWeapon);
        }
    }
		
    //retorna si està amb els escuts o no:
    public bool getShieldUp()
    {
        return anim.GetBool("shieldUp");
    }


    public void setArrowDeath()
    {
        anim.SetBool("arrow_death", true);
    }

    public void dontAttack()
    {
        anim.SetBool("attack", false);
    }

    public void die()
    {
        List<GameObject> auxList= transform.parent.GetComponent<Henomotia>().SpartanList;
        //int counter = 0;

        //auxList.Last().GetComponent<Spartan>().setRelativePosition(relativePosition);

        //while (auxList[counter].GetInstanceID() != gameObject.GetInstanceID() && counter<auxList.Count)
        //    counter++;

        //auxList[counter] = auxList.Last();

        transform.parent.GetComponent<Henomotia>().numSpartan--;
        transform.parent.parent.GetComponent<SpartanArmy>().totalNumSpartans--;
        Instantiate(Resources.Load("deadSpartanByArrow") as GameObject, gameObject.transform.position + new Vector3(0,0,10), gameObject.transform.rotation);
        Destroy(gameObject);
        auxList.Remove(gameObject);
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour {
    //variables per moure les fletxes:
    private GameObject selectedHenomotia;
    private Vector3 henomotiaPosition;
    public float arrowSpeed;

    //variables per l'animació:
    private Animator anim;
    float timePassed;
    private bool inPosition;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        arrowSpeed = 60.0f;
        StartArrows();
    }
	
	// Update is called once per frame
    void FixedUpdate()
    {
        timePassed += Time.deltaTime;
    }
	void Update () {
        moveArrows();
        if (inPosition)
        {
            anim.SetBool("shadow", false);
            if (timePassed >= 1.0f )
            {
                transform.position = new Vector3(henomotiaPosition.x, henomotiaPosition.y, 2);
            }
            if (timePassed >= Random.Range(5.0f, 6.0f))
            {
                StartArrows();  
            }
        }
    }

    private void StartArrows()
    {
        selectedHenomotia = GameObject.Find("Henomotia (" + Random.Range(0, 9).ToString() + ")");
        henomotiaPosition = selectedHenomotia.transform.position;

        transform.position = henomotiaPosition + new Vector3(Random.Range(200, 400), Random.Range(-50, 50), -1);

        timePassed = 0.0f;
        anim.SetBool("shadow", true);
        inPosition = false;
    }

    private void moveArrows()
    {
        anim.SetFloat("position", (transform.position - henomotiaPosition).magnitude);

        transform.position = Vector3.MoveTowards(transform.position, henomotiaPosition + new Vector3(0, 0, -1), arrowSpeed * Time.deltaTime);

        if (transform.position == henomotiaPosition + new Vector3(0, 0, -1))
        {
            inPosition = true;
        }
    }

    void OnTriggerStay2D(Collider2D collision)//per què no entra?
    {

        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.tag == "spartan" && !collision.gameObject.GetComponent<Spartan>().getShieldUp())
        {
            Debug.Log(timePassed);

            if(timePassed  >= 0.70f  && timePassed < 4.0f )
            {
                Debug.Log("asdghbag");
                //collision.gameObject.GetComponent<Spartan>().setArrowDeath();
            }
            else if(timePassed >= 4.5f  && timePassed < 4.7f )
            {
                Instantiate(Resources.Load("deadSpartanByArrow") as GameObject,collision.transform);
                Destroy(collision.gameObject);
            }
        }
    }

}

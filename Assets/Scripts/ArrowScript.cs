using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour {
    //variables per moure les fletxes:
    private GameObject selectedHenomotia;
    private Henomotia henomotia;
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
	void Update () {
        moveArrows();

        if (inPosition)
        {
            timePassed += 0.01f;
            if (timePassed*Time.deltaTime >= 0.5f*Time.deltaTime)
            {
                detectSpartans();
            }
            else if (timePassed*Time.deltaTime >= 1.0f*Time.deltaTime)
            {
                transform.position = new Vector3(henomotiaPosition.x, henomotiaPosition.y, 2);
            }
            if (timePassed * Time.deltaTime >= Random.Range(50f, 100f) * Time.deltaTime)
            {
                anim.SetBool("disappear", true);//per què no entra?
                StartArrows();
            }
        }
        
    }

    private void StartArrows()
    {
        selectedHenomotia = GameObject.Find("Henomotia (" + Random.Range(0, 9).ToString() + ")");
        henomotia = selectedHenomotia.GetComponent<Henomotia>();//per detectar els espartans dins l'henomotia
        henomotiaPosition = selectedHenomotia.transform.position;

        transform.position = henomotiaPosition + new Vector3(Random.Range(200, 400), Random.Range(-50, 50), -1);

        timePassed = 0.0f;
        anim.SetBool("disappear", false);
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

    private void detectSpartans()
    {
        foreach (GameObject spartan in henomotia.SpartanList)
        {

        }
    }

}

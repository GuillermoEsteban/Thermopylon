using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spartan_Left : MonoBehaviour {

    private Animator anim;
    public bool endCollision;
    public bool coRoutineOn;

    void Start ()
    {
        anim = this.gameObject.GetComponentInParent<Animator>();
        endCollision = false;
        coRoutineOn = false;
    }
	
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "persian")
        {
            gameObject.GetComponentInParent<Spartan>().colliding = true;
            endCollision = false;

            if (anim.GetBool("anim7")==true || anim.GetBool("anim6") == true || anim.GetBool("anim5") == true)
            {
                anim.SetBool("attack", true);
                collider.gameObject.GetComponent<Persian>().Invoke("death_anim", .1f);
                this.gameObject.GetComponentInParent<Spartan>().Invoke("dontAttack", .5f);

                //if (!coRoutineOn)
                //    StartCoroutine(clearForce());
            }
            else
            {
                collider.gameObject.GetComponent<Animator>().SetBool("attack", true);
                collider.gameObject.GetComponent<Persian>().Invoke("dontAttack", .5f);
                Invoke("Destroy", 0.25f);
            }
        } 
    }

    //private void OnTriggerExit2D(Collider2D collider)
    //{
    //    if (collider.gameObject.tag == "persian")
    //    {
    //        gameObject.GetComponentInParent<Spartan>().colliding = false;
    //        endCollision = true;
    //    }
    //}

    private void Destroy()
    {
        transform.parent.GetComponent<Spartan>().die();
    }

    //private IEnumerator clearForce()
    //{
    //    if (!coRoutineOn)
    //        coRoutineOn = true;

    //    while (!endCollision) ;

    //    transform.parent.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
    //    transform.parent.GetComponent<Rigidbody2D>().angularVelocity = 0.0f;

    //    coRoutineOn = false;

    //    yield return null;
    //}
}

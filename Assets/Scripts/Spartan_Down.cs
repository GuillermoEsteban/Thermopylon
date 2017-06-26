using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spartan_Down : MonoBehaviour {

    private Animator anim;
    public bool endCollision;
    public bool coRoutineOn;

    void Start()
    {
        anim = transform.parent.gameObject.GetComponent<Animator>();
        endCollision = false;
        coRoutineOn = false;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "persian")
        {
            gameObject.GetComponentInParent<Spartan>().colliding = true;
            endCollision = false;

            if (anim.GetBool("anim1") == true || anim.GetBool("anim0") == true || anim.GetBool("anim7") == true)
            {
                anim.SetBool("attack", true);
                collider.gameObject.GetComponent<Persian>().Invoke("death", 0.5f);
                gameObject.GetComponentInParent<Spartan>().Invoke("dontAttack", 0.5f);

                //if (!coRoutineOn)
                //    StartCoroutine(clearForce());
            }
            else
            {
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

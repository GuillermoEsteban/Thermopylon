using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spartan_Down : MonoBehaviour {

    private Animator anim;

    void Start()
    {
        anim = transform.parent.gameObject.GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "persian")
        {
            if (anim.GetBool("anim1") == true || anim.GetBool("anim0") == true || anim.GetBool("anim7") == true)
            {
                anim.SetBool("attack", true);
                collider.gameObject.GetComponent<Persian>().Invoke("death", 0.5f);
                gameObject.GetComponentInParent<Spartan>().Invoke("dontAttack", 0.5f);
            }
            else
            {
                Invoke("Destroy", 0.25f);
            }
        } 
    }

    private void Destroy()
    {
        transform.parent.parent.GetComponent<Henomotia>().numSpartan--;
        transform.parent.parent.parent.GetComponent<SpartanArmy>().totalNumSpartans--;
        transform.parent.parent.GetComponent<Henomotia>().SpartanList.Remove(transform.parent.gameObject);
        Destroy(transform.parent.gameObject);
    }
}

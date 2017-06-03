using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spartan_Up : MonoBehaviour {

    private Animator anim;

    void Start()
    {
        anim = this.gameObject.GetComponentInParent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "persian")
        {
            if (anim.GetBool("anim3") == true || anim.GetBool("anim4") == true || anim.GetBool("anim5") == true)
            {
                anim.SetBool("attack", true);
                collider.gameObject.GetComponent<Persian>().Invoke("death", .5f);
                this.gameObject.GetComponentInParent<Spartan>().Invoke("dontAttack", .5f);
            }
            else
            {
                this.transform.parent.gameObject.GetComponentInParent<Henomotia>().deleteSpartanList(this.transform.parent.gameObject);
                Invoke("Destroy", .25f);         }
        }
    }
    private void Destroy()
    {
        Destroy(this.transform.parent.gameObject);
    }
}


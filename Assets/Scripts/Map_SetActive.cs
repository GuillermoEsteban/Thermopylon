using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map_SetActive : MonoBehaviour {
    private bool collided;
    private float x;
    private float y;

    private string nextTag;
	// Use this for initialization
	void Awake () {
        collided = false;
         x= GameObject.Find("NewMap").GetComponent<RandomMap2>().getLimitX();
         y= GameObject.Find("NewMap").GetComponent<RandomMap2>().getLimitY();
        nextTag = RandomMap2.stringTag;
    }
	
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "spartan" && !collided)
        {
            GameObject[] persian_armies = GameObject.FindGameObjectsWithTag(nextTag);
            foreach(GameObject map in persian_armies)
            {
                foreach(Transform army in map.transform)
                {
                    army.gameObject.SetActive(true);
                }
            }
            CameraController2.limitX = x;
            CameraController2.limitY = y;
            collided = true;
        }
    }
}

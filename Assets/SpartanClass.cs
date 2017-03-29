using UnityEngine;
using System.Collections;
using System;

public class SpartanClass : MonoBehaviour {

    // Use this for initialization
    float xPos,yPos;
    float[] direction;
    float speed;


    void Start ()
    {
        direction = new float[2];
        speed = 0.5f;
    }
	
	// Update is called once per frame
	void Update ()
    {
	    if(Input.GetMouseButtonDown(0))
        {
            moveToPosition(Input.mousePosition.x, Input.mousePosition.y);
        }
	}

    void moveToPosition(float x, float y)
    {
        float modulo;
        direction[0] = x - xPos;
        direction[1] = y - yPos;
        modulo = (float)Math.Sqrt(Math.Pow(direction[0],2)+ Math.Pow(direction[1],2));

    }
}

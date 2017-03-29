using UnityEngine;
using System.Collections;

public class SpartanClass : MonoBehaviour {

    // Use this for initialization
    float xPos,yPos;

	void Start ()
    {
	 
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

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuSpartans : MonoBehaviour {

    private float count;
    private float timePassed;
    private int i;
	// Use this for initialization
	void Start () {
        timePassed = 0.0f;
        count = 0.0f;
        i = Random.Range(0, 5);
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if(count - timePassed >= 1f && count-timePassed <2f)
        {
            Debug.Log(i);
            this.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/spartan_idle_0_" + i.ToString()+".png");

            i++;
            if (i == 6)
            {
                i = 0;
            }
            count = 0.0f;
            timePassed = count;
        }
        count += Time.deltaTime;

    }
}

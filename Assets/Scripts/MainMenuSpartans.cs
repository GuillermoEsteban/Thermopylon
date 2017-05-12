using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuSpartans : MonoBehaviour {

    private float count;
    private float timePassed;
    private int i;
    Sprite[] newSprite;
    // Use this for initialization
    void Start () {
        timePassed = 0.0f;
        count = 0.0f;
        i = Random.Range(0, 5);
        newSprite = Resources.LoadAll<Sprite>("Sprites/spartan_idle_0");
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if(count - timePassed >= 0.17f && count-timePassed <1.0f)
        {
            Debug.Log(i);
            Debug.Log("Sprites/spartan_idle_0_" + i.ToString());

            this.GetComponent<Image>().sprite = newSprite[i];

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

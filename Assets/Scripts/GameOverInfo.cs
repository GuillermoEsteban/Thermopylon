using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameOverInfo : MonoBehaviour {

	// Use this for initialization
	void Start () {
        int timePlayed = (int)SpartanArmy.playedTime;
        gameObject.transform.Find("Stats").GetComponent<Text>().text = "You lasted: " + timePlayed.ToString() + " Seconds"  + "\n\n" + "Persians dead: " + SpartanArmy.persiansKilled.ToString() ;	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

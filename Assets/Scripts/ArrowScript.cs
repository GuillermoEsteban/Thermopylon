using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour {
    private GameObject selectedHenomotia;
    private Vector2 henomotiaPosition;
    public float arrowSpeed;

	// Use this for initialization
	void Start () {
        selectedHenomotia = GameObject.Find("Henomotia (" + Random.Range(0, 9).ToString() + ")");
        henomotiaPosition = selectedHenomotia.transform.position;
        Debug.Log(selectedHenomotia);

		transform.position=henomotiaPosition + new Vector2(Random.Range(100, 400), Random.Range(-50, 50));
        arrowSpeed = 100.0f;
	}
	
	// Update is called once per frame
	void Update () {

        transform.position=Vector2.MoveTowards(transform.position, henomotiaPosition, arrowSpeed*Time.deltaTime);
		
	}
}

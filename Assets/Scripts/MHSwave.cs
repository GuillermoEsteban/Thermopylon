using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MHSwave : MonoBehaviour {

    public float amplitud;
    public float periode;
    private float temps;
    private float pi = Mathf.PI;
    private Vector2 posicio;

	// Use this for initialization
	void Start () {
        posicio = gameObject.transform.position;
        temps = 0.0f;
        amplitud = 0.2f;
        periode = 6.0f;
        
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        temps += Time.deltaTime;
        posicio.y += amplitud * Mathf.Sin((2 * pi / periode) *temps);
        GetComponent<Rigidbody2D>().MovePosition(posicio);

    }
}

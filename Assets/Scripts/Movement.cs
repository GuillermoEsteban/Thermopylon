using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Movement : MonoBehaviour {

    List<GameObject> Henomotia;
	void Start ()
    {
        Henomotia = new List<GameObject>();
        for(int i=0; i<36;i++)
        {
            Henomotia.Add((GameObject)Instantiate(Resources.Load("Spartan"), new Vector3(i * 2f, 0, 0), Quaternion.identity));         
        }
	}


	// Función para inicializar las posiciones de los espartanos de la Henomotia
    void SetHenomotiaPosition()
    {
        for(int i = 0; i< 36; i++)
        {
			//Henomotia[i] = new Vector3 (i, i, 0);
            Henomotia[i].GetComponent<SpartanClass>();
        }
    }

	// Update is called once per frame
	void Update ()
    {
        
	}
}

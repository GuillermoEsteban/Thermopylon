using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersianArmy : MonoBehaviour {

    private List<GameObject> PersianList;
    private const int numPersians = 400;

	// Use this for initialization
	void Start () {
        PersianList = new List<GameObject>();
        for(int i = 0; i <= numPersians; i++)
        {

            PersianList.Add((GameObject)Instantiate(Resources.Load("Persian"), new Vector3(Random.Range(transform.position.x -50,transform.position.x + 50), Random.Range(transform.position.y + 40,transform.position.y - 40), 0.0f), Quaternion.identity));
            PersianList[i].transform.parent = transform;
        }
	}
	
	// Update is called once per frame
	void Update () {

	}


}

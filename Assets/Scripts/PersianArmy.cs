using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersianArmy : MonoBehaviour {

    private float maxRandom;
    private float randomNumber;
    private BoxCollider2D mapCollider;
    private List<GameObject> PersianList;
	public int numPersians;
    

    private float maxAreaX;//eix x del quadrat de l'àrea on s'instanciaran els perses
    private float maxAreaY;//eix y
    private Vector3 min;

    private GameObject Persian_Army;

	void Start () {

        Persian_Army = new GameObject("Persian_Army");
        Persian_Army.transform.parent = transform;
        Persian_Army.gameObject.tag = transform.gameObject.tag;

        mapCollider = GetComponent<BoxCollider2D>();
        maxAreaX = mapCollider.size.x - 5.0f;
        maxAreaY = mapCollider.size.y - 5.0f;
        min = mapCollider.bounds.min;

        PersianList = new List<GameObject>();//creem la llista dels perses.

        //Depenent del nivell, tindrà més o menys probabilitats que hi hagi enemics.
        //Cal tenir en compte que a les parts diagonals no s'instanciarà.
        if (this.tag == "lvl1")
        {
            maxRandom = 0.6f;//60 % de probabilitats
            numPersians = 0;
        }
        else if (this.tag == "lvl2")
        {
            maxRandom = 0.7f; //70 % de probabilitats
            numPersians = 200;
        }
        else if (this.tag == "lvl3")
        {
            maxRandom = 0.8f; //80 % de probabilitats
            numPersians = 300;
        }
        else if (this.tag == "lvl4")
        {
            maxRandom = 0.9f;//90% de probabilitats
            numPersians = 600;
        }

        randomNumber = Random.value;//escollim un número aleatori entre 0.0 i 1.0.
        if(randomNumber <= maxRandom)//si està dins la probabilitat, aleshores instanciarem els enemics.
        {
            for (int i = 0; i < numPersians; i++)
            {
                //agafem el prefab de Persian i el posem tantes vegades com el loop en un lloc random dins els paràmetres.
                PersianList.Add((GameObject)Instantiate(Resources.Load("Persian"), min + new Vector3(Random.Range(0, maxAreaX), Random.Range(0, maxAreaY), -40.0f), Quaternion.identity));
                PersianList[i].transform.parent = Persian_Army.transform;//posem cada persa com a child de PersianArmy
            }
        }

        if(this.tag != "lvl1")
        {
            Persian_Army.SetActive(false);
        }

	}
}

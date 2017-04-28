using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersianArmy : MonoBehaviour {

    private List<GameObject> PersianList;//llista que contindrà tots els perses del gameObject en concret.
	public int numPersians;//número de perses que contindrà. De moment és públic perquè anem canviant com vulguem.

    public int maxAreaX;//eix x del quadrat de l'àrea on s'instanciaran els perses
    public int maxAreaY;//eix y

	void Start () {
        PersianList = new List<GameObject>();//creem la llista dels perses.
        for(int i = 0; i <= numPersians; i++)
        {
            //agafem el prefab de Persian i el posem tantes vegades com el loop en un lloc random dins els paràmetres.
            PersianList.Add((GameObject)Instantiate(Resources.Load("Persian"), new Vector3(Random.Range(transform.position.x -maxAreaX,transform.position.x + maxAreaX), Random.Range(transform.position.y + maxAreaY,transform.position.y - maxAreaY), 0.0f), Quaternion.identity));
            PersianList[i].transform.parent = transform;//posem cada persa com a child de PersianArmy
        }
	}
	
	void Update () {

	}


}

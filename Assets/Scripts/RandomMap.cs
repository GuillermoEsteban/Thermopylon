using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMap : MonoBehaviour {

    private static List<GameObject> maps1;
    public int numMaps;
    private GameObject rndMap;
    private float sumX;
    private float sumY;

	// Use this for initialization
	void Start () {

        maps1 = new List<GameObject>();
        maps1.Add(Resources.Load<GameObject>("lvl1_straight"));
        maps1.Add(Resources.Load<GameObject>("lvl1_diag_down"));
        maps1.Add(Resources.Load<GameObject>("lvl1_diag_up"));
        maps1.Add(Resources.Load<GameObject>("lvl1_down"));
        maps1.Add(Resources.Load<GameObject>("lvl1_up"));

       
        sumX = 96;
        sumY = 0;

        for(int i = 0; i <= numMaps; ++i)
        {
            rndMap = maps1[Random.Range(0, 5)];
            Instantiate(rndMap, new Vector3(sumX, sumY, 2), Quaternion.identity);

            if (rndMap.name == "lvl1_straight")
            {
                sumX += 96;
                sumY += 0;
            }
            else if (rndMap.name == "lvl1_diag_down")
            {
                sumX += 96;
                sumY += -67.5f;
            }
            else if (rndMap.name == "lvl1_diag_up")
            {
                sumX += 96;
                sumY += +67.5f;
            }
            else if (rndMap.name == "lvl1_down")
            {
                sumX += 25.9f;
                sumY -= 70.35f;
            }
            else if (rndMap.name == "lvl1_up")
            {
                sumX += 25.9f;
                sumY += 69;
            }
        }

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

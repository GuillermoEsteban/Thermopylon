using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class RandomMap : MonoBehaviour {

    private static List<GameObject> mapsList;
    public int numMapsTotal;
    public int numMaps1;
    public int numMaps2;
    public int numMaps3;
    private GameObject rndMap;
    private BoxCollider2D rndMapCollider;
    private GameObject rndMapAnterior;
    private BoxCollider2D rndMapColliderAnterior;
    private int rndNum;
    private float sumX;
    private float maxX;
    private float sumY;
    private float maxY;
    private float maxYAnterior;
    private float sumZ;

    private Camera main;

	// Use this for initialization
	void Start () {

        mapsList = new List<GameObject>();

        mapsList.Add(Resources.Load<GameObject>("lvl1_straight"));
        mapsList.Add(Resources.Load<GameObject>("lvl1_diag_down"));
        mapsList.Add(Resources.Load<GameObject>("lvl1_diag_up"));
        mapsList.Add(Resources.Load<GameObject>("lvl1_down"));
        mapsList.Add(Resources.Load<GameObject>("lvl1_up"));

        sumX = 0.0f;
        sumY = 0.0f;
        sumZ = 0.0f;

        maxX = sumX;
        maxY = sumY;

        rndMap = mapsList[0];//inicialitzem el primer mapa, que sempre serà el lvl1_straight.

        //numMaps = Random.Range(2, 5);
        createMap(mapsList,mapCondition1);

        main = Camera.main;
        main.GetComponent<CameraController2>().setMax(maxX, maxY);


    }
	

	void Update () {
		
	}

    private void createMap(List<GameObject> maps,System.Action mapConditions )
    {
        for (int i = 0; i <= numMapsTotal; i++)
        {

            rndMapAnterior = rndMap;
            rndMapColliderAnterior = rndMapAnterior.GetComponent<BoxCollider2D>();

            rndNum = Random.Range(0, maps.Count);
            rndMap = maps[rndNum];

            rndMapCollider = rndMap.GetComponent<BoxCollider2D>();
            mapConditions();


            maxX = sumX;
            if (i == numMapsTotal)
            {
                maxX += rndMapCollider.size.x;
            }
            maxYAnterior = sumY;

            if (maxY < Mathf.Abs(maxYAnterior))
            {
                maxY = Mathf.Abs(maxYAnterior);
            }
            
            Instantiate(rndMap, new Vector3(sumX, sumY, sumZ), Quaternion.identity, GameObject.Find("Map").transform);

        }
    }

    private void mapCondition1()
    {
        if (rndMap.name == "lvl1_straight")
        {
            if (rndMapAnterior.name == "lvl1_straight")
            {
                sumX += rndMapColliderAnterior.size.x;
                sumY += rndMapColliderAnterior.size.y;
                sumZ += 2;
            }
            else if (rndMapAnterior.name == "lvl1_diag_down")
            {
                sumX += rndMapColliderAnterior.size.x + 0.8286f;
                sumY -= rndMapColliderAnterior.size.y + 7.76f;
                sumZ = 0.0f;
            }
            else if(rndMapAnterior.name == "lvl1_diag_up")
            {
                sumX += rndMapColliderAnterior.size.x;
                sumY += rndMapColliderAnterior.size.y;
                sumZ = 0.0f;
            }
            else if (rndMapAnterior.name == "lvl1_up")
            {
                sumX += rndMapColliderAnterior.size.x - 0.5f;
                sumY += rndMapColliderAnterior.size.y - rndMapColliderAnterior.size.x;
            }
            else if (rndMapAnterior.name == "lvl1_down")
            {
                sumX += rndMapColliderAnterior.size.x - 0.5f;
                sumY -= rndMapColliderAnterior.size.y;
            }
        }
        else if (rndMap.name == "lvl1_diag_down")
        {
            if (rndMapAnterior.name == "lvl1_straight")
            {
                sumX += rndMapColliderAnterior.size.x;
                sumY += rndMapColliderAnterior.size.y;
                sumZ += 2;
            }
            else if (rndMapAnterior.name == "lvl1_diag_down")
            {
                sumX += rndMapColliderAnterior.size.x - 17f;
                sumY -= rndMapColliderAnterior.size.y - 0.5f;
                sumZ += 2;
            }
            else if (rndMapAnterior.name == "lvl1_diag_up")
            {
                sumX += rndMapColliderAnterior.size.x;
                sumY += rndMapColliderAnterior.size.y;
                sumZ -= 0.5f;
                //Instantiate(Resources.Load<GameObject>("lvl1_triangle_up_down"), new Vector3(sumX, sumY, 0), Quaternion.identity, GameObject.Find("Map").transform);
            }
            else if (rndMapAnterior.name == "lvl1_up")
            {
                sumX += rndMapColliderAnterior.size.x;
                sumY+= rndMapColliderAnterior.size.y - rndMapColliderAnterior.size.x;
                sumZ += 4;
            }
            else if (rndMapAnterior.name == "lvl1_down")
            {
                sumX += rndMapColliderAnterior.size.x;
                sumY += -rndMapColliderAnterior.size.y;
                sumZ += 2;
            }
        }
        else if (rndMap.name == "lvl1_diag_up")
        {
            if (rndMapAnterior.name == "lvl1_straight")
            {
                sumX += 89.66f;
                sumY += 7.52f;
                sumZ += 2;
            }
            else if (rndMapAnterior.name == "lvl1_diag_down")
            {
                sumX += rndMapColliderAnterior.size.x + 18.55f;
                sumY -= rndMapColliderAnterior.size.y;
                sumZ += 2;
                //Instantiate(Resources.Load<GameObject>("lvl1_triangle_down_up"), new Vector3(sumX, sumY, 0), Quaternion.identity, GameObject.Find("Map").transform);
            }
            else if (rndMapAnterior.name == "lvl1_diag_up")
            {
                sumX += rndMapColliderAnterior.size.x;
                sumY += rndMapColliderAnterior.size.y;
                sumZ -= 0.5f;
            }
            else if (rndMapAnterior.name == "lvl1_up")
            {
                sumX += rndMapColliderAnterior.size.x + 17.36f;
                sumY += rndMapColliderAnterior.size.y + -17.81f;
                sumZ += 2;
            }
            else if (rndMapAnterior.name == "lvl1_down")
            {
                sumX += rndMapColliderAnterior.size.x + 17.78f;
                sumY += -rndMapColliderAnterior.size.y + rndMapColliderAnterior.size.x - 18.93f;
                sumZ += 2;
            }
        }
        else if (rndMap.name == "lvl1_down")
        {
            if (rndMapAnterior.name == "lvl1_straight")
            {
                sumX += rndMapColliderAnterior.size.x;
                sumY += rndMapCollider.size.x;
            }
            else if (rndMapAnterior.name == "lvl1_diag_down")
            {
                sumX += rndMapColliderAnterior.size.x;
                sumY += rndMapColliderAnterior.size.y - 83.32f;
                sumZ -= 5.0f;
            }
            else if (rndMapAnterior.name == "lvl1_diag_up")
            {
                sumX += rndMapColliderAnterior.size.x;
                sumY += rndMapColliderAnterior.size.y + 23.04f;
                sumZ -= 3.0f;
            }
            else if (rndMapAnterior.name == "lvl1_up")
            {
                sumX += rndMapColliderAnterior.size.x-0.1f;
                sumY += rndMapColliderAnterior.size.y;
            }
            else if (rndMapAnterior.name == "lvl1_down")
            {
                sumX += rndMapColliderAnterior.size.x;
                sumY += -rndMapColliderAnterior.size.y + rndMapColliderAnterior.size.x;
                
            }
        }
        else if (rndMap.name == "lvl1_up")
        {
            if (rndMapAnterior.name == "lvl1_straight")
            {
                sumX += rndMapColliderAnterior.size.x;
                sumY += rndMapColliderAnterior.size.y;
            }
            else if (rndMapAnterior.name == "lvl1_diag_down")
            {
                sumX += rndMapColliderAnterior.size.x;
                sumY += -rndMapColliderAnterior.size.y - 6.899f;
                sumZ -= 3.0f;
            }
            else if (rndMapAnterior.name == "lvl1_diag_up")
            {
                sumX += rndMapColliderAnterior.size.x;
                sumY += rndMapColliderAnterior.size.y;
                sumZ -= 3.0f;
            }
            else if (rndMapAnterior.name == "lvl1_up")
            {
                sumX += rndMapColliderAnterior.size.x;
                sumY += rndMapColliderAnterior.size.y - rndMapColliderAnterior.size.x;
                sumZ += 2;
            }
            else if (rndMapAnterior.name == "lvl1_down")
            {
                sumX += rndMapColliderAnterior.size.x;
                sumY -= rndMapColliderAnterior.size.y;
            }
        }
    }
}

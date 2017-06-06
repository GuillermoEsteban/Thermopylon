using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class RandomMap2 : MonoBehaviour
{

    private static List<GameObject> mapsList;

    private int numMaps1;
    private int numMaps2;
    private int numMaps3;
    private int numMaps4;

    public int random_X_lvl1=3;
    public int random_Y_lvl1 = 5;
    public int random_X_lvl2=3;
    public int random_Y_lvl2=5;
    public int random_X_lvl3=3;
    public int random_Y_lvl3=5;
    public int random_X_lvl4=3;
    public int random_Y_lvl4=5;


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


    private float yTri;

    private Camera cam;
	private Camera miniMapCamera;

    // Use this for initialization
    void Start()
    {

        mapsList = new List<GameObject>();

        mapsList.Add(Resources.Load<GameObject>("lvl1_straight"));
        mapsList.Add(Resources.Load<GameObject>("lvl1_diag_down_triangles"));
        mapsList.Add(Resources.Load<GameObject>("lvl1_diag_up_triangles"));
        mapsList.Add(Resources.Load<GameObject>("lvl1_down"));
        mapsList.Add(Resources.Load<GameObject>("lvl1_up"));

        sumX = 0.0f;
        sumY = 0.0f;
        sumZ = 40.0f;//Z canviada per problema de espartans.

        maxX = sumX;
        maxY = sumY;

        rndMap = mapsList[0];//inicialitzem el primer mapa, que sempre serà el lvl1_straight.
        yTri = 25.323f;

        numMaps1 = Random.Range(random_X_lvl1, random_Y_lvl1);
        numMaps2 = Random.Range(random_X_lvl2, random_Y_lvl2);
        numMaps3 = Random.Range(random_X_lvl3, random_Y_lvl3);
        numMaps4 = Random.Range(random_X_lvl4, random_Y_lvl4);

        createMap(numMaps1, mapConditions1);

        cam = Resources.Load<Camera>("MainCamera");
        Instantiate(cam);

        //Acabem el level1 amb un straight
        rndMapAnterior = rndMap;
        rndMapColliderAnterior = rndMapAnterior.GetComponent<BoxCollider2D>();
        rndMap = mapsList[0];
        rndMapCollider = rndMap.GetComponent<BoxCollider2D>();
        mapConditions1();
        Instantiate(rndMap, new Vector3(sumX, sumY, sumZ), Quaternion.identity, GameObject.Find("NewMap").transform);

        mapsList.Clear();

        //Quan el jugador entri a lúltima part del Level1, carregarà el nivell 2, eliminant el primer.
        //També el mini-map es centrarà en el Level 2 creat nou, i els extrems de la càmera del jugador seran els nous del Level2.
        mapsList.Add(Resources.Load<GameObject>("lvl2_straight"));
        mapsList.Add(Resources.Load<GameObject>("lvl2_diag_down_triangles"));
        mapsList.Add(Resources.Load<GameObject>("lvl2_diag_up_triangles"));
        mapsList.Add(Resources.Load<GameObject>("lvl2_down"));
        mapsList.Add(Resources.Load<GameObject>("lvl2_up"));

        yTri += 25.323f;

        rndMapAnterior = rndMap;
        rndMapColliderAnterior = rndMapAnterior.GetComponent<BoxCollider2D>();
        rndMap = mapsList[0]; //altre cop, tornem a començar amb un straight
        sumX += rndMapColliderAnterior.size.x;
        sumY -= 10f;
        Instantiate(rndMap, new Vector3(sumX, sumY, sumZ), Quaternion.identity, GameObject.Find("NewMap").transform);

        createMap(numMaps2, mapConditions2);

        rndMapAnterior = rndMap;
        rndMapColliderAnterior = rndMapAnterior.GetComponent<BoxCollider2D>();
        rndMap = mapsList[0];//i acabem amb un altre straight
        rndMapCollider = rndMap.GetComponent<BoxCollider2D>();
        mapConditions2();
        Instantiate(rndMap, new Vector3(sumX, sumY, sumZ), Quaternion.identity, GameObject.Find("NewMap").transform);


        mapsList.Clear();

        mapsList.Add(Resources.Load<GameObject>("lvl3_straight"));
        mapsList.Add(Resources.Load<GameObject>("lvl3_diag_down_triangles"));
        mapsList.Add(Resources.Load<GameObject>("lvl3_diag_up_triangles"));
        mapsList.Add(Resources.Load<GameObject>("lvl3_down"));
        mapsList.Add(Resources.Load<GameObject>("lvl3_up"));

        yTri += 25.323f;

        rndMapAnterior = rndMap;
        rndMapColliderAnterior = rndMapAnterior.GetComponent<BoxCollider2D>();
        rndMap = mapsList[0]; //altre cop, tornem a començar amb un straight
        sumX += rndMapColliderAnterior.size.x;
        sumY -= 10f;
        Instantiate(rndMap, new Vector3(sumX, sumY, sumZ), Quaternion.identity, GameObject.Find("NewMap").transform);


        createMap(numMaps3, mapConditions3);

        rndMapAnterior = rndMap;
        rndMapColliderAnterior = rndMapAnterior.GetComponent<BoxCollider2D>();
        rndMap = mapsList[0];//i acabem amb un altre straight
        rndMapCollider = rndMap.GetComponent<BoxCollider2D>();
        mapConditions3();
        Instantiate(rndMap, new Vector3(sumX, sumY, sumZ), Quaternion.identity, GameObject.Find("NewMap").transform);

        mapsList.Clear();

        mapsList.Add(Resources.Load<GameObject>("lvl4_straight"));
        mapsList.Add(Resources.Load<GameObject>("lvl4_diag_down_triangles"));
        mapsList.Add(Resources.Load<GameObject>("lvl4_diag_up_triangles"));
        mapsList.Add(Resources.Load<GameObject>("lvl4_down"));
        mapsList.Add(Resources.Load<GameObject>("lvl4_up"));

        rndMapAnterior = rndMap;
        rndMapColliderAnterior = rndMapAnterior.GetComponent<BoxCollider2D>();
        rndMap = mapsList[0]; //altre cop, tornem a començar amb un straight
        sumX += rndMapColliderAnterior.size.x;
        sumY -= 10f;
        Instantiate(rndMap, new Vector3(sumX, sumY, sumZ), Quaternion.identity, GameObject.Find("NewMap").transform);

        yTri += 25.323f;

        createMap(numMaps4, mapConditions4);

		miniMapCamera = Resources.Load<Camera>("miniMapCamera");
		Instantiate(miniMapCamera);
    }


    void Update()
    {

    }

    public float getLimitX()
    {
        return maxX + 60.1f;
    }
    public float getLimitY()
    {
        return maxY;
    }

    private void createMap(int numMaps, System.Action mapConditions)
    {
        for (int i = 0; i <= numMaps; i++)
        {

            rndMapAnterior = rndMap;
            rndMapColliderAnterior = rndMapAnterior.GetComponent<BoxCollider2D>();

            rndNum = Random.Range(0, mapsList.Count);
            rndMap = mapsList[rndNum];

            rndMapCollider = rndMap.GetComponent<BoxCollider2D>();  
            mapConditions();


            maxX = sumX;
            if (i == numMaps)
            {
                maxX += rndMapCollider.size.x;
            }
            maxYAnterior = sumY;

            if (maxY < Mathf.Abs(maxYAnterior))
            {
                maxY = Mathf.Abs(maxYAnterior);
            }

            Instantiate(rndMap, new Vector3(sumX, sumY, sumZ), Quaternion.identity, GameObject.Find("NewMap").transform);

        }
    }
    //private void mapConditions()
    //{
    //    //LEVEL 1*********************************************************************************
    //    if (rndMap.name == "lvl1_straight")
    //    {
    //        if (rndMapAnterior.name == "lvl1_straight")
    //        {
    //            sumX += rndMapColliderAnterior.size.x;

    //        }
    //        else if (rndMapAnterior.name == "lvl1_diag_down_triangles")
    //        {
    //            sumX += rndMapColliderAnterior.size.x;
    //            sumY -= rndMapColliderAnterior.size.y;
    //        }
    //        else if (rndMapAnterior.name == "lvl1_diag_up_triangles")
    //        {
    //            sumX += rndMapColliderAnterior.size.x;
    //            sumY += rndMapColliderAnterior.size.y - yTri;
    //        }
    //        else if (rndMapAnterior.name == "lvl1_up")
    //        {
    //            sumX += rndMapColliderAnterior.size.x;
    //            sumY += rndMapColliderAnterior.size.y - rndMapColliderAnterior.size.x;
    //        }
    //        else if (rndMapAnterior.name == "lvl1_down")
    //        {
    //            sumX += rndMapColliderAnterior.size.x;
    //            sumY -= rndMapColliderAnterior.size.y;
    //        }
    //    }
    //    else if (rndMap.name == "lvl1_diag_down_triangles")
    //    {
    //        if (rndMapAnterior.name == "lvl1_straight")
    //        {
    //            sumX += rndMapColliderAnterior.size.x;
    //        }
    //        else if (rndMapAnterior.name == "lvl1_diag_down_triangles")
    //        {
    //            sumX += Resources.Load<GameObject>("lvl1_diag_down").GetComponent<BoxCollider2D>().size.x;
    //            sumY -= Resources.Load<GameObject>("lvl1_diag_down").GetComponent<BoxCollider2D>().size.y;
    //            Instantiate(Resources.Load<GameObject>("lvl1_diag_down"), new Vector3(sumX, sumY, sumZ - 2), Quaternion.identity, GameObject.Find("NewMap").transform);
    //        }
    //        else if (rndMapAnterior.name == "lvl1_diag_up_triangles")
    //        {
    //            sumX += rndMapColliderAnterior.size.x;
    //            sumY += yTri;
    //        }
    //        else if (rndMapAnterior.name == "lvl1_up")
    //        {
    //            sumX += rndMapColliderAnterior.size.x;
    //            sumY += rndMapColliderAnterior.size.y - rndMapColliderAnterior.size.x;
    //        }
    //        else if (rndMapAnterior.name == "lvl1_down")
    //        {
    //            sumX += rndMapColliderAnterior.size.x;
    //            sumY -= rndMapColliderAnterior.size.y;
    //        }
    //    }
    //    else if (rndMap.name == "lvl1_diag_up_triangles")
    //    {
    //        if (rndMapAnterior.name == "lvl1_straight")
    //        {
    //            sumX += rndMapColliderAnterior.size.x;
    //            sumY += rndMapColliderAnterior.size.y;
    //        }
    //        else if (rndMapAnterior.name == "lvl1_diag_down_triangles")
    //        {
    //            sumX += rndMapColliderAnterior.size.x;
    //            sumY += -rndMapColliderAnterior.size.y + yTri;
    //        }
    //        else if (rndMapAnterior.name == "lvl1_diag_up_triangles")
    //        {
    //            sumX += rndMapColliderAnterior.size.x;
    //            sumY += rndMapColliderAnterior.size.y + yTri;
    //            Instantiate(Resources.Load<GameObject>("lvl1_diag_up"), new Vector3(sumX, sumY, sumZ - 3), Quaternion.identity, GameObject.Find("NewMap").transform);
    //        }
    //        else if (rndMapAnterior.name == "lvl1_up")
    //        {
    //            sumX += rndMapColliderAnterior.size.x;
    //            sumY += rndMapColliderAnterior.size.y;
    //        }
    //        else if (rndMapAnterior.name == "lvl1_down")
    //        {
    //            sumX += rndMapColliderAnterior.size.x;
    //            sumY += -rndMapColliderAnterior.size.y + yTri;
    //        }
    //    }
    //    else if (rndMap.name == "lvl1_down")
    //    {
    //        if (rndMapAnterior.name == "lvl1_straight")
    //        {
    //            sumX += rndMapColliderAnterior.size.x;
    //            sumY += rndMapCollider.size.x;
    //        }
    //        else if (rndMapAnterior.name == "lvl1_diag_down_triangles")
    //        {
    //            sumX += rndMapColliderAnterior.size.x;
    //            sumY += -rndMapColliderAnterior.size.y + yTri;
    //        }
    //        else if (rndMapAnterior.name == "lvl1_diag_up_triangles")
    //        {
    //            sumX += rndMapColliderAnterior.size.x;
    //            sumY += rndMapColliderAnterior.size.y;
    //        }
    //        else if (rndMapAnterior.name == "lvl1_up")
    //        {
    //            sumX += rndMapColliderAnterior.size.x;
    //            sumY += rndMapColliderAnterior.size.y;
    //        }
    //        else if (rndMapAnterior.name == "lvl1_down")
    //        {
    //            sumX += rndMapColliderAnterior.size.x;
    //            sumY -= rndMapColliderAnterior.size.y - yTri;

    //        }
    //    }
    //    else if (rndMap.name == "lvl1_up")
    //    {
    //        if (rndMapAnterior.name == "lvl1_straight")
    //        {
    //            sumX += rndMapColliderAnterior.size.x;
    //        }
    //        else if (rndMapAnterior.name == "lvl1_diag_down_triangles")
    //        {
    //            sumX += rndMapColliderAnterior.size.x;
    //            sumY -= +rndMapColliderAnterior.size.y + yTri;
    //        }
    //        else if (rndMapAnterior.name == "lvl1_diag_up_triangles")
    //        {
    //            sumX += rndMapColliderAnterior.size.x;
    //            sumY += rndMapColliderAnterior.size.y - yTri;
    //        }
    //        else if (rndMapAnterior.name == "lvl1_up")
    //        {
    //            sumX += rndMapColliderAnterior.size.x;
    //            sumY += rndMapColliderAnterior.size.y - rndMapColliderAnterior.size.x;
    //        }
    //        else if (rndMapAnterior.name == "lvl1_down")
    //        {
    //            sumX += rndMapColliderAnterior.size.x;
    //            sumY -= rndMapColliderAnterior.size.y;
    //        }
    //    }
    //    //LEVEL 2*********************************************************************************
    //    else if (rndMap.name == "lvl2_straight")
    //    {
    //        if (rndMapAnterior.name == "lvl2_straight")
    //        {
    //            sumX += rndMapColliderAnterior.size.x;

    //        }
    //        else if (rndMapAnterior.name == "lvl2_diag_down_triangles")
    //        {
    //            sumX += rndMapColliderAnterior.size.x;
    //            sumY -= rndMapColliderAnterior.size.y;
    //        }
    //        else if (rndMapAnterior.name == "lvl2_diag_up_triangles")
    //        {
    //            sumX += rndMapColliderAnterior.size.x;
    //            sumY += rndMapColliderAnterior.size.y - yTri;
    //        }
    //        else if (rndMapAnterior.name == "lvl2_up")
    //        {
    //            sumX += rndMapColliderAnterior.size.x;
    //            sumY += rndMapColliderAnterior.size.y - rndMapColliderAnterior.size.x;
    //        }
    //        else if (rndMapAnterior.name == "lvl2_down")
    //        {
    //            sumX += rndMapColliderAnterior.size.x;
    //            sumY -= rndMapColliderAnterior.size.y;
    //        }
    //    }
    //    else if (rndMap.name == "lvl2_diag_down_triangles")
    //    {
    //        if (rndMapAnterior.name == "lvl2_straight")
    //        {
    //            sumX += rndMapColliderAnterior.size.x;
    //        }
    //        else if (rndMapAnterior.name == "lvl2_diag_down_triangles")
    //        {
    //            sumX += Resources.Load<GameObject>("lvl2_diag_down").GetComponent<BoxCollider2D>().size.x;
    //            sumY -= Resources.Load<GameObject>("lvl2_diag_down").GetComponent<BoxCollider2D>().size.y;
    //            Instantiate(Resources.Load<GameObject>("lvl2_diag_down"), new Vector3(sumX, sumY, sumZ - 2), Quaternion.identity, GameObject.Find("NewMap").transform);
    //        }
    //        else if (rndMapAnterior.name == "lvl2_diag_up_triangles")
    //        {
    //            sumX += rndMapColliderAnterior.size.x;
    //            sumY += yTri;
    //        }
    //        else if (rndMapAnterior.name == "lvl2_up")
    //        {
    //            sumX += rndMapColliderAnterior.size.x;
    //            sumY += rndMapColliderAnterior.size.y - rndMapColliderAnterior.size.x;
    //        }
    //        else if (rndMapAnterior.name == "lvl2_down")
    //        {
    //            sumX += rndMapColliderAnterior.size.x;
    //            sumY -= rndMapColliderAnterior.size.y;
    //        }
    //    }
    //    else if (rndMap.name == "lvl2_diag_up_triangles")
    //    {
    //        if (rndMapAnterior.name == "lvl2_straight")
    //        {
    //            sumX += rndMapColliderAnterior.size.x;
    //            sumY += rndMapColliderAnterior.size.y;
    //        }
    //        else if (rndMapAnterior.name == "lvl2_diag_down_triangles")
    //        {
    //            sumX += rndMapColliderAnterior.size.x;
    //            sumY += -rndMapColliderAnterior.size.y + yTri;
    //        }
    //        else if (rndMapAnterior.name == "lvl2_diag_up_triangles")
    //        {
    //            sumX += rndMapColliderAnterior.size.x;
    //            sumY += rndMapColliderAnterior.size.y + yTri;
    //            Instantiate(Resources.Load<GameObject>("lvl2_diag_up"), new Vector3(sumX, sumY, sumZ - 2), Quaternion.identity, GameObject.Find("NewMap").transform);
    //        }
    //        else if (rndMapAnterior.name == "lvl2_up")
    //        {
    //            sumX += rndMapColliderAnterior.size.x;
    //            sumY += rndMapColliderAnterior.size.y;
    //        }
    //        else if (rndMapAnterior.name == "lvl2_down")
    //        {
    //            sumX += rndMapColliderAnterior.size.x;
    //            sumY += -rndMapColliderAnterior.size.y + yTri;
    //        }
    //    }
    //    else if (rndMap.name == "lvl2_down")
    //    {
    //        if (rndMapAnterior.name == "lvl2_straight")
    //        {
    //            sumX += rndMapColliderAnterior.size.x;
    //            sumY += rndMapCollider.size.x;
    //        }
    //        else if (rndMapAnterior.name == "lvl2_diag_down_triangles")
    //        {
    //            sumX += rndMapColliderAnterior.size.x;
    //            sumY += -rndMapColliderAnterior.size.y + yTri;
    //        }
    //        else if (rndMapAnterior.name == "lvl2_diag_up_triangles")
    //        {
    //            sumX += rndMapColliderAnterior.size.x;
    //            sumY += rndMapColliderAnterior.size.y;
    //        }
    //        else if (rndMapAnterior.name == "lvl2_up")
    //        {
    //            sumX += rndMapColliderAnterior.size.x;
    //            sumY += rndMapColliderAnterior.size.y;
    //        }
    //        else if (rndMapAnterior.name == "lvl2_down")
    //        {
    //            sumX += rndMapColliderAnterior.size.x;
    //            sumY -= rndMapColliderAnterior.size.y - yTri;

    //        }
    //    }
    //    else if (rndMap.name == "lvl2_up")
    //    {
    //        if (rndMapAnterior.name == "lvl2_straight")
    //        {
    //            sumX += rndMapColliderAnterior.size.x;
    //        }
    //        else if (rndMapAnterior.name == "lvl2_diag_down_triangles")
    //        {
    //            sumX += rndMapColliderAnterior.size.x;
    //            sumY -= +rndMapColliderAnterior.size.y + yTri;
    //        }
    //        else if (rndMapAnterior.name == "lvl2_diag_up_triangles")
    //        {
    //            sumX += rndMapColliderAnterior.size.x;
    //            sumY += rndMapColliderAnterior.size.y - yTri;
    //        }
    //        else if (rndMapAnterior.name == "lvl2_up")
    //        {
    //            sumX += rndMapColliderAnterior.size.x;
    //            sumY += rndMapColliderAnterior.size.y - rndMapColliderAnterior.size.x;
    //        }
    //        else if (rndMapAnterior.name == "lvl2_down")
    //        {
    //            sumX += rndMapColliderAnterior.size.x;
    //            sumY -= rndMapColliderAnterior.size.y;
    //        }
    //    }
    //    //LEVEL 3*********************************************************************************
    //    else if (rndMap.name == "lvl3_straight")
    //    {
    //        if (rndMapAnterior.name == "lvl3_straight")
    //        {
    //            sumX += rndMapColliderAnterior.size.x;

    //        }
    //        else if (rndMapAnterior.name == "lvl3_diag_down_triangles")
    //        {
    //            sumX += rndMapColliderAnterior.size.x;
    //            sumY -= rndMapColliderAnterior.size.y;
    //        }
    //        else if (rndMapAnterior.name == "lvl3_diag_up_triangles")
    //        {
    //            sumX += rndMapColliderAnterior.size.x;
    //            sumY += rndMapColliderAnterior.size.y - yTri;
    //        }
    //        else if (rndMapAnterior.name == "lvl3_up")
    //        {
    //            sumX += rndMapColliderAnterior.size.x;
    //            sumY += rndMapColliderAnterior.size.y - rndMapColliderAnterior.size.x;
    //        }
    //        else if (rndMapAnterior.name == "lvl3_down")
    //        {
    //            sumX += rndMapColliderAnterior.size.x;
    //            sumY -= rndMapColliderAnterior.size.y;
    //        }
    //    }
    //    else if (rndMap.name == "lvl3_diag_down_triangles")
    //    {
    //        if (rndMapAnterior.name == "lvl3_straight")
    //        {
    //            sumX += rndMapColliderAnterior.size.x;
    //        }
    //        else if (rndMapAnterior.name == "lvl3_diag_down_triangles")
    //        {
    //            sumX += Resources.Load<GameObject>("lvl3_diag_down").GetComponent<BoxCollider2D>().size.x;
    //            sumY -= Resources.Load<GameObject>("lvl3_diag_down").GetComponent<BoxCollider2D>().size.y;
    //            Instantiate(Resources.Load<GameObject>("lvl3_diag_down"), new Vector3(sumX, sumY, sumZ - 2), Quaternion.identity, GameObject.Find("NewMap").transform);
    //        }
    //        else if (rndMapAnterior.name == "lvl3_diag_up_triangles")
    //        {
    //            sumX += rndMapColliderAnterior.size.x;
    //            sumY += yTri;
    //        }
    //        else if (rndMapAnterior.name == "lvl3_up")
    //        {
    //            sumX += rndMapColliderAnterior.size.x;
    //            sumY += rndMapColliderAnterior.size.y - rndMapColliderAnterior.size.x;
    //        }
    //        else if (rndMapAnterior.name == "lvl3_down")
    //        {
    //            sumX += rndMapColliderAnterior.size.x;
    //            sumY -= rndMapColliderAnterior.size.y;
    //        }
    //    }
    //    else if (rndMap.name == "lvl3_diag_up_triangles")
    //    {
    //        if (rndMapAnterior.name == "lvl3_straight")
    //        {
    //            sumX += rndMapColliderAnterior.size.x;
    //            sumY += rndMapColliderAnterior.size.y;
    //        }
    //        else if (rndMapAnterior.name == "lvl3_diag_down_triangles")
    //        {
    //            sumX += rndMapColliderAnterior.size.x;
    //            sumY += -rndMapColliderAnterior.size.y + yTri;
    //        }
    //        else if (rndMapAnterior.name == "lvl3_diag_up_triangles")
    //        {
    //            sumX += rndMapColliderAnterior.size.x;
    //            sumY += rndMapColliderAnterior.size.y + yTri;
    //            Instantiate(Resources.Load<GameObject>("lvl3_diag_up"), new Vector3(sumX, sumY, sumZ - 2), Quaternion.identity, GameObject.Find("NewMap").transform);
    //        }
    //        else if (rndMapAnterior.name == "lvl3_up")
    //        {
    //            sumX += rndMapColliderAnterior.size.x;
    //            sumY += rndMapColliderAnterior.size.y;
    //        }
    //        else if (rndMapAnterior.name == "lvl3_down")
    //        {
    //            sumX += rndMapColliderAnterior.size.x;
    //            sumY += -rndMapColliderAnterior.size.y + yTri;
    //        }
    //    }
    //    else if (rndMap.name == "lvl3_down")
    //    {
    //        if (rndMapAnterior.name == "lvl3_straight")
    //        {
    //            sumX += rndMapColliderAnterior.size.x;
    //            sumY += rndMapCollider.size.x;
    //        }
    //        else if (rndMapAnterior.name == "lvl3_diag_down_triangles")
    //        {
    //            sumX += rndMapColliderAnterior.size.x;
    //            sumY += -rndMapColliderAnterior.size.y + yTri;
    //        }
    //        else if (rndMapAnterior.name == "lvl3_diag_up_triangles")
    //        {
    //            sumX += rndMapColliderAnterior.size.x;
    //            sumY += rndMapColliderAnterior.size.y;
    //        }
    //        else if (rndMapAnterior.name == "lvl3_up")
    //        {
    //            sumX += rndMapColliderAnterior.size.x;
    //            sumY += rndMapColliderAnterior.size.y;
    //        }
    //        else if (rndMapAnterior.name == "lvl3_down")
    //        {
    //            sumX += rndMapColliderAnterior.size.x;
    //            sumY -= rndMapColliderAnterior.size.y - yTri;

    //        }
    //    }
    //    else if (rndMap.name == "lvl3_up")
    //    {
    //        if (rndMapAnterior.name == "lvl3_straight")
    //        {
    //            sumX += rndMapColliderAnterior.size.x;
    //        }
    //        else if (rndMapAnterior.name == "lvl3_diag_down_triangles")
    //        {
    //            sumX += rndMapColliderAnterior.size.x;
    //            sumY -= +rndMapColliderAnterior.size.y + yTri;
    //        }
    //        else if (rndMapAnterior.name == "lvl3_diag_up_triangles")
    //        {
    //            sumX += rndMapColliderAnterior.size.x;
    //            sumY += rndMapColliderAnterior.size.y - yTri;
    //        }
    //        else if (rndMapAnterior.name == "lvl3_up")
    //        {
    //            sumX += rndMapColliderAnterior.size.x;
    //            sumY += rndMapColliderAnterior.size.y - rndMapColliderAnterior.size.x;
    //        }
    //        else if (rndMapAnterior.name == "lvl3_down")
    //        {
    //            sumX += rndMapColliderAnterior.size.x;
    //            sumY -= rndMapColliderAnterior.size.y;
    //        }
    //    }
    //    //LEVEL 4*********************************************************************************
    //    else if (rndMap.name == "lvl4_straight")
    //    {
    //        if (rndMapAnterior.name == "lvl4_straight")
    //        {
    //            sumX += rndMapColliderAnterior.size.x;

    //        }
    //        else if (rndMapAnterior.name == "lvl4_diag_down_triangles")
    //        {
    //            sumX += rndMapColliderAnterior.size.x;
    //            sumY -= rndMapColliderAnterior.size.y;
    //        }
    //        else if (rndMapAnterior.name == "lvl4_diag_up_triangles")
    //        {
    //            sumX += rndMapColliderAnterior.size.x;
    //            sumY += rndMapColliderAnterior.size.y - yTri;
    //        }
    //        else if (rndMapAnterior.name == "lvl4_up")
    //        {
    //            sumX += rndMapColliderAnterior.size.x;
    //            sumY += rndMapColliderAnterior.size.y - rndMapColliderAnterior.size.x;
    //        }
    //        else if (rndMapAnterior.name == "lvl4_down")
    //        {
    //            sumX += rndMapColliderAnterior.size.x;
    //            sumY -= rndMapColliderAnterior.size.y;
    //        }
    //    }
    //    else if (rndMap.name == "lvl4_diag_down_triangles")
    //    {
    //        if (rndMapAnterior.name == "lvl4_straight")
    //        {
    //            sumX += rndMapColliderAnterior.size.x;
    //        }
    //        else if (rndMapAnterior.name == "lvl4_diag_down_triangles")
    //        {
    //            sumX += Resources.Load<GameObject>("lvl4_diag_down").GetComponent<BoxCollider2D>().size.x;
    //            sumY -= Resources.Load<GameObject>("lvl4_diag_down").GetComponent<BoxCollider2D>().size.y;
    //            Instantiate(Resources.Load<GameObject>("lvl4_diag_down"), new Vector3(sumX, sumY, sumZ - 2), Quaternion.identity, GameObject.Find("NewMap").transform);
    //        }
    //        else if (rndMapAnterior.name == "lvl4_diag_up_triangles")
    //        {
    //            sumX += rndMapColliderAnterior.size.x;
    //            sumY += yTri;
    //        }
    //        else if (rndMapAnterior.name == "lvl4_up")
    //        {
    //            sumX += rndMapColliderAnterior.size.x;
    //            sumY += rndMapColliderAnterior.size.y - rndMapColliderAnterior.size.x;
    //        }
    //        else if (rndMapAnterior.name == "lvl4_down")
    //        {
    //            sumX += rndMapColliderAnterior.size.x;
    //            sumY -= rndMapColliderAnterior.size.y;
    //        }
    //    }
    //    else if (rndMap.name == "lvl4_diag_up_triangles")
    //    {
    //        if (rndMapAnterior.name == "lvl4_straight")
    //        {
    //            sumX += rndMapColliderAnterior.size.x;
    //            sumY += rndMapColliderAnterior.size.y;
    //        }
    //        else if (rndMapAnterior.name == "lvl4_diag_down_triangles")
    //        {
    //            sumX += rndMapColliderAnterior.size.x;
    //            sumY += -rndMapColliderAnterior.size.y + yTri;
    //        }
    //        else if (rndMapAnterior.name == "lvl4_diag_up_triangles")
    //        {
    //            sumX += rndMapColliderAnterior.size.x;
    //            sumY += rndMapColliderAnterior.size.y + yTri;
    //            Instantiate(Resources.Load<GameObject>("lvl4_diag_up"), new Vector3(sumX, sumY, sumZ - 2), Quaternion.identity, GameObject.Find("NewMap").transform);
    //        }
    //        else if (rndMapAnterior.name == "lvl4_up")
    //        {
    //            sumX += rndMapColliderAnterior.size.x;
    //            sumY += rndMapColliderAnterior.size.y;
    //        }
    //        else if (rndMapAnterior.name == "lvl4_down")
    //        {
    //            sumX += rndMapColliderAnterior.size.x;
    //            sumY += -rndMapColliderAnterior.size.y + yTri;
    //        }
    //    }
    //    else if (rndMap.name == "lvl4_down")
    //    {
    //        if (rndMapAnterior.name == "lvl4_straight")
    //        {
    //            sumX += rndMapColliderAnterior.size.x;
    //            sumY += rndMapCollider.size.x;
    //        }
    //        else if (rndMapAnterior.name == "lvl4_diag_down_triangles")
    //        {
    //            sumX += rndMapColliderAnterior.size.x;
    //            sumY += -rndMapColliderAnterior.size.y + yTri;
    //        }
    //        else if (rndMapAnterior.name == "lvl4_diag_up_triangles")
    //        {
    //            sumX += rndMapColliderAnterior.size.x;
    //            sumY += rndMapColliderAnterior.size.y;
    //        }
    //        else if (rndMapAnterior.name == "lvl4_up")
    //        {
    //            sumX += rndMapColliderAnterior.size.x;
    //            sumY += rndMapColliderAnterior.size.y;
    //        }
    //        else if (rndMapAnterior.name == "lvl4_down")
    //        {
    //            sumX += rndMapColliderAnterior.size.x;
    //            sumY -= rndMapColliderAnterior.size.y - yTri;

    //        }
    //    }
    //    else if (rndMap.name == "lvl4_up")
    //    {
    //        if (rndMapAnterior.name == "lvl4_straight")
    //        {
    //            sumX += rndMapColliderAnterior.size.x;
    //        }
    //        else if (rndMapAnterior.name == "lvl4_diag_down_triangles")
    //        {
    //            sumX += rndMapColliderAnterior.size.x;
    //            sumY -= +rndMapColliderAnterior.size.y + yTri;
    //        }
    //        else if (rndMapAnterior.name == "lvl4_diag_up_triangles")
    //        {
    //            sumX += rndMapColliderAnterior.size.x;
    //            sumY += rndMapColliderAnterior.size.y - yTri;
    //        }
    //        else if (rndMapAnterior.name == "lvl4_up")
    //        {
    //            sumX += rndMapColliderAnterior.size.x;
    //            sumY += rndMapColliderAnterior.size.y - rndMapColliderAnterior.size.x;
    //        }
    //        else if (rndMapAnterior.name == "lvl4_down")
    //        {
    //            sumX += rndMapColliderAnterior.size.x;
    //            sumY -= rndMapColliderAnterior.size.y;
    //        }
    //    }
    //}

    private void mapConditions1()
    {
        //LEVEL 1*********************************************************************************
        if (rndMap.name == "lvl1_straight")
        {
            if (rndMapAnterior.name == "lvl1_straight")
            {
                sumX += rndMapColliderAnterior.size.x;

            }
            else if (rndMapAnterior.name == "lvl1_diag_down_triangles")
            {
                sumX += rndMapColliderAnterior.size.x;
                sumY -= rndMapColliderAnterior.size.y;
            }
            else if (rndMapAnterior.name == "lvl1_diag_up_triangles")
            {
                sumX += rndMapColliderAnterior.size.x;
                sumY += rndMapColliderAnterior.size.y - yTri + 0.75f;
            }
            else if (rndMapAnterior.name == "lvl1_up")
            {
                sumX += rndMapColliderAnterior.size.x;
                sumY += rndMapColliderAnterior.size.y - rndMapColliderAnterior.size.x;
            }
            else if (rndMapAnterior.name == "lvl1_down")
            {
                sumX += rndMapColliderAnterior.size.x;
                sumY -= rndMapColliderAnterior.size.y;
            }
        }
        else if (rndMap.name == "lvl1_diag_down_triangles")
        {
            if (rndMapAnterior.name == "lvl1_straight")
            {
                sumX += rndMapColliderAnterior.size.x;
            }
            else if (rndMapAnterior.name == "lvl1_diag_down_triangles")
            {
                sumX += Resources.Load<GameObject>("lvl1_diag_down").GetComponent<BoxCollider2D>().size.x;
                sumY -= Resources.Load<GameObject>("lvl1_diag_down").GetComponent<BoxCollider2D>().size.y;
                
                Instantiate(Resources.Load<GameObject>("lvl1_diag_down"), new Vector3(sumX, sumY, sumZ - 3), Quaternion.identity, GameObject.Find("NewMap").transform);
                sumZ -= 0.05f;
            }
            else if (rndMapAnterior.name == "lvl1_diag_up_triangles")
            {
                sumX += rndMapColliderAnterior.size.x;
                sumY += yTri;
            }
            else if (rndMapAnterior.name == "lvl1_up")
            {
                sumX += rndMapColliderAnterior.size.x;
                sumY += rndMapColliderAnterior.size.y - rndMapColliderAnterior.size.x;
            }
            else if (rndMapAnterior.name == "lvl1_down")
            {
                sumX += rndMapColliderAnterior.size.x;
                sumY -= rndMapColliderAnterior.size.y;
            }
        }
        else if (rndMap.name == "lvl1_diag_up_triangles")
        {
            if (rndMapAnterior.name == "lvl1_straight")
            {
                sumX += rndMapColliderAnterior.size.x;
                sumY += rndMapColliderAnterior.size.y;
            }
            else if (rndMapAnterior.name == "lvl1_diag_down_triangles")
            {
                sumX += rndMapColliderAnterior.size.x;
                sumY += -rndMapColliderAnterior.size.y + yTri;
            }
            else if (rndMapAnterior.name == "lvl1_diag_up_triangles")
            {
                sumX += Resources.Load<GameObject>("lvl1_diag_up").GetComponent<BoxCollider2D>().size.x;
                sumY += Resources.Load<GameObject>("lvl1_diag_up").GetComponent<BoxCollider2D>().size.y;
                sumZ += 1;
                
                Instantiate(Resources.Load<GameObject>("lvl1_diag_up"), new Vector3(sumX, sumY, sumZ - 2), Quaternion.identity, GameObject.Find("NewMap").transform);
                
            }
            else if (rndMapAnterior.name == "lvl1_up")
            {
                sumX += rndMapColliderAnterior.size.x;
                sumY += rndMapColliderAnterior.size.y;
            }
            else if (rndMapAnterior.name == "lvl1_down")
            {
                sumX += rndMapColliderAnterior.size.x;
                sumY += -rndMapColliderAnterior.size.y + yTri;
            }
        }
        else if (rndMap.name == "lvl1_down")
        {
            if (rndMapAnterior.name == "lvl1_straight")
            {
                sumX += rndMapColliderAnterior.size.x;
                sumY += rndMapCollider.size.x;
            }
            else if (rndMapAnterior.name == "lvl1_diag_down_triangles")
            {
                sumX += rndMapColliderAnterior.size.x;
                sumY += -rndMapColliderAnterior.size.y + yTri;
            }
            else if (rndMapAnterior.name == "lvl1_diag_up_triangles")
            {
                sumX += rndMapColliderAnterior.size.x;
                sumY += rndMapColliderAnterior.size.y;
            }
            else if (rndMapAnterior.name == "lvl1_up")
            {
                sumX += rndMapColliderAnterior.size.x;
                sumY += rndMapColliderAnterior.size.y;
            }
            else if (rndMapAnterior.name == "lvl1_down")
            {
                sumX += rndMapColliderAnterior.size.x;
                sumY -= rndMapColliderAnterior.size.y - yTri;

            }
        }
        else if (rndMap.name == "lvl1_up")
        {
            if (rndMapAnterior.name == "lvl1_straight")
            {
                sumX += rndMapColliderAnterior.size.x;
            }
            else if (rndMapAnterior.name == "lvl1_diag_down_triangles")
            {
                sumX += rndMapColliderAnterior.size.x;
                sumY -= +rndMapColliderAnterior.size.y + yTri;
            }
            else if (rndMapAnterior.name == "lvl1_diag_up_triangles")
            {
                sumX += rndMapColliderAnterior.size.x;
                sumY += rndMapColliderAnterior.size.y - yTri;
            }
            else if (rndMapAnterior.name == "lvl1_up")
            {
                sumX += rndMapColliderAnterior.size.x;
                sumY += rndMapColliderAnterior.size.y - rndMapColliderAnterior.size.x;
            }
            else if (rndMapAnterior.name == "lvl1_down")
            {
                sumX += rndMapColliderAnterior.size.x;
                sumY += -rndMapColliderAnterior.size.y + yTri;
            }
        }
    }

    private void mapConditions2()
    {
        //LEVEL 2*********************************************************************************
        if (rndMap.name == "lvl2_straight")
        {
            if (rndMapAnterior.name == "lvl2_straight")
            {
                sumX += rndMapColliderAnterior.size.x;

            }
            else if (rndMapAnterior.name == "lvl2_diag_down_triangles")
            {
                sumX += rndMapColliderAnterior.size.x;
                sumY -= rndMapColliderAnterior.size.y;
            }
            else if (rndMapAnterior.name == "lvl2_diag_up_triangles")
            {
                sumX += rndMapColliderAnterior.size.x;
                sumY += rndMapColliderAnterior.size.y - yTri;
            }
            else if (rndMapAnterior.name == "lvl2_up")
            {
                sumX += rndMapColliderAnterior.size.x;
                sumY += rndMapColliderAnterior.size.y - rndMapColliderAnterior.size.x;
            }
            else if (rndMapAnterior.name == "lvl2_down")
            {
                sumX += rndMapColliderAnterior.size.x;
                sumY -= rndMapColliderAnterior.size.y;
            }
        }
        else if (rndMap.name == "lvl2_diag_down_triangles")
        {
            if (rndMapAnterior.name == "lvl2_straight")
            {
                sumX += rndMapColliderAnterior.size.x;
            }
            else if (rndMapAnterior.name == "lvl2_diag_down_triangles")
            {
                sumX += rndMapColliderAnterior.size.x;
                sumY -= rndMapColliderAnterior.size.y;
                Instantiate(Resources.Load<GameObject>("lvl2_diag_down"), new Vector3(sumX, sumY, sumZ - 2), Quaternion.identity, GameObject.Find("NewMap").transform);
            }
            else if (rndMapAnterior.name == "lvl2_diag_up_triangles")
            {
                sumX += rndMapColliderAnterior.size.x;
                //sumY += rndMapColliderAnterior.size.y;
            }
            else if (rndMapAnterior.name == "lvl2_up")
            {
                sumX += rndMapColliderAnterior.size.x;
                sumY += rndMapColliderAnterior.size.y - rndMapColliderAnterior.size.x;
            }
            else if (rndMapAnterior.name == "lvl2_down")
            {
                sumX += rndMapColliderAnterior.size.x;
                sumY -= rndMapColliderAnterior.size.y;
            }
        }
        else if (rndMap.name == "lvl2_diag_up_triangles")
        {
            if (rndMapAnterior.name == "lvl2_straight")
            {
                sumX += rndMapColliderAnterior.size.x;
                sumY += rndMapColliderAnterior.size.y;
            }
            else if (rndMapAnterior.name == "lvl2_diag_down_triangles")
            {
                sumX += rndMapColliderAnterior.size.x;
                sumY += -rndMapColliderAnterior.size.y + yTri;
            }
            else if (rndMapAnterior.name == "lvl2_diag_up_triangles")
            {
                sumX += Resources.Load<GameObject>("lvl2_diag_up").GetComponent<BoxCollider2D>().size.x;
                sumY += Resources.Load<GameObject>("lvl2_diag_up").GetComponent<BoxCollider2D>().size.y;
                sumZ += 1;
                Instantiate(Resources.Load<GameObject>("lvl2_diag_up"), new Vector3(sumX, sumY, sumZ - 2), Quaternion.identity, GameObject.Find("NewMap").transform);
            }
            else if (rndMapAnterior.name == "lvl2_up")
            {
                sumX += rndMapColliderAnterior.size.x;
                sumY += rndMapColliderAnterior.size.y;
            }
            else if (rndMapAnterior.name == "lvl2_down")
            {
                sumX += rndMapColliderAnterior.size.x;
                sumY += -rndMapColliderAnterior.size.y + yTri;
            }
        }
        else if (rndMap.name == "lvl2_down")
        {
            if (rndMapAnterior.name == "lvl2_straight")
            {
                sumX += rndMapColliderAnterior.size.x;
                sumY += rndMapCollider.size.x;
            }
            else if (rndMapAnterior.name == "lvl2_diag_down_triangles")
            {
                sumX += rndMapColliderAnterior.size.x;
                sumY += -rndMapColliderAnterior.size.y + yTri ;
            }
            else if (rndMapAnterior.name == "lvl2_diag_up_triangles")
            {
                sumX += rndMapColliderAnterior.size.x;
                sumY += rndMapColliderAnterior.size.y;
            }
            else if (rndMapAnterior.name == "lvl2_up")
            {
                sumX += rndMapColliderAnterior.size.x;
                sumY += rndMapColliderAnterior.size.y;
            }
            else if (rndMapAnterior.name == "lvl2_down")
            {
                sumX += rndMapColliderAnterior.size.x;
                sumY -= rndMapColliderAnterior.size.y - yTri;

            }
        }
        else if (rndMap.name == "lvl2_up")
        {
            if (rndMapAnterior.name == "lvl2_straight")
            {
                sumX += rndMapColliderAnterior.size.x;
            }
            else if (rndMapAnterior.name == "lvl2_diag_down_triangles")
            {
                sumX += rndMapColliderAnterior.size.x;
                sumY -= rndMapColliderAnterior.size.y ;
            }
            else if (rndMapAnterior.name == "lvl2_diag_up_triangles")
            {
                sumX += rndMapColliderAnterior.size.x;
                sumY += rndMapColliderAnterior.size.y - yTri;
            }
            else if (rndMapAnterior.name == "lvl2_up")
            {
                sumX += rndMapColliderAnterior.size.x;
                sumY += rndMapColliderAnterior.size.y - rndMapColliderAnterior.size.x;
            }
            else if (rndMapAnterior.name == "lvl2_down")
            {
                sumX += rndMapColliderAnterior.size.x;
                sumY -= rndMapColliderAnterior.size.y;
            }
        }
    }

    private void mapConditions3()
    {
        //LEVEL 3*********************************************************************************
        if (rndMap.name == "lvl3_straight")
        {
            if (rndMapAnterior.name == "lvl3_straight")
            {
                sumX += rndMapColliderAnterior.size.x;

            }
            else if (rndMapAnterior.name == "lvl3_diag_down_triangles")
            {
                sumX += rndMapColliderAnterior.size.x;
                sumY -= rndMapColliderAnterior.size.y;
            }
            else if (rndMapAnterior.name == "lvl3_diag_up_triangles")
            {
                sumX += rndMapColliderAnterior.size.x;
                sumY += rndMapColliderAnterior.size.y - yTri;
            }
            else if (rndMapAnterior.name == "lvl3_up")
            {
                sumX += rndMapColliderAnterior.size.x;
                sumY += rndMapColliderAnterior.size.y - rndMapColliderAnterior.size.x;
            }
            else if (rndMapAnterior.name == "lvl3_down")
            {
                sumX += rndMapColliderAnterior.size.x;
                sumY -= rndMapColliderAnterior.size.y;
            }
        }
        else if (rndMap.name == "lvl3_diag_down_triangles")
        {
            if (rndMapAnterior.name == "lvl3_straight")
            {
                sumX += rndMapColliderAnterior.size.x;
            }
            else if (rndMapAnterior.name == "lvl3_diag_down_triangles")
            {
                sumX += rndMapColliderAnterior.size.x;
                sumY -= rndMapColliderAnterior.size.y;
                Instantiate(Resources.Load<GameObject>("lvl3_diag_down"), new Vector3(sumX, sumY, sumZ - 3), Quaternion.identity, GameObject.Find("NewMap").transform);
            }
            else if (rndMapAnterior.name == "lvl3_diag_up_triangles")
            {
                sumX += rndMapColliderAnterior.size.x;
                //sumY += yTri;
            }
            else if (rndMapAnterior.name == "lvl3_up")
            {
                sumX += rndMapColliderAnterior.size.x;
                sumY += rndMapColliderAnterior.size.y - rndMapColliderAnterior.size.x;
            }
            else if (rndMapAnterior.name == "lvl3_down")
            {
                sumX += rndMapColliderAnterior.size.x;
                sumY -= rndMapColliderAnterior.size.y;
            }
        }
        else if (rndMap.name == "lvl3_diag_up_triangles")
        {
            if (rndMapAnterior.name == "lvl3_straight")
            {
                sumX += rndMapColliderAnterior.size.x;
                sumY += rndMapColliderAnterior.size.y;
            }
            else if (rndMapAnterior.name == "lvl3_diag_down_triangles")
            {
                sumX += rndMapColliderAnterior.size.x;
                sumY += -rndMapColliderAnterior.size.y + yTri;
            }
            else if (rndMapAnterior.name == "lvl3_diag_up_triangles")
            {
                sumX += Resources.Load<GameObject>("lvl1_diag_up").GetComponent<BoxCollider2D>().size.x;
                sumY += Resources.Load<GameObject>("lvl1_diag_up").GetComponent<BoxCollider2D>().size.y;
                sumZ += 1;
                Instantiate(Resources.Load<GameObject>("lvl3_diag_up"), new Vector3(sumX, sumY, sumZ - 2), Quaternion.identity, GameObject.Find("NewMap").transform);
            }
            else if (rndMapAnterior.name == "lvl3_up")
            {
                sumX += rndMapColliderAnterior.size.x;
                sumY += rndMapColliderAnterior.size.y;
            }
            else if (rndMapAnterior.name == "lvl3_down")
            {
                sumX += rndMapColliderAnterior.size.x;
                sumY += -rndMapColliderAnterior.size.y + yTri;
            }
        }
        else if (rndMap.name == "lvl3_down")
        {
            if (rndMapAnterior.name == "lvl3_straight")
            {
                sumX += rndMapColliderAnterior.size.x;
                sumY += rndMapCollider.size.x;
            }
            else if (rndMapAnterior.name == "lvl3_diag_down_triangles")
            {
                sumX += rndMapColliderAnterior.size.x;
                sumY += -rndMapColliderAnterior.size.y + yTri;
            }
            else if (rndMapAnterior.name == "lvl3_diag_up_triangles")
            {
                sumX += rndMapColliderAnterior.size.x;
                sumY += rndMapColliderAnterior.size.y;
            }
            else if (rndMapAnterior.name == "lvl3_up")
            {
                sumX += rndMapColliderAnterior.size.x;
                sumY += rndMapColliderAnterior.size.y;
            }
            else if (rndMapAnterior.name == "lvl3_down")
            {
                sumX += rndMapColliderAnterior.size.x;
                sumY -= rndMapColliderAnterior.size.y - yTri;

            }
        }
        else if (rndMap.name == "lvl3_up")
        {
            if (rndMapAnterior.name == "lvl3_straight")
            {
                sumX += rndMapColliderAnterior.size.x;
            }
            else if (rndMapAnterior.name == "lvl3_diag_down_triangles")
            {
                sumX += rndMapColliderAnterior.size.x;
                sumY -= +rndMapColliderAnterior.size.y + yTri;
            }
            else if (rndMapAnterior.name == "lvl3_diag_up_triangles")
            {
                sumX += rndMapColliderAnterior.size.x;
                sumY += rndMapColliderAnterior.size.y - yTri;
            }
            else if (rndMapAnterior.name == "lvl3_up")
            {
                sumX += rndMapColliderAnterior.size.x;
                sumY += rndMapColliderAnterior.size.y - rndMapColliderAnterior.size.x;
            }
            else if (rndMapAnterior.name == "lvl3_down")
            {
                sumX += rndMapColliderAnterior.size.x;
                sumY -= rndMapColliderAnterior.size.y;
            }
        }
    }

    private void mapConditions4()
    {
        //LEVEL 4*********************************************************************************
        if (rndMap.name == "lvl4_straight")
        {
            if (rndMapAnterior.name == "lvl4_straight")
            {
                sumX += rndMapColliderAnterior.size.x;

            }
            else if (rndMapAnterior.name == "lvl4_diag_down_triangles")
            {
                sumX += rndMapColliderAnterior.size.x;
                sumY -= rndMapColliderAnterior.size.y;
            }
            else if (rndMapAnterior.name == "lvl4_diag_up_triangles")
            {
                sumX += rndMapColliderAnterior.size.x;
                sumY += rndMapColliderAnterior.size.y - yTri;
            }
            else if (rndMapAnterior.name == "lvl4_up")
            {
                sumX += rndMapColliderAnterior.size.x;
                sumY += rndMapColliderAnterior.size.y - rndMapColliderAnterior.size.x;
            }
            else if (rndMapAnterior.name == "lvl4_down")
            {
                sumX += rndMapColliderAnterior.size.x;
                sumY -= rndMapColliderAnterior.size.y;
            }
        }
        else if (rndMap.name == "lvl4_diag_down_triangles")
        {
            if (rndMapAnterior.name == "lvl4_straight")
            {
                sumX += rndMapColliderAnterior.size.x;
            }
            else if (rndMapAnterior.name == "lvl4_diag_down_triangles")
            {
                sumX += rndMapColliderAnterior.size.x;
                sumY -= rndMapColliderAnterior.size.y ;
                Instantiate(Resources.Load<GameObject>("lvl4_diag_down"), new Vector3(sumX, sumY, sumZ - 4), Quaternion.identity, GameObject.Find("NewMap").transform);
            }
            else if (rndMapAnterior.name == "lvl4_diag_up_triangles")
            {
                sumX += rndMapColliderAnterior.size.x;
                sumY -=  yTri;
            }
            else if (rndMapAnterior.name == "lvl4_up")
            {
                sumX += rndMapColliderAnterior.size.x;
                sumY += rndMapColliderAnterior.size.y - rndMapColliderAnterior.size.x;
            }
            else if (rndMapAnterior.name == "lvl4_down")
            {
                sumX += rndMapColliderAnterior.size.x;
                sumY -= rndMapColliderAnterior.size.y;
            }
        }
        else if (rndMap.name == "lvl4_diag_up_triangles")
        {
            if (rndMapAnterior.name == "lvl4_straight")
            {
                sumX += rndMapColliderAnterior.size.x;
                sumY += rndMapColliderAnterior.size.y;
            }
            else if (rndMapAnterior.name == "lvl4_diag_down_triangles")
            {
                sumX += rndMapColliderAnterior.size.x;
                sumY += -rndMapColliderAnterior.size.y + yTri;
            }
            else if (rndMapAnterior.name == "lvl4_diag_up_triangles")
            {
                sumX += Resources.Load<GameObject>("lvl1_diag_up").GetComponent<BoxCollider2D>().size.x;
                sumY += Resources.Load<GameObject>("lvl1_diag_up").GetComponent<BoxCollider2D>().size.y;
                sumZ += 1;
                Instantiate(Resources.Load<GameObject>("lvl4_diag_up"), new Vector3(sumX, sumY, sumZ - 2), Quaternion.identity, GameObject.Find("NewMap").transform);
            }
            else if (rndMapAnterior.name == "lvl4_up")
            {
                sumX += rndMapColliderAnterior.size.x;
                sumY += rndMapColliderAnterior.size.y;
            }
            else if (rndMapAnterior.name == "lvl4_down")
            {
                sumX += rndMapColliderAnterior.size.x;
                sumY += -rndMapColliderAnterior.size.y + yTri;
            }
        }
        else if (rndMap.name == "lvl4_down")
        {
            if (rndMapAnterior.name == "lvl4_straight")
            {
                sumX += rndMapColliderAnterior.size.x;
                sumY += rndMapCollider.size.x;
            }
            else if (rndMapAnterior.name == "lvl4_diag_down_triangles")
            {
                sumX += rndMapColliderAnterior.size.x;
                sumY += -rndMapColliderAnterior.size.y + yTri;
            }
            else if (rndMapAnterior.name == "lvl4_diag_up_triangles")
            {
                sumX += rndMapColliderAnterior.size.x;
                sumY += rndMapColliderAnterior.size.y;
            }
            else if (rndMapAnterior.name == "lvl4_up")
            {
                sumX += rndMapColliderAnterior.size.x;
                sumY += rndMapColliderAnterior.size.y;
            }
            else if (rndMapAnterior.name == "lvl4_down")
            {
                sumX += rndMapColliderAnterior.size.x;
                sumY -= rndMapColliderAnterior.size.y - yTri;

            }
        }
        else if (rndMap.name == "lvl4_up")
        {
            if (rndMapAnterior.name == "lvl4_straight")
            {
                sumX += rndMapColliderAnterior.size.x;
            }
            else if (rndMapAnterior.name == "lvl4_diag_down_triangles")
            {
                sumX += rndMapColliderAnterior.size.x;
                sumY -= +rndMapColliderAnterior.size.y + yTri;
            }
            else if (rndMapAnterior.name == "lvl4_diag_up_triangles")
            {
                sumX += rndMapColliderAnterior.size.x;
                sumY += rndMapColliderAnterior.size.y - yTri;
            }
            else if (rndMapAnterior.name == "lvl4_up")
            {
                sumX += rndMapColliderAnterior.size.x;
                sumY += rndMapColliderAnterior.size.y - rndMapColliderAnterior.size.x;
            }
            else if (rndMapAnterior.name == "lvl4_down")
            {
                sumX += rndMapColliderAnterior.size.x;
                sumY -= rndMapColliderAnterior.size.y;
            }
        }
    }
}

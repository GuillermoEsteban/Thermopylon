﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class RandomMap2 : MonoBehaviour
{

    private static List<GameObject> mapsList;
    public int numMapsTotal;
    public int numMaps1;
    public int numMaps2;
    public int numMaps3;
    public int numMaps4;
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

    private Camera main;

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
        sumZ = 0.0f;

        maxX = sumX;
        maxY = sumY;

        rndMap = mapsList[0];//inicialitzem el primer mapa, que sempre serà el lvl1_straight.
        yTri = 25.323f;

        numMaps1 = 10;//Random.Range(2, 5);
        numMaps2 = 10; // Random.Range(3, 7);
        numMaps3 = 10; // Random.Range(5, 8);
        numMaps4 = 10;// Random.Range(7, 10);
        createMap(numMaps1, mapConditions);

        //main = Camera.main;
        //main.GetComponent<CameraController2>().setMax(maxX, maxY);

        mapsList.Clear();

        //Quan el jugador entri a lúltima part del Level1, carregarà el nivell 2, eliminant el primer.
        //També el mini-map es centrarà en el Level 2 creat nou, i els extrems de la càmera del jugador seran els nous del Level2.
        mapsList.Add(Resources.Load<GameObject>("lvl2_straight"));
        mapsList.Add(Resources.Load<GameObject>("lvl2_diag_down_triangles"));
        mapsList.Add(Resources.Load<GameObject>("lvl2_diag_up_triangles"));
        mapsList.Add(Resources.Load<GameObject>("lvl2_down"));
        mapsList.Add(Resources.Load<GameObject>("lvl2_up"));

        yTri += yTri;
        createMap(numMaps2, mapConditions);

        mapsList.Clear();

        mapsList.Add(Resources.Load<GameObject>("lvl3_straight"));
        mapsList.Add(Resources.Load<GameObject>("lvl3_diag_down_triangles"));
        mapsList.Add(Resources.Load<GameObject>("lvl3_diag_up_triangles"));
        mapsList.Add(Resources.Load<GameObject>("lvl3_down"));
        mapsList.Add(Resources.Load<GameObject>("lvl3_up"));

        yTri += yTri;
        createMap(numMaps3, mapConditions);

        mapsList.Clear();

        mapsList.Add(Resources.Load<GameObject>("lvl4_straight"));
        mapsList.Add(Resources.Load<GameObject>("lvl4_diag_down_triangles"));
        mapsList.Add(Resources.Load<GameObject>("lvl4_diag_up_triangles"));
        mapsList.Add(Resources.Load<GameObject>("lvl4_down"));
        mapsList.Add(Resources.Load<GameObject>("lvl4_up"));

        yTri += yTri;
        createMap(numMaps4, mapConditions);
    }


    void Update()
    {

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
            if (i == numMapsTotal)
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
    private void mapConditions()
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
                Instantiate(Resources.Load<GameObject>("lvl1_diag_down"), new Vector3(sumX, sumY, sumZ - 2), Quaternion.identity, GameObject.Find("NewMap").transform);
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
                sumY -= rndMapColliderAnterior.size.y;
            }
        }
        //LEVEL 2*********************************************************************************
        else if (rndMap.name == "lvl2_straight")
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
                sumX += Resources.Load<GameObject>("lvl2_diag_down").GetComponent<BoxCollider2D>().size.x;
                sumY -= Resources.Load<GameObject>("lvl2_diag_down").GetComponent<BoxCollider2D>().size.y;
                Instantiate(Resources.Load<GameObject>("lvl2_diag_down"), new Vector3(sumX, sumY, sumZ - 2), Quaternion.identity, GameObject.Find("NewMap").transform);
            }
            else if (rndMapAnterior.name == "lvl2_diag_up_triangles")
            {
                sumX += rndMapColliderAnterior.size.x;
                sumY += yTri;
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
                sumY += -rndMapColliderAnterior.size.y + yTri;
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
                sumY -= +rndMapColliderAnterior.size.y + yTri;
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
        //LEVEL 3*********************************************************************************
        else if (rndMap.name == "lvl3_straight")
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
                sumX += Resources.Load<GameObject>("lvl3_diag_down").GetComponent<BoxCollider2D>().size.x;
                sumY -= Resources.Load<GameObject>("lvl3_diag_down").GetComponent<BoxCollider2D>().size.y;
                Instantiate(Resources.Load<GameObject>("lvl3_diag_down"), new Vector3(sumX, sumY, sumZ - 2), Quaternion.identity, GameObject.Find("NewMap").transform);
            }
            else if (rndMapAnterior.name == "lvl3_diag_up_triangles")
            {
                sumX += rndMapColliderAnterior.size.x;
                sumY += yTri;
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
                sumX += Resources.Load<GameObject>("lvl3_diag_up").GetComponent<BoxCollider2D>().size.x;
                sumY += Resources.Load<GameObject>("lvl3_diag_up").GetComponent<BoxCollider2D>().size.y;
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
        //LEVEL 4*********************************************************************************
        else if (rndMap.name == "lvl4_straight")
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
                sumX += Resources.Load<GameObject>("lvl4_diag_down").GetComponent<BoxCollider2D>().size.x;
                sumY -= Resources.Load<GameObject>("lvl4_diag_down").GetComponent<BoxCollider2D>().size.y;
                Instantiate(Resources.Load<GameObject>("lvl4_diag_down"), new Vector3(sumX, sumY, sumZ - 2), Quaternion.identity, GameObject.Find("NewMap").transform);
            }
            else if (rndMapAnterior.name == "lvl4_diag_up_triangles")
            {
                sumX += rndMapColliderAnterior.size.x;
                sumY += yTri;
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
                sumX += Resources.Load<GameObject>("lvl4_diag_up").GetComponent<BoxCollider2D>().size.x;
                sumY += Resources.Load<GameObject>("lvl4_diag_up").GetComponent<BoxCollider2D>().size.y;
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

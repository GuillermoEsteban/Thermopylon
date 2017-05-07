using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SpartanArmy : MonoBehaviour {

	public List<GameObject> HenomotiaList;	//Lista que alberga todos los espartanos
	private int numHenomotia;	//Número de espartanos de la henomotia 

	public int startingSpartan;
	public int currentSpartan;

    private int totalNumSpartans;


	void Start()
	{
		numHenomotia = 9;
		HenomotiaList = new List<GameObject>();
        totalNumSpartans = 9 * 36;

        for (int i = 0; i <= numHenomotia; i++)
        {
            HenomotiaList.Add(GameObject.Find("Henomotia (" + i.ToString() + ")"));
        }
	}

    void Update()
    {
        getTotalNumSpartans();
        if (totalNumSpartans == 0)
        {
            SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
        }
    }

    private void getTotalNumSpartans()
    {
        totalNumSpartans = 0;
        for (int i = 0; i <= 9; i++)
        {
            totalNumSpartans += HenomotiaList[i].GetComponent<Henomotia>().numSpartans();
        }
        
    }


}
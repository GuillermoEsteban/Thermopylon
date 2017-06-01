using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SpartanArmy : MonoBehaviour {

    public static List<GameObject> HenomotiaList;// ah de ser pública perquè hi puguin accedir-hi els perses!
	public static int numHenomotia;

    //HUD ANGEL:*******************************************
	public int startingSpartan;
	public int totalNumSpartans;
	public int currentSpartan;
	public Slider NumSpartanSlider;
	public Text NumSpartan;
	public Image damageImage;
	public float flashSpeed = 5f;
	public Color flashColour = new Color(1f, 0f, 0f, 0.1f);
    //******************************************************

	void Start()
	{
        HenomotiaList = new List<GameObject>();
        getNumHenomotias();

		totalNumSpartans = numHenomotia * 36;
		currentSpartan = totalNumSpartans;

        getHenomotias();
	}

    void Update()
    {
        getNumHenomotias();
        getTotalNumSpartans();

		if (totalNumSpartans == 0) {
		
			for (int i = 0; i < 20; i++)
			{
			damageImage.color = flashColour;
			damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
			}
			SceneManager.LoadScene ("GameOver", LoadSceneMode.Single);
		}
    }

    private void getTotalNumSpartans()
    {
		totalNumSpartans = currentSpartan;
		currentSpartan = 0;
        for (int i = 0; i < numHenomotia; i++)
        {
			if (HenomotiaList[i] == null) 
			{
				continue;
			}
            currentSpartan += HenomotiaList[i].GetComponent<Henomotia>().numSpartans();
			NumSpartanSlider.value = currentSpartan;
			NumSpartan.text = currentSpartan.ToString();
        }        

		if (totalNumSpartans - currentSpartan != 0) {
			damageImage.color = flashColour;
		} 
		else 
		{
			damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
		}

    }

    private void getNumHenomotias()
    {
        int numHenomotiaAnterior = numHenomotia;
        numHenomotia = this.gameObject.transform.childCount;//el nombre de childs que té SpartanArmy, on hi ha totes les Henomoties.

        if(numHenomotia != numHenomotiaAnterior)
        {
            getHenomotias();
        }
    }

    private void getHenomotias()
    {
        HenomotiaList.Clear();
        for (int i = 0; i < numHenomotia; i++)
        {
            HenomotiaList.Add(this.gameObject.transform.GetChild(i).gameObject);//cadascun dels childs el va entrant a la llista.
        }
    }
}


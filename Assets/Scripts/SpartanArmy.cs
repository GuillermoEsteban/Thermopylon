using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SpartanArmy : MonoBehaviour {

	public List<GameObject> HenomotiaList;	//Lista que alberga todos los espartanos
	private int numHenomotia;	//Número de espartanos de la henomotia 

	public int startingSpartan;
	public int totalNumSpartans;
	public int currentSpartan;
	public Slider NumSpartanSlider;
	public Text NumSpartan;
	public Image damageImage;
	public float flashSpeed = 5f;
	public Color flashColour = new Color(1f, 0f, 0f, 0.1f);

	public GameObject henomotia;


	bool isDead;  
	bool damaged;  

    


	void Start()
	{
		numHenomotia = 9;
		HenomotiaList = new List<GameObject>();
		totalNumSpartans = 9 * 36;
		currentSpartan = totalNumSpartans;

        for (int i = 0; i <= numHenomotia; i++)
        {
            HenomotiaList.Add(GameObject.Find("Henomotia (" + i.ToString() + ")"));
        }
	}

    void Update()
    {
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
        for (int i = 0; i <= numHenomotia; i++)
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
}


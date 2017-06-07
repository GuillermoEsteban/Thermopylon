using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SpartanArmy : MonoBehaviour
{

    static public List<GameObject> HenomotiaList;// ah de ser pública perquè hi puguin accedir-hi els perses!
    static public List<GameObject> selectedEnomotias;
    static public float playedTime =0.0f;
    static public int persiansKilled = 0;
    public int numHenomotia;

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

    void Awake()
    {
        selectedEnomotias = new List<GameObject>();
        HenomotiaList = new List<GameObject>();
        HenomotiaList.Add((GameObject)Instantiate(Resources.Load("Henomotia"), new Vector3(43.0f, 13.68f, 0.0f), Quaternion.identity));
        HenomotiaList.Add((GameObject)Instantiate(Resources.Load("Henomotia"), new Vector3(31.2f, 13.68f, 0.0f), Quaternion.identity));
        HenomotiaList.Add((GameObject)Instantiate(Resources.Load("Henomotia"), new Vector3(18.8f, 13.68f, 0.0f), Quaternion.identity));
        HenomotiaList.Add((GameObject)Instantiate(Resources.Load("Henomotia"), new Vector3(6.9f, 13.68f, 0.0f), Quaternion.identity));
        HenomotiaList.Add((GameObject)Instantiate(Resources.Load("Henomotia"), new Vector3(-4.8f, 13.68f, 0.0f), Quaternion.identity));
        HenomotiaList.Add((GameObject)Instantiate(Resources.Load("Henomotia"), new Vector3(-16.8f, 13.68f, 0.0f), Quaternion.identity));
        HenomotiaList.Add((GameObject)Instantiate(Resources.Load("Henomotia"), new Vector3(-28.9f, 13.68f, 0.0f), Quaternion.identity));
        HenomotiaList.Add((GameObject)Instantiate(Resources.Load("Henomotia"), new Vector3(-40.6f, 13.68f, 0.0f), Quaternion.identity));
        HenomotiaList.Add((GameObject)Instantiate(Resources.Load("Henomotia"), new Vector3(-52.9f, 13.68f, 0.0f), Quaternion.identity));

        for (int i = 0; i < HenomotiaList.Count; i++)
        {
            HenomotiaList[i].transform.parent = transform;
            HenomotiaList[i].name = "Henomotia " + "(" + i + ")";
        }
        numHenomotia = HenomotiaList.Count;

        totalNumSpartans = numHenomotia * 36;

        currentSpartan = totalNumSpartans;

        GameObject.Find("HUD(Clone)").transform.Find("SpartanHealth").transform.Find("NumSpartan").GetComponent<Text>().text = currentSpartan.ToString();
    }

    void Update()
    {
        spartanKilled();
        gameOver();
        playedTime += Time.deltaTime;
    }

    void spartanKilled()
    {
        if(currentSpartan != totalNumSpartans)
        {
            currentSpartan = totalNumSpartans;
            GameObject.Find("HUD(Clone)").transform.Find("SpartanHealth").transform.Find("NumSpartanSlider").GetComponent<Slider>().value = currentSpartan;
            GameObject.Find("HUD(Clone)").transform.Find("SpartanHealth").transform.Find("NumSpartan").GetComponent<Text>().text = currentSpartan.ToString();

            //damageImage.color = flashColour;

        }
    }

    void gameOver()
    {
        if (totalNumSpartans <= 0)
        {
            //for (int i = 0; i < 20; i++)
            //{
            //    damageImage.color = flashColour;
            //    damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
            //}
            SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
        }
    }

    public void clearSelectedEnomotias()
    {
        foreach (GameObject auxHeno in selectedEnomotias)
        {
            auxHeno.GetComponent<Henomotia>().selected = false;
        }
        selectedEnomotias.Clear();
    }
}


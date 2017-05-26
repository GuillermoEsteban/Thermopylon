using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour {

    private float FadeRate= 2.0f;
    private float timeAlpha;
    private Image image;
    private Color colorAlpha;
    
	// Use this for initialization
	void Start () {
        timeAlpha = 0.0f;

        this.image = this.GetComponent<Image>();

        if (this.image == null)
        {
            Debug.LogError("Error: No image on " + this.name);
        }

        //colorAlpha = this.image.color;
        //colorAlpha.a = 0.0f;
        //this.image.color = colorAlpha; //sembla que no té connexió el color Alpha amb el crossFadeAlpha...

        image.CrossFadeAlpha(0.0f, 0.0f, false);
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (0.0f <= timeAlpha && timeAlpha <= 2.0f)
        {
            image.CrossFadeAlpha(1.0f, 2, false);
        }
        else if (2.5f<= timeAlpha && timeAlpha <= 4.5f)
        {
            image.CrossFadeAlpha(0.0f, FadeRate, false);
        }
        timeAlpha += Time.deltaTime;
        chooseImage();
    }

    private void chooseImage()
    { 
        //if (Time.time == 5.0f)
        //{
        //    image = Resources.Load<Image>("/Backgrounds/intro/intro_history_300_1");
        //    this.image.color = colorAlpha;
        //    timeAlpha = 0.0f;
        //}
        //else if (Time.time == 7.0f)
        //{
        //    image = Resources.Load<Image>("/Backgrounds/intro/intro_history_300_2");
        //    this.image.color = colorAlpha;
        //    timeAlpha = 0.0f;
        //}
        //else if (Time.time == 9.0f)
        //{
        //    image = Resources.Load<Image>("/Backgrounds/intro/intro_history_300_3");
        //    this.image.color = colorAlpha;
        //    timeAlpha = 0.0f;
        //}
        //else if (Time.time == 11.0f)
        //{
        //    image = Resources.Load<Image>("/Backgrounds/intro/intro_history_300_4");
        //    this.image.color = colorAlpha;
        //    timeAlpha = 0.0f;
        //}
        //else if (Time.time == 13.0f)
        //{
        //    image = Resources.Load<Image>("/Backgrounds/intro/intro_history_300_5");
        //    this.image.color = colorAlpha;
        //    timeAlpha = 0.0f;
        //}

        if (Time.time > 4.9 && Time.time < 5.1)
        {
            image.sprite = Resources.Load<Sprite>("Backgrounds/intro/intro_history_300_6");
            //this.image.color = colorAlpha;
            timeAlpha = 0.0f;
        }
        else if (Time.time > 9.9 && Time.time < 10.1)
        {
            image.sprite = Resources.Load<Sprite>("Backgrounds/intro/intro_history_300_the battle of thermopylae");
            //this.image.color = colorAlpha;
            timeAlpha = 0.0f;
        }
        else if (Time.time > 14.9 && Time.time < 15.1)
        {
            image.sprite = Resources.Load<Sprite>("Backgrounds/intro/intro_history_thermopylon");
            //this.image.color = colorAlpha;
            timeAlpha = 0.0f;
        }
        else if((Time.time > 19.9 && Time.time < 20.1))
        {
            SceneManager.LoadScene("MenuPrincipal", LoadSceneMode.Single);
        }
    }
}

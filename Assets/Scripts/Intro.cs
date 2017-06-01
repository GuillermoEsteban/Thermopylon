using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour {

    private float timeAlpha;
    private float minTime;
    private Image image;

    private Image lastImage;

    private bool text;

    // Use this for initialization
    void Start () {
        timeAlpha = 0.0f;
        minTime = 2.5f;

        image = this.GetComponent<Image>();

        if (image == null)
        {
            Debug.LogError("Error: No image on " + this.name);
        }


        image.CrossFadeAlpha(0.0f, 0.0f, false);

        text = false;

        lastImage = GameObject.Find("text").GetComponent<Image>();  
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (!text)
        {
            if (0.0f <= timeAlpha && timeAlpha <= 2.0f)
            {
                image.CrossFadeAlpha(1.0f, 3, false);
            }
            else if (minTime <= timeAlpha && timeAlpha <= minTime+2)
            {
                image.CrossFadeAlpha(0.0f, 3, false);
            }
        }
        else if (text)
        {
            if (0.0f <= timeAlpha && timeAlpha <= 2.0f)
            {
                image.CrossFadeAlpha(1.0f, 1.5f, false);
            }
        }
        timeAlpha += Time.deltaTime;
        chooseImage();
    }

    private void chooseImage()
    {
        if (Time.time > 4.9 && Time.time < 5.1)
        {
            image.sprite = Resources.Load<Sprite>("Backgrounds/intro/intro_history_300_1");
            image.CrossFadeAlpha(0.0f, 0.0f, false);
            timeAlpha = 0.0f;
            text = true;
        }
        else if (Time.time > 7.9f &&Time.time < 8.1f)
        {
            lastImage.GetComponent<IntroText>().text(0);
            image.sprite = Resources.Load<Sprite>("Backgrounds/intro/intro_history_300_2");
            image.CrossFadeAlpha(0.0f, 0.0f, false);
            timeAlpha = 0.0f;
        }
        else if (Time.time > 9.9f && Time.time < 10.1f)
        {
            lastImage.GetComponent<IntroText>().text(1);
            image.sprite = Resources.Load<Sprite>("Backgrounds/intro/intro_history_300_3");
            image.CrossFadeAlpha(0.0f, 0.0f, false);
            timeAlpha = 0.0f;
        }
        else if (Time.time > 11.9f && Time.time < 12.1f)
        {
            lastImage.GetComponent<IntroText>().text(2);
            image.sprite = Resources.Load<Sprite>("Backgrounds/intro/intro_history_300_4");
            image.CrossFadeAlpha(0.0f, 0.0f, false);
            timeAlpha = 0.0f;
        }
        else if (Time.time > 13.9f && Time.time < 14.1f)
        {
            lastImage.GetComponent<IntroText>().text(3);
            image.sprite = Resources.Load<Sprite>("Backgrounds/intro/intro_history_300_5");
            image.CrossFadeAlpha(0.0f, 0.0f, false);
            timeAlpha = 0.0f;
        }

        else if (Time.time > 15.9f && Time.time < 16.1f)
        {
            lastImage.GetComponent<IntroText>().text(4);
            image.sprite = Resources.Load<Sprite>("Backgrounds/intro/intro_history_300_6");
            image.CrossFadeAlpha(0.0f, 0.0f, false);
            timeAlpha = 0.0f;
        }
        else if(Time.time>17.9 && Time.time < 18.1)
        {
            lastImage.GetComponent<IntroText>().text(5);
            text = false;
        }
        else if (Time.time > 24.9f && Time.time < 25.0f)
        {
            if (GameObject.Find("text") != null)
            {
                lastImage.GetComponent<IntroText>().destroyPlease();
            }
            
            image.sprite = Resources.Load<Sprite>("Backgrounds/intro/intro_history_the battle of thermopylae");
            image.CrossFadeAlpha(0.0f, 0.0f, false);
            timeAlpha = 0.0f;
            minTime = 5.0f;
        }
        else if (Time.time > 33.9f && Time.time < 34.1f)
        {
            image.sprite = Resources.Load<Sprite>("Backgrounds/intro/intro_history_thermopylon");
            image.CrossFadeAlpha(0.0f, 0.0f, false);
            timeAlpha = 0.0f;
        }
        else if((Time.time > 35.9f && Time.time < 36.1f))
        {
            SceneManager.LoadScene("Menu Principal", LoadSceneMode.Single);
        }
    }
}

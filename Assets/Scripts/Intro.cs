using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour {

    private float timeAlpha;
    private Image image;

    private Image lastImage;

    private bool text;
    private Vector3 position;

    // Use this for initialization
    void Start () {
        timeAlpha = 0.0f;

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
            else if (2.5f <= timeAlpha && timeAlpha <= 4.5f)
            {
                image.CrossFadeAlpha(0.0f, 3, false);
            }
        }
        else if (text)
        {
            if (0.0f <= timeAlpha && timeAlpha <= 2.0f)
            {
                image.CrossFadeAlpha(1.0f, 2, false);
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
            position = image.sprite.pivot;
        }
        else if (Time.time > 6.9f &&Time.time < 7.1f)
        {
            lastImage.GetComponent<IntroText>().text(0);
            image.sprite = Resources.Load<Sprite>("Backgrounds/intro/intro_history_300_2");
            image.CrossFadeAlpha(0.0f, 0.0f, false);
            timeAlpha = 0.0f;
        }
        else if (Time.time > 8.9f && Time.time < 9.1f)
        {
            lastImage.GetComponent<IntroText>().text(1);
            image.sprite = Resources.Load<Sprite>("Backgrounds/intro/intro_history_300_3");
            image.CrossFadeAlpha(0.0f, 0.0f, false);
            timeAlpha = 0.0f;
        }
        else if (Time.time > 10.9f && Time.time < 11.1f)
        {
            lastImage.GetComponent<IntroText>().text(2);
            image.sprite = Resources.Load<Sprite>("Backgrounds/intro/intro_history_300_4");
            image.CrossFadeAlpha(0.0f, 0.0f, false);
            timeAlpha = 0.0f;
        }
        else if (Time.time > 12.9f && Time.time < 13.1f)
        {
            lastImage.GetComponent<IntroText>().text(3);
            image.sprite = Resources.Load<Sprite>("Backgrounds/intro/intro_history_300_5");
            image.CrossFadeAlpha(0.0f, 0.0f, false);
            timeAlpha = 0.0f;
        }

        if (Time.time > 14.9 && Time.time < 15.1)
        {
            lastImage.GetComponent<IntroText>().text(4);
            image.sprite = Resources.Load<Sprite>("Backgrounds/intro/intro_history_300_6");
            image.CrossFadeAlpha(0.0f, 0.0f, false);
            timeAlpha = 0.0f;
            text = false;
        }
        else if (Time.time > 18.9 && Time.time < 19.1)
        {
            lastImage.GetComponent<IntroText>().destroyPlease();
            image.sprite = Resources.Load<Sprite>("Backgrounds/intro/intro_history_the battle of thermopylae");
            image.CrossFadeAlpha(0.0f, 0.0f, false);
            timeAlpha = 0.0f;
        }
        else if (Time.time > 22.9 && Time.time < 23.1)
        {
            image.sprite = Resources.Load<Sprite>("Backgrounds/intro/intro_history_thermopylon");
            image.CrossFadeAlpha(0.0f, 0.0f, false);
            timeAlpha = 0.0f;
        }
        else if((Time.time > 26.9 && Time.time < 27.1))
        {
            SceneManager.LoadScene("Menu Principal", LoadSceneMode.Single);
        }
    }
}

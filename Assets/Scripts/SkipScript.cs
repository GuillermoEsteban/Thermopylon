using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SkipScript : MonoBehaviour {

    private float timeLast;
    private Image image;
    private bool keyPressed;
	// Use this for initialization
	void Start () {
        timeLast = 0.0f;

        this.image = this.GetComponent<Image>();

        if (this.image == null)
        {
            Debug.LogError("Error: No image on " + this.name);
        }

        image.CrossFadeAlpha(0.0f, 0.0f, false);
        keyPressed = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (!keyPressed)
        {
            if (Input.anyKeyDown)
            {
                timeLast = Time.time;
                image.CrossFadeAlpha(1.0f, 0.5f, false);
                keyPressed = true;
            }
        }

        else
        {
            if(Time.time - timeLast <= 2.0f)
            {
                if (Input.anyKeyDown)
                {
                    SceneManager.LoadScene("Menu Principal", LoadSceneMode.Single);
                }
            }
            else
            {
                keyPressed = false;
                timeLast = Time.time;
                image.CrossFadeAlpha(0.0f, 0.5f, false);
            }
            
        }
        
	}
}

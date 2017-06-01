using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroText : MonoBehaviour {

    private List<Sprite> texts;

	// Use this for initialization
	void Start () {
        texts = new List<Sprite>();
        texts.Add(Resources.Load<Sprite>("Backgrounds/intro/intro_history_300_1"));
        texts.Add(Resources.Load<Sprite>("Backgrounds/intro/intro_history_300_2"));
        texts.Add(Resources.Load<Sprite>("Backgrounds/intro/intro_history_300_3"));
        texts.Add(Resources.Load<Sprite>("Backgrounds/intro/intro_history_300_4"));
        texts.Add(Resources.Load<Sprite>("Backgrounds/intro/intro_history_300_5"));
        texts.Add(Resources.Load<Sprite>("Backgrounds/intro/intro_history_300_6"));

        this.GetComponent<Image>().CrossFadeAlpha(0.0f, 0.0f, false);
    }
	
	public void text(int i)
    {
        this.GetComponent<Image>().sprite = texts[i];
        this.GetComponent<Image>().CrossFadeAlpha(1.0f, 0.0f, false);
    }

    public void destroyPlease()
    {
        Destroy(gameObject);
    }
}

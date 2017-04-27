using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name)
    {
        if(name=="Quit")
        {
            Application.Quit();
        }
        else
        {
            Debug.Log("Opening" + name);
            SceneManager.LoadScene(name);
        }
       
    }
}

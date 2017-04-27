using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_NewGame_controller : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        Debug.Log("In New Game");
        GameData data = GameData.GetInstance();
        data.AddValue("welcome", "hola");

        SceneManager.LoadScene("Prova_Spartan");
    }

    // Update is called once per frame
    void Update()
    {

    }
}

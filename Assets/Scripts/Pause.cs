using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    bool paused = false;
    public GameObject HUD;
    public void Start()
    {
       HUD = GameObject.FindGameObjectWithTag("HUD");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Instantiate(Resources.Load<GameObject>("black_background"),new Vector3(0, 0, -40.0f), Quaternion.identity, transform);
            paused = togglePause();
        }
        if (!paused)
        {
            foreach(Transform child in transform)
            {
                Destroy(child.gameObject);
            }
        }   
    }

    void OnGUI()
    {
        if (paused)
        {
            GUILayout.BeginArea(new Rect((Screen.width / 2) - 50, (Screen.height / 2), 100, 100));
            
            GUILayout.Label("GAME PAUSED");
            if (GUILayout.Button("Resume"))
                paused = togglePause();

            if (GUILayout.Button("Replay"))
                SceneManager.LoadScene("Scenes/NewGame2",LoadSceneMode.Single);

            if (GUILayout.Button("Return to Menu"))
                SceneManager.LoadScene("Scenes/Menu Principal", LoadSceneMode.Single);

            GUILayout.EndArea();
        }
        //SceneManager.LoadScene("Scenes/Pause", LoadSceneMode.Additive);
    }

 

    bool togglePause()
    {
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
            HUD.SetActive(true);
            return (false);
        }
        else
        {
            Time.timeScale = 0f;
            HUD.SetActive(false);
            return (true);
        }
    }
}
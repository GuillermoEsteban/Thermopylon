using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    bool paused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameObject instance = Instantiate(Resources.Load<GameObject>("black_background"),new Vector3(0, 0, -40.0f), Quaternion.identity, this.transform);
            paused = togglePause();
        }
        if (!paused)
        {
            foreach(Transform child in this.transform)
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
            return (false);
        }
        else
        {
            Time.timeScale = 0f;
            return (true);
        }
    }
}
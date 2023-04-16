using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MenuController : MonoBehaviour
{

     public GameManager gameManager;
    public void Start()
    {
        gameManager = GameManager.instance;
    }
    public void ChangeScene(string sceneName)
    {
       gameManager.ChangeScene(sceneName);
    }   

    

    public void QuitGame()
    {
        /*if (Application.isEditor)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
        else
        {*/
        Application.Quit();
        // }

    }
}

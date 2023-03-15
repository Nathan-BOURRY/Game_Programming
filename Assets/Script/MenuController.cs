using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MenuController : MonoBehaviour
{
    private GameManager gameManager;
    private void Start()
    {
        gameManager = GameManager.instance;
    }
    public void ChangeScene(string sceneName)
    {
       gameManager.ChangeScene(sceneName);
    }   

    public void ExitGame()
    {
        gameManager.ExitGame();
    }
}

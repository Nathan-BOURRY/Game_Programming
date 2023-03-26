using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OptionController : MonoBehaviour
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

  
}

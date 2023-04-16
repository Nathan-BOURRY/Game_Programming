using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MenuController : MonoBehaviour
{

    public void StartGame()
    {
        StartCoroutine(LoadScene.LoadLaunchScene("level0"));// Charge la scène "Game"
    }

    public void OpenOptions()
    {
        StartCoroutine(LoadScene.LoadLaunchScene("option")); // Charge la scène "Options"
    }

    public void QuitGame()
    {
        Application.Quit(); // Quitte l'application
    }
}

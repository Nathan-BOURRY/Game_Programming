using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPause : MonoBehaviour
{
    public static bool gameIsPaused = false;

    public GameObject pauseMenuUI;

    //public GameObject settingsWindow;
    void update()
    {
        Debug.Log("yes");
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Paused();
            }
        }
    }
    // public void OnPause()
    // {
    //     Debug.Log("YES");
    //     if (gameIsPaused)
    //     {
    //         Resume();
    //     }
    //     else
    //     {
    //         Paused();
    //     }

    // }

    void Paused()
    {
        //PlayerMovement.instance.enabled = false;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        gameIsPaused = true;
    }

    public void Resume()
    {
        //PlayerMovement.instance.enabled = true;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        gameIsPaused = false;
    }

    // public void OpenSettingsWindow()
    // {
    //     settingsWindow.SetActive(true);
    // }

    // public void CloseSettingsWindow()
    // {
    //     settingsWindow.SetActive(false);
    // }

    public void LoadMainMenu()
    {
        Resume();
        SceneManager.LoadScene("MainMenu");
    }
}

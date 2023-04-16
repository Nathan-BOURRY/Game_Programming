using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    void Start()
    {
        IsGameOver = false;
        DontDestroyOnLoad(transform);
        DontDestroyOnLoad(GameOverUI.transform);
    }

    // Update is called once per frame
    void Update()
    {
        if (IsGameOver)
        {
            StartCoroutine(PageGameOver());
        }


    }

    private IEnumerator PageGameOver()
    {
        Player.DontMove = false;
        GameOverUI.SetActive(true);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Menu");
    }
}

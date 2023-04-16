using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    static public bool IsGameOver;
    public GameObject GameOverUI;
    // Start is called before the first frame update
    void Start()
    {
        IsGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsGameOver)
        {
            Debug.Log("Game Over");
            StartCoroutine(PageGameOver());
        }


    }

    private IEnumerator PageGameOver()
    {

        Player.DontMove = false;
        GameOverUI.SetActive(true);
        yield return new WaitForSeconds(2f);
        GameOverUI.SetActive(false);
        IsGameOver = false;
        SceneManager.LoadScene("Menu");
    }
}

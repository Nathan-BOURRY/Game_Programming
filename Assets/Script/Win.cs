using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{

    static public bool IsWin;
    public GameObject WinUI;
    void Start()
    {
        IsWin = false;
        DontDestroyOnLoad(transform);
        DontDestroyOnLoad(WinUI.transform);
    }

    // Update is called once per frame
    void Update()
    {
        if (IsWin)
        {
            StartCoroutine(PageWin());
            IsWin = false;
        }


    }

    private IEnumerator PageWin()
    {
        Player.DontMove = false;
        WinUI.SetActive(true);
        yield return new WaitForSeconds(2f);
        
        WinUI.SetActive(false);
        SceneManager.LoadScene("Menu");
    }
}

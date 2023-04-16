using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    static Animator animator = null;

    void Awake()
    {
        DontDestroyOnLoad(transform.parent);
    }
    // Start is called before the first frame update
    void Start()
    {
        animator = GameObject.Find("LoadAnimationControler").GetComponent<Animator>();
    }

    public static IEnumerator LoadLaunchScene(string sceneToLoad)
    {
        animator.SetBool("IsLoading", true);
        yield return new WaitForSeconds(1f);
        animator.SetBool("IsLoading", false);
        SceneManager.LoadScene(sceneToLoad);
    }

    // Update is called once per frame
    void Update()
    {

    }
}

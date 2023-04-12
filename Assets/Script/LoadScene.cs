using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{


    string sceneToLoad = "";
    Animator animator = null;

    public static LoadScene instance = null;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(transform.parent.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void LaunchSceneLoad(string sceneToLoad)
    {
        this.sceneToLoad = sceneToLoad;
        animator.SetBool("Opaque", true);
    }

    public void LoadNextScene()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).speed == 1)
        {
            SceneManager.LoadSceneAsync(sceneToLoad).completed += (AsyncOperation op) =>
            {
                animator.SetBool("Opaque", false);
            };
        }


    }

    // Update is called once per frame
    void Update()
    {

    }
}

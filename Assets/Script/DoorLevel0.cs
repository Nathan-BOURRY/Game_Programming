using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class DoorLevel0 : MonoBehaviour
{
    // Start is called before the first frame update
    public bool activedoor;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "player")
        {
            return;
        }
        if (activedoor)
        {
            SceneManager.LoadScene(0);
        }
    }
}

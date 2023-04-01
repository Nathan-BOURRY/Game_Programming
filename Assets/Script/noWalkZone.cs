using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class noWalkZone : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool walk;


    void Start()
    {
        walk = true;
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerStay2D(Collider2D detection)
    {
        if (detection.gameObject.tag == "player")
        {
            walk = false;
        }
    }
    void OnTriggerExit2D(Collider2D detection)
    {
        if (detection.gameObject.tag == "player")
        {
            walk = true;
        }
    }

}

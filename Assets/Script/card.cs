using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class card : MonoBehaviour
{
    Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "player")
        {



            if(tag == "redKey") {
                player.hasRedKey = true;
                Destroy(gameObject);
            } else if (tag == "greenKey") {
                player.hasGreenKey = true;
                Destroy(gameObject);
            }else if (tag == "blueKey") {
                player.hasBlueKey = true;
                Destroy(gameObject);
            }
        }
    }
}

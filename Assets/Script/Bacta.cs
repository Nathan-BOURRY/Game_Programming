using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bacta : MonoBehaviour
{
    // Start is called before the first frame update
    Player player;



    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player" && player.life != 100)
        {
            if (player.life >= 50)
            {
                player.life = 100;
            }
            else
            {
                player.life += 50;
            }
            Destroy(gameObject);
        }
    }
}

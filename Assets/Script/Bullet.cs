using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public Vector2 mouvement;
    public float speed;


    // Start is called before the first frame update
    void Start()
    {

        GetComponent<Rigidbody2D>().velocity = mouvement * speed;

    }

    // Update is called once per frame
    void Update()
    {

        Destroy(gameObject, 1.4f);
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "bordure" || collision.gameObject.tag == "munition" || collision.gameObject.tag == "droid")
        {
            Destroy(gameObject);
            //todo : animation du laser qui explose
        }
    }


}



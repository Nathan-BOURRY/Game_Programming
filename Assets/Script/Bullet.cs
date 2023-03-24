using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{


    public float speed;
    public Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
<<<<<<< HEAD
        rb = GetComponent<Rigidbody2D>();

        if (player.isLeft)
        {
            gameObject.transform.localScale = new Vector3(-1, (float)0.6, (float)0.6);
            rb.velocity = -transform.right * speed;
        }
        else
        {
            gameObject.transform.localScale = new Vector3(1, (float)0.6, (float)0.6);
            rb.velocity = transform.right * speed;
=======
        rb = GetComponent<Rigidbody>();

        

        if(Player.isLeft){ 
                gameObject.transform.localScale = new Vector3 (-1,(float)0.6,(float)0.6);
              rb.velocity = -transform.right * speed;
        }else {
             gameObject.transform.localScale = new Vector3 (1,(float)0.6,(float)0.6);
              rb.velocity = transform.right * speed;
>>>>>>> origin/Dev_Mélaine
        }
        //tirer dans l'autre sens
        // rb.velocity = transform.up * speed;
        // rb.velocity = -transform.right * speed;
        // rb.velocity = - transform.up * speed;

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



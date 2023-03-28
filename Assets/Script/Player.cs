using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;
public class Player : MonoBehaviour
{

    public float speed = 10.0f;
    Rigidbody2D rbody = null;
    public Vector2 movement = Vector2.zero;

    Vector2 velocity = Vector2.zero;

    SpriteRenderer spr = null;

    public int numberOfBullet;

    public int life = 100;

    public AudioSource audio;

    int randomValue;


    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        spr = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        velocity.x = movement.x * speed;
        velocity.y = movement.y * speed;

        if (movement.x != 0)
        {
            spr.flipX = movement.x < 0;
        }

        rbody.velocity = new Vector2(velocity.x, velocity.y);
    }

    public void OnMove(InputValue val)
    {
        movement = val.Get<Vector2>();
        if (movement != Vector2.zero)
        {
            //TODO Ajout de l'audio de déplacement ;)
            GetComponent<Weapon>().playerMovement = movement;
        }
    }




    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("test = " + collision.gameObject.tag);
        if (collision.gameObject.tag == "munition")
        {
            Destroy(collision.gameObject);
            randomValue = Random.Range(20, 151);

            //todo afficher +nbbullet sur le hud
            if (numberOfBullet < 500)
            {
                numberOfBullet = numberOfBullet + randomValue;
                if (numberOfBullet > 500)
                {
                    numberOfBullet = 500;
                }
            }
            audio.Play();
        }



        if (life > 0)
        {
            //todo : faire pour des tirs de blaster
            if (collision.gameObject.tag == "droid")
            {
                life = life - 10;
            }
        }
        else
        {
            //TODO : you dead
        }

    }
}


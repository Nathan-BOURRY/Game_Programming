using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;
public class Player : MonoBehaviour
{

    public static bool isLeft = false;
<<<<<<< HEAD
    public static bool isUp = false;
    private CharacterController controller = null;
=======
>>>>>>> Dev_Nathan
    public float speed = 10.0f;
    Rigidbody2D rbody = null;
    Vector2 movement = Vector2.zero;

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
        //Debug.Log("direction left = "+ isLeft);
        velocity.x = movement.x * speed;
        velocity.y = movement.y * speed;

<<<<<<< HEAD

        if(velocity.y < 0 ){
           // Debug.Log("isUp = " + isUp);
         isUp = false;
       } 

        if(velocity.y > 0 ){
         isUp = true;
       } 

       if(velocity.x < 0 ){
         isLeft = true;
       } 
=======
>>>>>>> Dev_Nathan

        if (velocity.x < 0)
        {
            isLeft = true;
        }

        if (velocity.x > 0)
        {
            isLeft = false;
        }

        if (movement.x != 0)
        {

            spr.flipX = movement.x < 0;
        }

        rbody.velocity = new Vector2(velocity.x, velocity.y);
    }

    public void OnMove(InputValue val)
    {

        movement = val.Get<Vector2>();
    }




    void OnControllerColliderHit(ControllerColliderHit collision)
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


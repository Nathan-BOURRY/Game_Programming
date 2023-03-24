using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class player : MonoBehaviour
{

    public static bool isLeft = false;
    public float speed = 10.0f;
    Rigidbody2D rbody = null;
    Vector2 movement = Vector2.zero;

    Vector2 velocity = Vector2.zero;

    SpriteRenderer spr = null;

    public AudioSource audio;


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




    void OnControllerColliderHit2D(ControllerColliderHit collision)
    {
        Debug.Log("test = " + collision.gameObject.tag);
        if (collision.gameObject.tag == "munition")
        {
            Destroy(collision.gameObject);
            audio.Play();
        }

    }
}


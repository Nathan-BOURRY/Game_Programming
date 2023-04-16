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
    public Animator animator;

    public int numberOfBullet;

    public int life;
    public bool hasScanKey = false;
    public bool hasScanGreenKey = false;
    public bool hasScanBlueKey = false;

    public bool hasRedKey = false;
    public bool hasGreenKey = false;
    public bool hasBlueKey = false;

    public bool heWasDown = false;
    public bool heWasUp = false;

    public static bool gameIsEnd = false;

    DoorAction doorAction;

    public AudioSource walksound;
    public AudioSource itemSound;
    public AudioSource BactaSound;

    public AudioSource ammoSound;
    public AudioSource takeAShot;
    public AudioSource deadSound;
    int randomValue;
    card card;
    generated_all generated_all;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        spr = GetComponent<SpriteRenderer>();
        doorAction = FindObjectOfType<DoorAction>();
        card = FindObjectOfType<card>();
        generated_all = FindObjectOfType<generated_all>();

        animator = GetComponent<Animator>();

    }


    animator = GetComponent<Animator>();
        DontMove = true;

    // Update is called once per frame
    void Update()
    {


        velocity = movement * speed;

        if (movement.x != 0)
        {
            if (!heWasDown || !heWasUp)
            {
                spr.flipX = movement.x < 0;
            }
            animator.SetBool("isDown", false);
            animator.SetBool("isUp", false);
            animator.SetBool("isWalkingUp", false);
            animator.SetBool("isWalkingDown", false);
            animator.SetBool("isWalking", true);
            heWasDown = false;
            heWasUp = false;


        }
        if (movement.y > 0)
        {
            // Le joueur monte

            animator.SetBool("isWalking", false);
            animator.SetBool("isWalkingDown", false);
            animator.SetBool("isUp", true);
            animator.SetBool("isDown", false);
            animator.SetBool("isWalkingUp", true);

            heWasDown = false;
            heWasUp = true;

        }
        else if (movement.y < 0)
        {
            // Le joueur descend

            animator.SetBool("isWalking", false);
            animator.SetBool("isWalkingDown", true);
            animator.SetBool("isUp", false);
            animator.SetBool("isDown", true);
            animator.SetBool("isWalkingUp", false);

            heWasDown = true;
            heWasUp = false;
        }

        if (movement.y != 0 && movement.x != 0)
        {
            animator.SetBool("isWalking", true);

            heWasDown = false;
            heWasUp = false;
        }

        if (movement.y == 0 && movement.x == 0)
        {
            animator.SetBool("isWalkingDown", false);
            animator.SetBool("isWalkingUp", false);

            if (heWasDown)
            {
                animator.SetBool("isDown", true);
                animator.SetBool("isUp", false);

            }
            else if (heWasUp)
            {
                animator.SetBool("isDown", false);
                animator.SetBool("isUp", true);

            }
            else
            {
                animator.SetBool("isDown", false);
                animator.SetBool("isUp", false);


            }
        }

        rbody.velocity = new Vector2(velocity.x, velocity.y);
    }






    public void OnMove(InputValue val)
    {
        movement = val.Get<Vector2>();
        if (movement != Vector2.zero)
        {

            GetComponent<Weapon>().playerMovement = movement;

            animator.SetBool("isWalking", true);

            if (!walksound.isPlaying)
            {
                walksound.Play();
            }
        }
        else
        {
            animator.SetBool("isWalking", false);

            if (walksound.isPlaying)
            {
                walksound.Stop();
            }
        }
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (life > 0)
        {
            if (collision.gameObject.tag == "balle")
            {
                life = life - 10;
                takeAShot.Play();
                if (life <= 0)
                {
                    deadSound.Play();

                }
            }

        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "munition")
        {
            Destroy(collision.gameObject);
            randomValue = Random.Range(20, 151);


            if (numberOfBullet < 500)
            {
                numberOfBullet = numberOfBullet + randomValue;
                if (numberOfBullet > 500)
                {
                    numberOfBullet = 500;
                }
            }
            ammoSound.Play();
        }
        else if (collision.gameObject.tag == "bacta" && life != 100)
        {
            if (life >= 50)
            {
                life = 100;
            }
            else
            {
                life += 50;
            }
            Destroy(collision.gameObject);
            BactaSound.Play();
        }

        else if (collision.gameObject.tag == "terminal")
        {
            if (hasRedKey)
            {

                hasScanKey = true;
            }

        }
        else if (collision.gameObject.tag == "terminalGreen")
        {
            if (hasGreenKey)
            {

                hasScanGreenKey = true;

            }
        }
        else if (collision.gameObject.tag == "terminalBlue")
        {
            if (hasBlueKey)
            {

                hasScanBlueKey = true;

            }

        }
        else if (collision.gameObject.name == "redCard" || collision.gameObject.name == "blueCard" || collision.gameObject.name == "greenCard")
        {

            StartCoroutine(generated_all.EnableTextMesh(collision.gameObject));
            itemSound.Play();
            Destroy(collision.gameObject);

            // if (Input.GetKeyDown(KeyCode.E)) {
            //Debug.Log("test");
            hasScanKey = true;

        }
        else if (collision.gameObject.tag == "win")
        {

            StartCoroutine(generated_all.EnableTextMesh(collision.gameObject));
        }

    }
        else if (collision.gameObject.tag == "terminalGreen")
        {
            if (hasGreenKey)
            {

                // if (Input.GetKeyDown(KeyCode.E)) {
                //Debug.Log("test");
                hasScanGreenKey = true;

    }




}


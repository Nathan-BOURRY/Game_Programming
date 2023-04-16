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

    public int life;
    public bool hasScanKey = false;
    public bool hasScanGreenKey = false;
    public bool hasScanBlueKey = false;

    public bool hasRedKey = false;
    public bool hasGreenKey = false;
    public bool hasBlueKey = false;

    DoorAction doorAction;

    public static bool gameIsEnd = false;
    public GameObject endMenuUI;

    public GameManager gameManager;



    public AudioSource audio;

    int randomValue;

    card card;
    generated_all generated_all;


    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        spr = GetComponent<SpriteRenderer>();
        doorAction = FindObjectOfType<DoorAction>();
        card = FindObjectOfType<card>();
        generated_all = FindObjectOfType<generated_all>();
        //Resume();



    }

    // Update is called once per frame
    void Update()
    {


        velocity = movement * speed;

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

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (life > 0)
        {
            //todo : faire pour des tirs de blaster
            if (collision.gameObject.tag == "balle")
            {
                life = life - 10;
            }

        }
        else
        {
            //TODO ANIMATION DE MORT !

            //Resume();

        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("test = " + collision.gameObject.tag);
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

        else if (collision.gameObject.tag == "terminal")
        {
            if (hasRedKey)
            {

                // if (Input.GetKeyDown(KeyCode.E)) {
                //Debug.Log("test");
                hasScanKey = true;

                // }
            }

        }
        else if (collision.gameObject.tag == "terminalGreen")
        {
            if (hasGreenKey)
            {

                // if (Input.GetKeyDown(KeyCode.E)) {
                //Debug.Log("test");
                hasScanGreenKey = true;

                //}
            }
        }
        else if (collision.gameObject.tag == "terminalBlue")
        {
            if (hasBlueKey)
            {

                // if (Input.GetKeyDown(KeyCode.E)) {
                // Debug.Log("test");
                hasScanBlueKey = true;

                // }
            }
        }
        else if (collision.gameObject.name == "redCard" || collision.gameObject.name == "blueCard" || collision.gameObject.name == "greenCard")
        {

            StartCoroutine(generated_all.EnableTextMesh(collision.gameObject));
            Destroy(collision.gameObject);


        }



    }
    // public void Resume()
    // {
    //     //endMenuUI.SetActive(false);
    //     Time.timeScale = 1f;
    //     gameIsEnd = false;
    // }

    // public void ChangeScene(string sceneName)
    // {
    //     gameManager.ChangeScene(sceneName);
    // }

    // public void ExitGame()
    // {
    //     gameManager.ExitGame();
    // }


}


using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour
{
    public GameObject Bullet;
    public Transform Spawn;
    public AudioSource audio;
    //public AudioSource audio2;
    int nbBullet;
    Player player;

    float rotation;
    GameObject instanBullet;
    public Vector2 playerMovement;




    void Start()
    {

        // Recherche l'objet qui a le script "Player" attaché
        player = FindObjectOfType<Player>();

        // Accède à la variable "nbBullet" à partir de l'objet "player"


    }




    // Update is called once per frame
    void Update()
    {
        // if (Gamepad.current.xButton.wasPressedThisFrame)
        // {
        //     Debug.Log("YES");
        // }
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            if (player.numberOfBullet > 0)
            {
                audio.Play();
                player.numberOfBullet = player.numberOfBullet - 1;
                rotation = Mathf.Rad2Deg * Mathf.Atan2(-playerMovement.x, playerMovement.y) + 90;
                if (rotation == 180)
                {
                    instanBullet = Instantiate(Bullet, new Vector2(Spawn.position.x - 0.8f, Spawn.position.y), Quaternion.Euler(0, 0, rotation));
                }
                else
                {
                    instanBullet = Instantiate(Bullet, Spawn.position, Quaternion.Euler(0, 0, rotation));
                }
                instanBullet.GetComponent<Bullet>().mouvement = playerMovement;

            }
            else
            {
                //todo : text no bullet to show on hud
                //Debug.Log("plus de balle");
                /*if(audio2.isPlaying == false){
                    audio2.Play();
                }*/
            }
        }
    }
}



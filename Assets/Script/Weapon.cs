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
    public AudioSource audio2;
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

        if(player.animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f )
        {
            player.animator.SetBool("isFire", false);
            
        }
        // if (Gamepad.current.xButton.wasPressedThisFrame)
        // {
        //     Debug.Log("YES");
        // }
        //if (Keyboard.current.spaceKey.wasPressedThisFrame)
        //{

        //}

    }
    public void OnFire()
    {
        if (player.numberOfBullet > 0)
        {
            audio.Play();
            player.numberOfBullet = player.numberOfBullet - 1;
            rotation = Mathf.Rad2Deg * Mathf.Atan2(-playerMovement.x, playerMovement.y) + 90;

            //TODO : Fix Spawn bullet with animation

            if (rotation >= 45 && rotation <= 135) // En haut
            {
<<<<<<< HEAD
                instanBullet = Instantiate(Bullet, new Vector2(Spawn.position.x, Spawn.position.y + 0.5f), Quaternion.Euler(0, 0, rotation));
=======
                audio.Play();
                player.animator.SetBool("isFire", true);
                player.numberOfBullet = player.numberOfBullet - 1;
                rotation = Mathf.Rad2Deg * Mathf.Atan2(-playerMovement.x, playerMovement.y) + 90;

                //TODO : Fix Spawn bullet with animation

                if (rotation >= 45 && rotation <= 135) // En haut
                {
                    instanBullet = Instantiate(Bullet, new Vector2(Spawn.position.x -0.75f, Spawn.position.y + 0.5f), Quaternion.Euler(0, 0, rotation));
                }
                else if (rotation > 135 && rotation <= 225) //A gauche
                {
                    instanBullet = Instantiate(Bullet, new Vector2(Spawn.position.x - 1.5f, Spawn.position.y), Quaternion.Euler(0, 0, rotation));
                }
                else if (rotation > 225 && rotation <= 315)//En bas
                {
                    instanBullet = Instantiate(Bullet, new Vector2(Spawn.position.x -0.75f, Spawn.position.y + 0.5f), Quaternion.Euler(0, 0, rotation));
                }
                else //Droite
                {
                    instanBullet = Instantiate(Bullet, new Vector2(Spawn.position.x + 0.6f, Spawn.position.y), Quaternion.Euler(0, 0, rotation));
                }
                instanBullet.GetComponent<Bullet>().mouvement = playerMovement;

>>>>>>> Dev_Mélaine
            }
            else if (rotation > 135 && rotation <= 225) //A gauche
            {
<<<<<<< HEAD
                instanBullet = Instantiate(Bullet, new Vector2(Spawn.position.x - 1.5f, Spawn.position.y), Quaternion.Euler(0, 0, rotation));
=======
                //todo : text no bullet to show on hud
                //Debug.Log("plus de balle");
                if(audio2.isPlaying == false){
                    audio2.Play();
                }
>>>>>>> Dev_Mélaine
            }
            else if (rotation > 225 && rotation < 315)
            {
                instanBullet = Instantiate(Bullet, new Vector2(Spawn.position.x, Spawn.position.y - 0.5f), Quaternion.Euler(0, 0, rotation));
            }
            else //Droite
            {
                instanBullet = Instantiate(Bullet, new Vector2(Spawn.position.x + 0.6f, Spawn.position.y), Quaternion.Euler(0, 0, rotation));
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



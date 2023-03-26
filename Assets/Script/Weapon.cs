using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour
{
    public GameObject Bullet;
    public Transform Spawn;
    public Transform Spawn2;
    //public Transform SpawnUp;
    //public Transform SpawnDown;
    public AudioSource audio;
    public AudioSource audio2;
    int nbBullet;
    Player player;




    void Start()
    {

        // Recherche l'objet qui a le script "Player" attaché
        player = FindObjectOfType<Player>();

        // Accède à la variable "nbBullet" à partir de l'objet "player"


    }




    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            if (player.numberOfBullet > 0)
            {
                audio.Play();
                player.numberOfBullet = player.numberOfBullet - 1;
                if (Player.isLeft)
                {
                    Instantiate(Bullet, Spawn2.position, Quaternion.identity);
                }
                else
                {
                    Instantiate(Bullet, Spawn.position, Quaternion.identity);
                }
                if (Player.isUp)
                {
                   // Instantiate(Bullet, SpawnUp.position, Quaternion.identity);

                }
            }
            else
            {
                //todo : text no bullet to show on hud
                //Debug.Log("plus de balle");
                audio2.Play();
            }
        }
    }
}



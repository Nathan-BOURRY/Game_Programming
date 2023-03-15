using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour
{
    public GameObject Bullet;    
    public Transform Spawn;
    public Transform Spawn2;
    public AudioSource audio;

    void Start()
    {
     
    }


    

    // Update is called once per frame
    void Update()
    {
         if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            audio.Play();  
            
            if(player.isLeft){
                 Instantiate(Bullet, Spawn2.position, Quaternion.identity);
            }else {
                 Instantiate(Bullet, Spawn.position, Quaternion.identity);
            }
          
             }
             }

             
    }



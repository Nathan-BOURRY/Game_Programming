using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;
public class Player : MonoBehaviour
{

    public static bool isLeft = false;
    private CharacterController controller = null;
    public float speed = 10.0f;
    

    Vector2 movement = Vector2.zero;

    Vector2 velocity = Vector2.zero;

    SpriteRenderer spr = null;

    public int numberOfBullet;

    public int life=100;

    public AudioSource audio;

     int randomValue;


    // Start is called before the first frame update
    void Start()
    {
        
        controller = gameObject.AddComponent<CharacterController>();
        spr = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("direction left = "+ isLeft);
    
        velocity.x = movement.x*speed;
        velocity.y = movement.y*speed;

       if(velocity.x < 0 ){
         isLeft = true;
       } 

       if(velocity.x > 0 ){
         isLeft = false;
       } 
       
        if(movement.x != 0){
                
            spr.flipX = movement.x < 0;
        }
        
        controller.Move(velocity * Time.deltaTime);
    }

    public void OnMove(InputValue val){
        
        movement = val.Get<Vector2>();
            }


         

        void OnControllerColliderHit(ControllerColliderHit collision){
                   Debug.Log("test = "+ collision.gameObject.tag);
        if(collision.gameObject.tag == "munition"){
            Destroy(collision.gameObject);
             randomValue = Random.Range(20, 151); 

             //todo afficher +nbbullet sur le hud
             if( numberOfBullet < 500){
             numberOfBullet = numberOfBullet + randomValue;
             if(numberOfBullet > 500){
                numberOfBullet =500;
             }
             }
              audio.Play();  
        }


                
                if(life > 0){
                //todo : faire pour des tirs de blaster
                if(collision.gameObject.tag == "droid"){
                    life = life - 10;
                }
                }else {
                    //TODO : you dead
                }
        
    }
    }
 

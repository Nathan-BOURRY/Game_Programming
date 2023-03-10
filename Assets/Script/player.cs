using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class player : MonoBehaviour
{


    private CharacterController controller = null;
    public float speed = 10.0f;

    Vector2 movement = Vector2.zero;

    Vector2 velocity = Vector2.zero;

    SpriteRenderer spr = null;


    // Start is called before the first frame update
    void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();
        spr = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        velocity.x = movement.x*speed;
        velocity.y = movement.y*speed;
      
       
       
        if(movement.x != 0){
            spr.flipX = movement.x < 0;
        }
        
        controller.Move(velocity * Time.deltaTime);
    }

    void OnMove(InputValue val){
        movement = val.Get<Vector2>();
            }
    }
 

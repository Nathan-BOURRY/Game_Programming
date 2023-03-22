using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    
    public float speed;
    public Rigidbody rb;

    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if(Player.isLeft){ 
                gameObject.transform.localScale = new Vector3 (-1,(float)0.6,(float)0.6);
              rb.velocity = -transform.right * speed;
        }else {
             gameObject.transform.localScale = new Vector3 (1,(float)0.6,(float)0.6);
              rb.velocity = transform.right * speed;
        }
        //tirer dans l'autre sens
        // rb.velocity = transform.up * speed;
        // rb.velocity = -transform.right * speed;
          // rb.velocity = - transform.up * speed;
      
    }

    // Update is called once per frame
    void Update()
    {
        
       Destroy(gameObject, 1.4f);
    }


    void OnCollisionEnter (Collision collision){
        if(collision.gameObject.tag == "bordure" ||collision.gameObject.tag == "munition"  ||collision.gameObject.tag == "droid" ){
            Destroy(gameObject);
        }
    }
}



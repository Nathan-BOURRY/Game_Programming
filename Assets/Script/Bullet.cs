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
        rb.velocity = transform.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
       Destroy(gameObject, 0.8f);
    }


    void OnCollisionEnter (Collision collision){
        if(collision.gameObject.tag == "bordure" ||collision.gameObject.tag == "munition"  ){
            Destroy(gameObject);
        }
    }
}



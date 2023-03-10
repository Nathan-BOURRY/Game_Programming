

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class munition : MonoBehaviour
{

      public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
          rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnCollisionEnter (Collision collision){

          Debug.Log("test munition = "+ collision.gameObject.tag);
        if(collision.gameObject.tag == "player"){
            Destroy(gameObject);
        }
    }
}

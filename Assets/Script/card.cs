using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class card : MonoBehaviour
{
    Player player;
    generated_all generated_all;
    
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
         generated_all = FindObjectOfType<generated_all>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "player")
        {

            StartCoroutine(generated_all.EnableTextMesh(this.gameObject));
             Destroy(gameObject);
    

        }
    }

    
}

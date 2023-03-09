using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Interaction : MonoBehaviour
{

    public string levelToLoad = "";
    void OnTriggerEnter2D(Collider2D other){
        if(other.name != "Player"){
            return;
        }
        
        
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAction : MonoBehaviour
{

    Animator animator;
    int compteur;

     
    // Start is called before the first frame update
    void Start()
    {
          animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(compteur);
        Debug.Log(animator.GetBool("needToOpen"));
    }

    void OnTriggerEnter2D(Collider2D other)
    {
           
        //todo : 
        if (other.gameObject.tag == "player" || other.gameObject.tag == "droid")
        {
            compteur ++;
            if(compteur == 1){
            animator.SetBool("needToOpen", true);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        //todo : 
        if (other.gameObject.tag == "player" || other.gameObject.tag == "droid")
        {

            compteur --;
            if(compteur == 0){
                animator.SetBool("needToOpen", false);
            }
        }
    }

    void SetTrueFinish (){
        animator.SetBool("finishAnimDoor", true);
    }

    void SetFalseFinish (){
        animator.SetBool("finishAnimDoor", false);
    }
}

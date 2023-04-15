using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DoorAction : MonoBehaviour
{

Animator animator;
int compteur=0;
Player player;
TextMeshProUGUI textmeshPro;
private float timer = 5f;
bool hasRedKey = false;
public bool hasScanKey = false;
bool hasBlueKey = false;
public bool hasScanBlueKey = false;
bool hasGreenKey = false;
public bool hasScanGreenKey = false;
public AudioSource openDoorSound;
public AudioSource closeDoorSound;


    
// Start is called before the first frame update
void Start()
{
        animator = GetComponent<Animator>();
        player = FindObjectOfType<Player>();
        textmeshPro = GameObject.Find("noKey").GetComponent<TextMeshProUGUI>();
        textmeshPro.enabled = false;
}

// Update is called once per frame
void Update()
{
    hasRedKey = player.hasRedKey;
    hasScanKey = player.hasScanKey;
    hasBlueKey = player.hasBlueKey;
    hasScanBlueKey = player.hasScanBlueKey;
    hasGreenKey = player.hasGreenKey;
    hasScanGreenKey = player.hasScanGreenKey;

    
    
}

void OnTriggerEnter2D(Collider2D other)
{

    //todo : 
    if (other.gameObject.tag == "player")
    {
        compteur ++;

        if(gameObject.tag == "simpleDoor"){
            if(compteur == 1){
                    
                animator.SetBool("needToOpen", true);
                if(closeDoorSound.isPlaying){
                    closeDoorSound.Stop();
                    
                }
                openDoorSound.Play();

                
                }

        } else if(gameObject.tag == "redKey"){
    
    
            if(hasRedKey && hasScanKey){
                
            
                if(compteur == 1){
                    
                animator.SetBool("needToOpen", true);
                if(closeDoorSound.isPlaying){
                    closeDoorSound.Stop();
                    
                }
                openDoorSound.Play();

                
                }
            } else if (hasRedKey){

                textmeshPro.text ="Scan the red key on the terminal !";
                textmeshPro.enabled = true;

            } else {

                
            
                //Debug.Log("n'a pas la clé");
                textmeshPro.text ="You need the red Key !";
                textmeshPro.enabled = true;

            }
        }else if(gameObject.tag == "greenKey"){
            if(hasGreenKey && hasScanGreenKey){
                if(compteur == 1){
                animator.SetBool("needToOpen", true);
                if(closeDoorSound.isPlaying){
                    closeDoorSound.Stop();
                    
                }
                openDoorSound.Play();
                }
            } else if (hasGreenKey){

                textmeshPro.text ="Scan the green key on the terminal !";
                textmeshPro.enabled = true;

            } else {

                //Debug.Log("n'a pas la clé");
                textmeshPro.text ="You need the green Key !";
                textmeshPro.enabled = true;

            }

            }else if(gameObject.tag == "blueKey"){
            if(hasBlueKey && hasScanBlueKey){
                if(compteur == 1){
                animator.SetBool("needToOpen", true);
                if(closeDoorSound.isPlaying){
                    closeDoorSound.Stop();
                    
                }
                openDoorSound.Play();
                }
            } else if (hasBlueKey){

                textmeshPro.text ="Scan the blue key on the terminal !";
                textmeshPro.enabled = true;

            } else {

                //Debug.Log("n'a pas la clé");
                textmeshPro.text ="You need the blue Key !";
                textmeshPro.enabled = true;

            }
            }
            
    } else if (other.gameObject.tag == "droid"){
            
            compteur ++;
            if(compteur == 1){
            animator.SetBool("needToOpen", true);
            if(closeDoorSound.isPlaying){
                    closeDoorSound.Stop();
                    
                }
                openDoorSound.Play();
            
            }
    }
}

void OnTriggerExit2D(Collider2D other)
{
    //todo : 
    if (other.gameObject.tag == "player" || other.gameObject.tag == "droid")
    {

        textmeshPro.enabled = false;

        compteur --;
            

        if(compteur == 0){
            animator.SetBool("needToOpen", false);
                if(gameObject.tag == "SimpleDoor"){
            
                if(openDoorSound.isPlaying){
                    openDoorSound.Stop();
                    closeDoorSound.Play();
                    
                }   
                }
            
                
            else  if(gameObject.tag == "redKey"){
            if(hasScanKey){
                if(openDoorSound.isPlaying){
                    openDoorSound.Stop();
                    closeDoorSound.Play();
                    
                }
            }
            
        } else if (gameObject.tag == "greenKey"){
            if(hasScanGreenKey){
                if(openDoorSound.isPlaying){
                    openDoorSound.Stop();
                    closeDoorSound.Play();
                    
                }
            }
        } else if (gameObject.tag == "blueKey"){
            if(hasScanBlueKey){
                if(openDoorSound.isPlaying){
                    openDoorSound.Stop();
                    closeDoorSound.Play();
                    
                }
            }
        }
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

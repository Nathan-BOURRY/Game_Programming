using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class scanKey : MonoBehaviour
{
     public Sprite spriteCheck;
     TextMeshProUGUI textmeshPro;
    Player player;
    public AudioSource cardSwipeSound;
    
    DoorAction doorAction;
    bool hasRedKey = false;
    bool hasScanKey = false;
    bool hasBlueKey = false;
    bool hasScanBlueKey = false;
    bool hasGreenKey = false;
    bool hasScanGreenKey = false; 
    private bool hasPlayedRed = false;
    private bool hasPlayedBlue = false;
    private bool hasPlayedGreen = false; 
    lightDoor lightDoor;
    lightDoor lightDoorGreen;
    lightDoor lightDoorBlue;
    SpriteRenderer spriteRenderer;
     UnityEngine.Rendering.Universal.Light2D light2DredDoorRed;
     UnityEngine.Rendering.Universal.Light2D light2DgreenDoorRed;
     UnityEngine.Rendering.Universal.Light2D light2DredDoorBlue;
     UnityEngine.Rendering.Universal.Light2D light2DgreenDoorBlue;
     UnityEngine.Rendering.Universal.Light2D light2DredDoorGreen;
     UnityEngine.Rendering.Universal.Light2D light2DgreenDoorGreen;
   
    
    
    // Start is called before the first frame update
    void Start()
    {
       
        textmeshPro = GameObject.Find("noKey").GetComponent<TextMeshProUGUI>();
        player = FindObjectOfType<Player>();
        doorAction = FindObjectOfType<DoorAction>();
        lightDoor = GameObject.Find("LightDoor").GetComponent<lightDoor>();
      
      //todo : refaire
      lightDoorGreen = GameObject.Find("LightDoorGreen").GetComponent<lightDoor>();
        lightDoorBlue = GameObject.Find("LightDoorBlue").GetComponent<lightDoor>();
    

        spriteRenderer = GetComponent<SpriteRenderer>();

        
        light2DredDoorRed = GameObject.Find("redLightRed").GetComponent<UnityEngine.Rendering.Universal.Light2D>();

        light2DgreenDoorRed = GameObject.Find("greenLightRed").GetComponent<UnityEngine.Rendering.Universal.Light2D>();

        light2DredDoorBlue = GameObject.Find("redLightBlue").GetComponent<UnityEngine.Rendering.Universal.Light2D>();

        light2DgreenDoorBlue = GameObject.Find("greenLightBlue").GetComponent<UnityEngine.Rendering.Universal.Light2D>();

        light2DredDoorGreen = GameObject.Find("redLightGreen").GetComponent<UnityEngine.Rendering.Universal.Light2D>();

        light2DgreenDoorGreen = GameObject.Find("greenLightGreen").GetComponent<UnityEngine.Rendering.Universal.Light2D>();

        light2DgreenDoorRed.enabled = false;

        light2DgreenDoorGreen.enabled = false;

        light2DgreenDoorBlue.enabled = false;
       

         
    }

    // Update is called once per frame
    void Update()
    {
        hasScanKey = player.hasScanKey;
        hasRedKey = player.hasRedKey;  
        hasScanBlueKey = player.hasScanBlueKey;
        hasBlueKey = player.hasBlueKey;
        hasScanGreenKey = player.hasScanGreenKey;
        hasGreenKey = player.hasGreenKey;

        setLight();
        
       
    }

    void OnTriggerEnter2D(Collider2D other)
    {
           
       
            if (other.gameObject.tag == "player")
            {
                if(hasRedKey){
                    if(!hasScanKey){
                        textmeshPro.text ="Interact with \"E\" to scan";
                        textmeshPro.enabled = true;
                       
                    }

            }

        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        //todo : 
         if(hasRedKey){
            if (other.gameObject.tag == "player" )
            {
                textmeshPro.enabled = false;
            }
         }
    }

    void setLight(){

      

         if(hasScanKey){
            if( gameObject.tag== "terminal"){
                
                spriteRenderer.sprite = spriteCheck;
                light2DgreenDoorRed.enabled = true;
                light2DredDoorRed.enabled = false;
                if(!cardSwipeSound.isPlaying){
                     if (!hasPlayedRed)
                    {
                        cardSwipeSound.Play();
                        hasPlayedRed = true;
                    }
                }


            }
             lightDoor.spriteRenderer.sprite = lightDoor.newSprite;
        }
        if(hasScanBlueKey){
                
                
                if( gameObject.tag== "terminalBlue"){
                  
                    spriteRenderer.sprite = spriteCheck;
                     light2DgreenDoorBlue.enabled = true;
                light2DredDoorBlue.enabled = false;
                     if(!cardSwipeSound.isPlaying){
                     if (!hasPlayedBlue)
                    {
                        cardSwipeSound.Play();
                        hasPlayedBlue = true;
                    }
                }
            }

                lightDoorBlue.spriteRenderer.sprite = lightDoorBlue.newSprite;
        }
        if(hasScanGreenKey){
                
              
                if( gameObject.tag== "terminalGreen"){
                   
                    spriteRenderer.sprite = spriteCheck;
                     light2DgreenDoorGreen.enabled = true;
                light2DredDoorGreen.enabled = false;
                if(!cardSwipeSound.isPlaying){
                     if (!hasPlayedGreen)
                    {
                        cardSwipeSound.Play();
                        hasPlayedGreen = true;
                    }
                }
                }
                lightDoorGreen.spriteRenderer.sprite = lightDoorGreen.newSprite;
        }
         
    }

    
}

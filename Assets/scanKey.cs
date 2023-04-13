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
    lightDoor lightDoor;
    lightDoor lightDoorGreen;
    lightDoor lightDoorBlue;
    SpriteRenderer spriteRenderer;
    public UnityEngine.Rendering.Universal.Light2D light2DredDoorRed;
    public UnityEngine.Rendering.Universal.Light2D light2DgreenDoorRed;
   
    
    
    // Start is called before the first frame update
    void Start()
    {
       
        textmeshPro = GameObject.Find("noKey").GetComponent<TextMeshProUGUI>();
        player = FindObjectOfType<Player>();
        doorAction = FindObjectOfType<DoorAction>();
        lightDoor = GameObject.Find("LightDoor").GetComponent<lightDoor>();
      
      //todo : refaire
       // lightDoorGreen = GameObject.Find("LightDoorGreen").GetComponent<lightDoor>();
        //lightDoorBlue = GameObject.Find("LightDoorBlue").GetComponent<lightDoor>();

        spriteRenderer = GetComponent<SpriteRenderer>();

        
        light2DredDoorRed = GameObject.Find("redLightRed").GetComponent<UnityEngine.Rendering.Universal.Light2D>();

        light2DgreenDoorRed = GameObject.Find("greenLightRed").GetComponent<UnityEngine.Rendering.Universal.Light2D>();


        light2DgreenDoorRed.enabled = false;
       

         
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
                cardSwipeSound.Play();


            }
             lightDoor.spriteRenderer.sprite = lightDoor.newSprite;
        }
        if(hasScanBlueKey){
                
                
                if( gameObject.tag== "terminalBlue"){
                    
                    spriteRenderer.sprite = spriteCheck;
                     cardSwipeSound.Play();
            }

                lightDoorBlue.spriteRenderer.sprite = lightDoorBlue.newSprite;
        }
        if(hasScanGreenKey){
                
              
                if( gameObject.tag== "terminalGreen"){
                    spriteRenderer.sprite = spriteCheck;
                     cardSwipeSound.Play();
                }
                lightDoorGreen.spriteRenderer.sprite = lightDoorGreen.newSprite;
        }
         
    }

    
}

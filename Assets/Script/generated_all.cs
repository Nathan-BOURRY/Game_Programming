using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class generated_all : MonoBehaviour
{
        private TextMeshProUGUI textmeshPro2;
       private TextMeshProUGUI textmeshPro;
      private TextMeshProUGUI textmeshProLife;
      
       int nbBullet;
       int life;
       public Player player;
       card card;
       

    // Start is called before the first frame update
    void Start()
    {

        textmeshPro = GameObject.Find("noKey").GetComponent<TextMeshProUGUI>();

        StartCoroutine(intro2());

         // Recherche l'objet qui a le script "Player" attaché
        card = FindObjectOfType<card>();

        player = FindObjectOfType<Player>(); 
        if (player == null)
        {
            Debug.LogError("player is null!");
        }

        
        // Accède à la variable "nbBullet" à partir de l'objet "player"

        textmeshPro2 = GameObject.Find("bullet_text").GetComponent<TextMeshProUGUI>();
        textmeshProLife = GameObject.Find("bacta_text").GetComponent<TextMeshProUGUI>();
        
    }

    // Update is called once per frame
    void Update()
    {
        nbBullet = player.numberOfBullet;

        

        textmeshProLife.text = "" + player.life;
        textmeshPro2.text ="" + nbBullet + " mun";
        
    }

   public IEnumerator EnableTextMesh(GameObject cardObject)
    {

         if (cardObject.tag == "win"){
            textmeshPro.text ="You WIN !";
            textmeshPro.enabled = true;
         }else{
        
        if(cardObject.tag == "redKey") {
            player.hasRedKey = true;
            textmeshPro.text ="You found red key";
            textmeshPro.enabled = true; 
        } else if (cardObject.tag == "greenKey") {
            player.hasGreenKey = true;
       
            textmeshPro.text ="You found green key";
            textmeshPro.enabled = true;
        }else if (cardObject.tag == "blueKey") {
            player.hasBlueKey = true;
           
            textmeshPro.text ="You found blue key";
            textmeshPro.enabled = true;
        }

        yield return new WaitForSeconds(2.0f);
        textmeshPro.enabled = false;
        Destroy(cardObject);
         }
        
        
    
         
    }

     IEnumerator intro2()
    {
        textmeshPro.text = "You need to found the secret plan ! GO GO GO";
        textmeshPro.enabled = true;
        yield return new WaitForSeconds(4.0f);
        textmeshPro.enabled = false;
    }

}

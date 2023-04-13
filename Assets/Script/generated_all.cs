using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class generated_all : MonoBehaviour
{
<<<<<<< HEAD

    private TextMeshProUGUI textmeshPro;
    private TextMeshProUGUI textmeshProLife;
    int nbBullet;
    Player player;

=======
        private TextMeshProUGUI textmeshPro2;
       private TextMeshProUGUI textmeshPro;
      private TextMeshProUGUI textmeshProLife;
      
       int nbBullet;
       int life;
       Player player;
       card card;
       
>>>>>>> origin/DEV_Mélaine

    // Start is called before the first frame update
    void Start()
    {

<<<<<<< HEAD
        // Recherche l'objet qui a le script "Player" attaché
        player = FindObjectOfType<Player>();
=======
        textmeshPro = GameObject.Find("noKey").GetComponent<TextMeshProUGUI>();

         // Recherche l'objet qui a le script "Player" attaché
        card = FindObjectOfType<card>();
>>>>>>> origin/DEV_Mélaine

        player = FindObjectOfType<Player>();
        if (player == null)
        {
            Debug.LogError("player is null!");
        }


        // Accède à la variable "nbBullet" à partir de l'objet "player"

<<<<<<< HEAD
        textmeshPro = GameObject.Find("bullet_text").GetComponent<TextMeshProUGUI>();
        textmeshProLife = GameObject.Find("bacta_text").GetComponent<TextMeshProUGUI>();
=======
     
     
        textmeshPro2 = GameObject.Find("bullet_text").GetComponent<TextMeshProUGUI>();
>>>>>>> origin/DEV_Mélaine

    }

    // Update is called once per frame
    void Update()
    {
        nbBullet = player.numberOfBullet;

        textmeshPro.text = "" + nbBullet + " mun";

<<<<<<< HEAD
        textmeshProLife.text = "" + player.life;
=======
        textmeshPro2.text ="" + nbBullet + " mun";
>>>>>>> origin/DEV_Mélaine

    }

   public IEnumerator EnableTextMesh(GameObject cardObject)
    {
        
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

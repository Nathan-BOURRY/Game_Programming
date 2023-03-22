using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class generated_all : MonoBehaviour
{

       private TextMeshProUGUI textmeshPro;
      private TextMeshProUGUI textmeshProLife;
       int nbBullet;
       int life;
       Player player;
       

    // Start is called before the first frame update
    void Start()
    {

         // Recherche l'objet qui a le script "Player" attaché
        player = FindObjectOfType<Player>();

         player = FindObjectOfType<Player>();
        if (player == null)
        {
            Debug.LogError("player is null!");
        }

        
        // Accède à la variable "nbBullet" à partir de l'objet "player"

     
     
        textmeshPro = GameObject.Find("bullet_text").GetComponent<TextMeshProUGUI>();

        textmeshProLife = GameObject.Find("life_text").GetComponent<TextMeshProUGUI>();

      
       
        
    }

    // Update is called once per frame
    void Update()
    {
        nbBullet = player.numberOfBullet;

        life = player.life;

        textmeshPro.text ="" + nbBullet;

          textmeshProLife.text ="" + life;
        
    }
}

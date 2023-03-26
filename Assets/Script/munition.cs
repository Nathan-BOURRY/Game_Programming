

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class munition : MonoBehaviour
{
    public Rigidbody2D rb;
    Player player;
    int nbBullet;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Recherche l'objet qui a le script "Player" attaché
        player = FindObjectOfType<Player>();

        // Accède à la variable "nbBullet" à partir de l'objet "player"

    }

    // Update is called once per frame
    void Update()
    {

    }



}

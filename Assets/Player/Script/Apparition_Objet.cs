using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apparition_Objet : MonoBehaviour
{
   public GameObject objet;
   

    void OnTriggerEnter(Collider other){
        Instantiate(objet, transform.position, transform.rotation);
}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour
{
    public GameObject Balle;    
    public Transform Spawn;
    public KeyCode Touch;
    public float Power  = 1000;

    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(Touch))
        {
           GameObject Fire = Instantiate(Balle, Spawn.position, Quaternion.identity);
           Fire.GetComponent<Rigidbody>().AddForce(Spawn.forward * Power);

           Destroy(Fire, 5);
        }
    }
}

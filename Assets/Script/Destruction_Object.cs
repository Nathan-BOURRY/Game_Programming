using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruction_Object : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collider)
    {

        Destroy(gameObject);
    }
}

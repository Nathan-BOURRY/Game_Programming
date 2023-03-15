using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruction_Object : MonoBehaviour
{
  private void OnTriggerExit(Collider collider)
  {
   
    Destroy(gameObject);
  }
}

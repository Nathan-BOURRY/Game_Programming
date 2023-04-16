using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class intro : MonoBehaviour
{
    public float speed = 4f;
    public TextMeshProUGUI textmeshPro;
    public AudioSource shipSound;
    public AudioSource IncomingSound;
    public AudioSource goSound;
        
    // Start is called before the first frame update
    void Start()
    {
            StartCoroutine(ship());
            StartCoroutine(startTheFight());
            StartCoroutine(MoveSound());
            StartCoroutine(GoSound());
            StartCoroutine(DetroyShip());
             
            textmeshPro = GameObject.Find("noKey").GetComponent<TextMeshProUGUI>();
        
    }

   
    

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }


     IEnumerator startTheFight()
    {
        textmeshPro.text = "Hello, soldier ! You need to found the crashed ship at the border, GO GO GO";
        textmeshPro.enabled = true;
        yield return new WaitForSeconds(5.0f);
        textmeshPro.enabled = false;
    }

     IEnumerator ship()
    {
       
        yield return new WaitForSeconds(0.1f);
        shipSound.Play();

    }
    IEnumerator MoveSound()
    {
       
        yield return new WaitForSeconds(1f);
        IncomingSound.Play();
        
    }
    IEnumerator GoSound()
    {
       
        yield return new WaitForSeconds(2f);
        goSound.Play();
        
    }
 IEnumerator DetroyShip()
    {
       
        yield return new WaitForSeconds(30f);
        Destroy(gameObject);
        
    }
    
}

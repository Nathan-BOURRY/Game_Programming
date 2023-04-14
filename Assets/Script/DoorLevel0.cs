using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class DoorLevel0 : MonoBehaviour
{
    // Start is called before the first frame update
    TextMeshProUGUI textmeshPro;
    Player player;
    void Start()
    {
        player = FindObjectOfType<Player>();
        textmeshPro = GameObject.Find("noKey").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "player")
        {
            return;
        }
        if (player.hasBlueKey)
        {
            StartCoroutine(LoadScene.LoadLaunchScene("level1"));
        }
        else
        {
            StartCoroutine(dontHaveKey());
        }
    }

    IEnumerator dontHaveKey()
    {
        textmeshPro.text = "You need the blue Key !";
        textmeshPro.enabled = true;
        yield return new WaitForSeconds(2.0f);
        textmeshPro.enabled = false;
    }
}

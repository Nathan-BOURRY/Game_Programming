using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class droid : MonoBehaviour
{
NavMeshAgent agent;
private Vector3 targetPosition;
SpriteRenderer spr = null;
GameObject instanBullet;
bool alreadyDetected = false;
public AudioSource rogerSound;
public GameObject Player;
public GameObject Bullet;
float rotation;
bool readyShoot;
public AudioSource fireSound;
public AudioSource destroySound;
private Vector2 bulletDirection;
Animator animator;
bool isDead = false;
public Vector2 movement = Vector2.zero;
private Vector3 previousPosition;


void Awake()
{
    agent = GetComponent<NavMeshAgent>();
    agent.updateRotation = false;
    agent.updateUpAxis = false;
}


// Start is called before the first frame update
void Start()
{
    targetPosition = transform.position;
    readyShoot = true;
    animator = GetComponent<Animator>();
    spr = GetComponent<SpriteRenderer>();
    previousPosition = transform.position;
}

// Update is called once per frame
void Update()
{

       if (transform.position.x > previousPosition.x)
{
//Debug.Log("L'agent se déplace vers la droite");
transform.rotation = Quaternion.Euler(0, 180, 0);
}
else if (transform.position.x < previousPosition.x)
{
//Debug.Log("L'agent se déplace vers la gauche");
transform.rotation = Quaternion.Euler(0, 0, 0);
}

    if (agent.velocity.magnitude > 0)
    {
        animator.SetBool("droidIsWalking", true);
    } else {
        animator.SetBool("droidIsWalking", false);
    }

    
    if(!isDead){
        if (noWalkZone.walk)
        {
                    
             
            
            agent.SetDestination(new Vector3(targetPosition.x, targetPosition.y, transform.position.z));
            
        }
        else
        {
            
            agent.SetDestination(new Vector3(transform.position.x, transform.position.y, transform.position.z));

        }
    }else {
        agent.speed = 0;
    }
}

void OnTriggerStay2D(Collider2D detection)
{
    if (detection.gameObject.tag == "player" && !isDead)

    {
        if(!alreadyDetected){
            rogerSound.Play();
            alreadyDetected = true;
        }
        targetPosition = detection.transform.position;
        if (readyShoot)
        {
            fireSound.Play();
            //rotation = Mathf.Rad2Deg * Mathf.Atan2(-playerMovement.x, playerMovement.y) + 180;
            bulletDirection = new Vector2((Player.transform.position.x - transform.position.x), (Player.transform.position.y - transform.position.y));
            bulletDirection.Normalize();
            rotation = Mathf.Rad2Deg * Mathf.Atan2(-bulletDirection.x, bulletDirection.y) + 90;
            //TODO : Fix Spawn bullet with animation
            if (rotation >= 45 && rotation <= 135) // En haut
            {
                instanBullet = Instantiate(Bullet, new Vector2(transform.position.x, transform.position.y + 1.5f), Quaternion.Euler(0, 0, rotation));
            }
            else if (rotation > 135 && rotation <= 225) //A gauche
            {
                instanBullet = Instantiate(Bullet, new Vector2(transform.position.x - 1.5f, transform.position.y), Quaternion.Euler(0, 0, rotation));
            }
            else if (rotation > 225 && rotation < 315)
            {
                instanBullet = Instantiate(Bullet, new Vector2(transform.position.x, transform.position.y - 1.5f), Quaternion.Euler(0, 0, rotation));
            }
            else //Droite
            {
                instanBullet = Instantiate(Bullet, new Vector2(transform.position.x + 1.5f, transform.position.y), Quaternion.Euler(0, 0, rotation));
            }

            instanBullet.GetComponent<Bullet>().speed = 8;
            instanBullet.GetComponent<Bullet>().mouvement = bulletDirection;
            StartCoroutine(CouldownWeapon(1.5f));
        }
    }
}

void OnCollisionEnter2D(Collision2D collision)
{
    if (collision.gameObject.tag == "balle")
    {
        isDead = true;
        animator.SetBool("isDestroy", true);
        //sound + animation
        if(!destroySound.isPlaying){
        destroySound.Play();
        }
        Destroy(gameObject, 1.4f);
    }
}
IEnumerator CouldownWeapon(float temps)
{

    //Execution du code
    readyShoot = false;
    yield return new WaitForSeconds(temps);
    //Code à effectué après le temps d'att
    readyShoot = true;

}
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class droid : MonoBehaviour
{
    NavMeshAgent agent;
    private Vector3 targetPosition;
    GameObject instanBullet;

    public GameObject Player;
    public GameObject Bullet;
    float rotation;
    bool readyShoot;
    public AudioSource fireSound;
    private Vector2 bulletDirection;

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
    }

    // Update is called once per frame
    void Update()
    {
        if (noWalkZone.walk)
        {
            agent.SetDestination(new Vector3(targetPosition.x, targetPosition.y, transform.position.z));
        }
        else
        {
            agent.SetDestination(new Vector3(transform.position.x, transform.position.y, transform.position.z));

        }
    }

    void OnTriggerStay2D(Collider2D detection)
    {
        if (detection.gameObject.tag == "player")
        {
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
                StartCoroutine(CouldownWeapon(2));
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "balle")
        {
            Destroy(gameObject);
        }
    }
    IEnumerator CouldownWeapon(int temps)
    {

        //Execution du code
        readyShoot = false;
        yield return new WaitForSeconds(temps);
        //Code à effectué après le temps d'att
        readyShoot = true;

    }
}


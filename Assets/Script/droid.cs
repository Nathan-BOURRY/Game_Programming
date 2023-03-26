using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class droid : MonoBehaviour
{
    NavMeshAgent agent;
    private Vector3 targetPosition;

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
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(new Vector3(targetPosition.x, targetPosition.y, transform.position.z));
    }

    void OnTriggerStay2D(Collider2D detection)
    {
        if (detection.gameObject.tag == "player")
        {
            targetPosition = detection.transform.position;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "balle")
        {
            Destroy(gameObject);
        }
    }
}

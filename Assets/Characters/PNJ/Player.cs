using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
     UnityEngine.AI.NavMeshAgent agent;
    private Vector3 targetPosition;

    void Awake()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        SetTargetPosition();
        agent.SetDestination(new Vector3(targetPosition.x, targetPosition.y, transform.position.z));

    }

    void SetTargetPosition()
    {
        if (Input.GetMouseButtonDown(0))
        {
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }
}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    // Start is called before the first frame update
    NavMeshAgent agent;

    [SerializeField]
    private Transform playerTransform;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveTowardsPlayer();
    }
    public void MoveTowardsPlayer()
    {
        if (agent != null)
        {
            agent.SetDestination(playerTransform.position);
        }
    }

}

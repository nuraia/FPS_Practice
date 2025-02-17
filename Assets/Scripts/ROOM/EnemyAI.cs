using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask WhatIsGround, WhatIsPlayer;

    [Header("Patrolling")]
    [SerializeField] Vector3 walkPoint;
    private bool walkPointSet;
    public float walkPointRange;

    [Header("Attacking")]
    public float timeBetweenAttck;
    private bool IsAlreadyAttacked;
    public GameObject projectile;

    [Header("States")]
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttckRange;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        if (player == null)
        {
            Debug.LogError("Player reference is not set in EnemyAI.");
        }
    }

    void Update()
    {
        // Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, WhatIsPlayer);
        playerInAttckRange = Physics.CheckSphere(transform.position, attackRange, WhatIsPlayer);

        if (!playerInSightRange && !playerInAttckRange)
        {
            //Debug.Log("Patrolling");
            Patroling();
        }
        if (playerInSightRange && !playerInAttckRange)
        {
            //Debug.Log("Chasing Player");
            ChasingPlayer();
        }
        if (playerInSightRange && playerInAttckRange)
        {
            //Debug.Log("Attacking Player");
            AttackingPlayer();
        }
    }

    void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
        {
            agent.SetDestination(walkPoint);
        }

        Vector3 distanceToWalkPoint = transform.position - walkPoint;
        if (distanceToWalkPoint.magnitude < 1f)
        {
            walkPointSet = false;
        }
    }

    void SearchWalkPoint()
    {
        float randomX = Random.Range(-walkPointRange, walkPointRange);
        float randomZ = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
        if (Physics.Raycast(walkPoint, -transform.up, 2f, WhatIsGround))
        {
            walkPointSet = true;
        }
        else
        {
            Debug.Log("Walk Point Not Set: No Ground Found");
        }
    }

    void ChasingPlayer()
    {
        agent.SetDestination(player.position);
        //Debug.Log("Chasing Player: " + player.position);
    }

    void AttackingPlayer()
    {
        agent.SetDestination(transform.position);
        transform.LookAt(player);

        if (!IsAlreadyAttacked)
        {
            var enemyInstantiatedBullet = Instantiate(projectile, transform.position, Quaternion.identity);
            Rigidbody rd = enemyInstantiatedBullet.GetComponent<Rigidbody>();
            rd.AddForce(transform.forward * 32f, ForceMode.Impulse);
            IsAlreadyAttacked = true;
            Destroy(enemyInstantiatedBullet, 2f);
            Invoke(nameof(ResetAttck), timeBetweenAttck);
        }
    }

    private void ResetAttck()
    {
        IsAlreadyAttacked = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
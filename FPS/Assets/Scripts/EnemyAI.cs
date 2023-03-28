using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    //Player
    [SerializeField] Transform target;

    //How close player can ghet before the enemy notices
    [SerializeField] float chaseRange = 5.0f;

    //Entire scene dimensions
    float distanceToTarget = Mathf.Infinity;

    bool isProvoked = false;

    NavMeshAgent nma;

    // Start is called before the first frame update
    void Start()
    {

        nma = GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {

        //measure the distance between player and enemy
        distanceToTarget = Vector3.Distance(target.position, transform.position);

        if (isProvoked)
        {

            EngageTarget();

        }
        else if(distanceToTarget <= chaseRange)
        {

            isProvoked = true;

            //nma.SetDestination(target.position);

        }

    }

    //display chaseRange radius when selected
    private void OnDrawGizmosSelected()
    {
        
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(transform.position, chaseRange);

    }

    private void EngageTarget()
    {

        if (distanceToTarget >= nma.stoppingDistance)
        {

            nma.SetDestination(target.position);

        }

        if (distanceToTarget <= nma.stoppingDistance)
        {

            Attack();

        }

    }

    private void Attack()
    {

        print(name + "is attacking " + target.name);

    }

}

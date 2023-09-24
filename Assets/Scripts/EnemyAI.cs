using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    private GameObject player;
    private NavMeshAgent navMeshAgent;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectsWithTag("Player")[0];
        //Debug.Log("=enemies??" + player);
        navMeshAgent.speed = Random.Range(.5f, 2f);
    }

    void Update()
    {
        Vector3 enemyPos = player.transform.position;
        bool isEnemyClose = Vector3.Distance(enemyPos, transform.position) < 10;
        if (isEnemyClose)
        {
            //Debug.Log("enemy close");
            Vector3 lookPos = enemyPos - transform.position;
            lookPos.y = 0;
            Quaternion newRotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, 0.2f);
        }
        else
        {
            //Debug.Log("enemy not close");
            navMeshAgent.SetDestination(player.transform.position);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab;

    [SerializeField]
    private GameObject bulletPos;

    private GameObject player;
    private NavMeshAgent navMeshAgent;
    private float bulletRange;

    private bool shouldFire = false;
    private bool isPlayerClose = false;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectsWithTag("Player")[0];
        //Debug.Log("=enemies??" + player);
        navMeshAgent.speed = Random.Range(.5f, 2f);
        bulletRange = WeaponInventory.GetInstance().GetEnemyWeaponAttributes().range;
    }

    void Update()
    {
        Vector3 enemyPos = player.transform.position;
        bool isClose = Vector3.Distance(enemyPos, transform.position) <= bulletRange;

        //Debug.Log("enemy pos?" + bulletRange + "=dis=" +Vector3.Distance(enemyPos, transform.position));
        if (isClose && !this.isPlayerClose)
        {
            shouldFire = true;
        }
        this.isPlayerClose = isClose;
        if (isClose)
        {
            //Debug.Log("enemy close");
            Vector3 lookPos = enemyPos - transform.position;
            lookPos.y = 0;
            Quaternion newRotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, 0.2f);
            Fire();
        }
        else
        {
            //Debug.Log("enemy not close");
            navMeshAgent.SetDestination(player.transform.position);
        }
    }

    void Fire()
    {
        if (shouldFire)
        {
            Debug.Log("firing from enemy");
            Transform bulletPosition = bulletPos.transform;
            Instantiate(bulletPrefab, bulletPosition.position, bulletPosition.rotation);
            shouldFire = false;
        }
    }
}

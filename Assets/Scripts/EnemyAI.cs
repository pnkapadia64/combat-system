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

    private GameObject playerToShoot;
    private NavMeshAgent navMeshAgent;
    private float bulletRange;

    private bool shouldFire = false;
    private bool isPlayerClose = false;

    private IEnumerator fireCoroutine;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.speed = Random.Range(.5f, 2f);
        bulletRange = WeaponInventory.GetInstance().GetEnemyWeaponAttributes().range;
        playerToShoot = GetRandomEnemy();
        Debug.Log("= enemey AI=" + gameObject.name + "=shooting=" + playerToShoot.name);

        fireCoroutine = FireAnother();
        StartCoroutine(FollowEnemy());
    }

    private GameObject GetRandomEnemy()
    {
        return PlayerManager.Instance.GetRandomEnemyFor(gameObject);
    }

    void Update()
    {
        if (!playerToShoot || !gameObject.GetComponent<Health>().isAlive())
        {
            StopAllCoroutines();
            return;
        }

        Vector3 enemyPos = playerToShoot.transform.position;
        bool isClose = Vector3.Distance(enemyPos, transform.position) <= bulletRange;

        if (!isClose)
        {
            StopCoroutine(fireCoroutine);
        }
        // Fire if close enough to enemy
        if (isClose && !this.isPlayerClose)
        {
            StartCoroutine(fireCoroutine);
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
        
    }

    private bool isEnemyAlive(GameObject pl)
    {
        return pl.GetComponent<Health>().isAlive();
    }

    IEnumerator FollowEnemy()
    {
        while (true)
        {
            bool isPlayerAlive = isEnemyAlive(playerToShoot);
            //Debug.Log(gameObject.name + " following enemy " + playerToShoot.name + isPlayerAlive + "-" + this.isPlayerClose);
            if (!isPlayerAlive)
            {
                // Find a new enemy
                playerToShoot = GetRandomEnemy();
                //Debug.Log("=finding new enemy for=" + gameObject.name + "-got-" + playerToShoot.name);
            }
            else if (!this.isPlayerClose)
            {
                navMeshAgent.SetDestination(playerToShoot.transform.position);
            }

            yield return new WaitForSeconds(0.5f);
        }
    }

    void Fire()
    {
        if (shouldFire)
        {
            //Debug.Log("firing from enemy " + gameObject.name);
            Transform bulletPosition = bulletPos.transform;
            Instantiate(bulletPrefab, bulletPosition.position, bulletPosition.rotation);
            shouldFire = false;
        }
    }

    IEnumerator FireAnother()
    {
        while (true)
        {
            shouldFire = true;
            yield return new WaitForSeconds(2f);
        }
    }
}

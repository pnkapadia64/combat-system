using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    public GameObject enemyPrefab;
    [SerializeField]
    public Transform[] enemyPos;

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        for (int i = 0; i < enemyPos.Length; i++)
        {
            Transform pos = enemyPos[i];
            Instantiate(enemyPrefab, pos.position, Quaternion.identity);
            yield return new WaitForSeconds(3 + 1);
        }
    }
}

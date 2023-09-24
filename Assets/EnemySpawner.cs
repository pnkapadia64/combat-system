using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Singleton<EnemySpawner>
{
    [SerializeField]
    public GameObject enemyPrefab;
    [SerializeField]
    public Transform[] enemyPos;

    public List<GameObject> SpawnEnemies()
    {
        List<GameObject> allEnemies = new List<GameObject>();

        for (int i = 0; i < enemyPos.Length; i++)
        {
            Transform pos = enemyPos[i];
            var enemy = Instantiate(enemyPrefab, pos.position, Quaternion.identity);
            enemy.name = "Enemy" + i;
            allEnemies.Add(enemy);
        }
        return allEnemies;
    }
}

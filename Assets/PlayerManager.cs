using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerManager : Singleton<PlayerManager>
{
    [SerializeField]
    public TextMeshProUGUI aliveUI;

    private List<GameObject> allPlayers;
    private List<GameObject> alivePlayers;

    void Start()
    {
        allPlayers = EnemySpawner.Instance.SpawnEnemies();
        GameObject currPlayer = GameObject.Find("Soldier");
        allPlayers.Add(currPlayer);
        alivePlayers = new List<GameObject>(allPlayers);
        UpdateUI();
    }

    public void OnPlayerDeath(GameObject player)
    {
        Debug.Log("On player death =" + player.name);
        alivePlayers.Remove(player);
        UpdateUI();
    }

    // Get random target enemy
    public GameObject GetRandomEnemyFor(GameObject player)
    {
        List<GameObject> aliveEnemiesForPlayer = new List<GameObject>(alivePlayers);
        aliveEnemiesForPlayer.Remove(player);
        if (aliveEnemiesForPlayer.Count == 0)
        {
            return null;
        }
        int randomIndex = Random.Range(0, aliveEnemiesForPlayer.Count);

        return randomIndex > -1 ? aliveEnemiesForPlayer[randomIndex] : null;
    }

    private void UpdateUI()
    {
        string text = "";

        foreach (GameObject pl in alivePlayers) {
            text += pl.name + "\n";
        }
        aliveUI.text = text;
    }
}

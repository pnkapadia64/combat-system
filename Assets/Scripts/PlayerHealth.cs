using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private TextMeshPro healthUI;

    private int health;

    void Start()
    {
        health = Random.Range(1, 4);
        healthUI.text = health.ToString();
    }

    public bool isAlive()
    {
        return health > 0;
    }

    public void getHit()
    {
        health -= 1;
        healthUI.text = health.ToString();
    }

    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log("has collision " + collision.gameObject.tag);
        if (collision.gameObject.tag == "Bullet")
        {
            getHit();
        }
    }
}

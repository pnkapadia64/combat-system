using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Health : MonoBehaviour
{
    [SerializeField]
    private TextMeshPro healthUI;

    protected int health;

    void Start()
    {
        health = 50;
        healthUI.text = getHealthText();
    }

    public bool isAlive()
    {
        return health > 0;
    }

    public void getHit(int damage)
    {
        if (health > 0)
        {
            health -= damage;
            healthUI.text = getHealthText();
        }
        if (health <= 0)
        {
            PlayerManager.Instance.OnPlayerDeath(gameObject);
        }
    }

    protected virtual string getHealthText()
    {
        return health.ToString();
    }

    protected virtual int getBulletDamage(Collision collision)
    {
        int damageFromBullet = collision.gameObject.GetComponent<BulletMovement>().damage;
        //Debug.Log("has collision " + gameObject.name + damageFromBullet);
        return damageFromBullet;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet" & isAlive())
        {
            int damageFromBullet = getBulletDamage(collision);
            getHit(damageFromBullet);
        }
    }
}

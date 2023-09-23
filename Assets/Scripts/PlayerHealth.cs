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
        health = Random.Range(50, 100);
        healthUI.text = health.ToString();
    }

    public bool isAlive()
    {
        return health > 0;
    }

    public void getHit(int damage)
    {
        health -= damage;
        healthUI.text = health.ToString();
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            WeaponType bulletWeaponType = collision.gameObject.GetComponent<BulletMovement>().weaponType;
            Debug.Log("has collision " + collision.gameObject.tag + bulletWeaponType);
            int damageFromBullet = WeaponInventory.GetInstance().GetWeaponAttributes(bulletWeaponType).damage;
            getHit(damageFromBullet);
        }
    }
}

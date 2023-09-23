using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float speed = 10f;

    private bool keepMoving = true;

    private void Start()
    {
        WeaponType currentWeapon = GameManager.Instance.weaponChosen;
        WeaponAttributes currentWeaponAttr = WeaponInventory.GetInstance().GetWeaponAttributes(currentWeapon);
        if (currentWeaponAttr != null)
        {
            speed = currentWeaponAttr.speed;
        }
    }

    void FixedUpdate()
    {
        if (keepMoving)
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        keepMoving = false;
    }
}

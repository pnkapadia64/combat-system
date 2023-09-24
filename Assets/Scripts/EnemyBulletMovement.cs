using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletMovement : BulletMovement
{
    private void Start()
    {
        WeaponAttributes currentWeaponAttr = WeaponInventory.GetInstance().GetEnemyWeaponAttributes();
        speed = currentWeaponAttr.speed;
        range = currentWeaponAttr.range;
        damage = currentWeaponAttr.damage;
        originPos = transform.position;
    }
}

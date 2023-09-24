using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public WeaponType weaponType;

    public float speed = 10f;
    protected float range = 5f;
    public int damage = 1;

    private bool keepMoving = true;
    protected Vector3 originPos;

    private void Start()
    {
        weaponType = GameManager.Instance.weaponChosen;
        WeaponAttributes currentWeaponAttr = WeaponInventory.GetInstance().GetWeaponAttributes(weaponType);
        if (currentWeaponAttr != null)
        {
            speed = currentWeaponAttr.speed;
            range = currentWeaponAttr.range;
            damage = currentWeaponAttr.damage;
        }
        originPos = transform.position;
    }

    void FixedUpdate()
    {
        if (Vector3.Distance(originPos, transform.position) > range)
        {
            //Debug.Log("Out of range bullet");
            Destroy(gameObject);
        }
        if (keepMoving)
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        keepMoving = false;
        Destroy(gameObject);
    }
}

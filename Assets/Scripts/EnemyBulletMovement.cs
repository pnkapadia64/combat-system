using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletMovement : MonoBehaviour
{
    public float speed = 10f;
    private float range = 5f;

    private bool keepMoving = true;
    private Vector3 originPos;

    private void Start()
    {
        WeaponAttributes currentWeaponAttr = WeaponInventory.GetInstance().GetEnemyWeaponAttributes();
        speed = currentWeaponAttr.speed;
        range = currentWeaponAttr.range;
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
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SoldierFire : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab;

    [SerializeField]
    private GameObject bulletPos;

    public void OnFire(InputValue _value)
    {
        if (gameObject.GetComponent<Health>().isAlive())
        {
            Transform bulletPosition = bulletPos.transform;
            Instantiate(bulletPrefab, bulletPosition.position, bulletPosition.rotation);
        }
    }
}

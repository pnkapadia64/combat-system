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

    private void Start()
    {
    }

    //private void OnEnable()
    //{
    //    input.Enable();
    //    input.Player.Fire.performed += OnFire;
    //}

    //private void OnDisable()
    //{
    //    input.Disable();
    //    input.Player.Fire.performed -= OnFire;
    //}

    public void OnFire(InputValue _value)
    {
        Transform bulletPosition = bulletPos.transform;
        Instantiate(bulletPrefab, bulletPosition.position, bulletPosition.rotation);
    }
}

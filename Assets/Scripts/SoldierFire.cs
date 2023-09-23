using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SoldierFire : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab;

    private Transform bulletPosition;

    private CustomInput input;

    private void Start()
    {
        bulletPosition = transform;
    }

    void Awake()
    {
        input = new CustomInput();
    }

    private void OnEnable()
    {
        input.Enable();
        input.Player.Fire.performed += OnFire;
    }

    private void OnDisable()
    {
        input.Disable();
        input.Player.Fire.performed -= OnFire;
    }

    private void OnFire(InputAction.CallbackContext val)
    {
        Instantiate(bulletPrefab, bulletPosition.position, bulletPosition.rotation);
    }
}

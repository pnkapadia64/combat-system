using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SoldierMovement : MonoBehaviour
{
    private CustomInput input;
    private Vector3 moveVec = Vector3.zero;
    private float speed = 5.0f;

    void Awake()
    {
        input = new CustomInput();
    }

    private void Start()
    {
        Debug.Log("player start==" + GameManager.Instance.GetBulletStr());
    }

    private void FixedUpdate()
    {
        transform.Translate(moveVec * speed * Time.deltaTime);
    }

    private void OnEnable()
    {
        input.Enable();
        input.Player.Move.performed += OnMoved;
        input.Player.Move.canceled += OnCancelled;
    }

    private void OnDisable()
    {
        input.Disable();
        input.Player.Move.performed -= OnMoved;
        input.Player.Move.canceled -= OnCancelled;
    }

    private void OnMoved(InputAction.CallbackContext value)
    {
        Vector2 inputVal = value.ReadValue<Vector2>();
        moveVec = new Vector3(inputVal.x, 0f, inputVal.y);
        //Debug.Log(inputVal +"+++++" + moveVec);
    }

    private void OnCancelled(InputAction.CallbackContext value)
    {
        moveVec = Vector3.zero;
    }

}

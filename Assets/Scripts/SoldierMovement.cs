using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SoldierMovement : MonoBehaviour
{
    private Vector3 moveVec = Vector3.zero;
    private float speed = 5.0f;

    private const float _threshold = 0.01f;
    private float RotationSpeed = 1.0f;
    private float _cinemachineTargetPitch;
    private float _rotationVelocity;
    [Tooltip("How far in degrees can you move the camera up")]
    private float TopClamp = 5.0f;
    [Tooltip("How far in degrees can you move the camera down")]
    private float BottomClamp = -5.0f;

    public GameObject CinemachineCameraTarget;

    private void FixedUpdate()
    {
        transform.Translate(moveVec * speed * Time.deltaTime);
    }

    public void OnLook(InputValue value)
    {
        CameraRotation(value.Get<Vector2>());
    }

    public void OnMove(InputValue value)
    {
        Vector2 inputVal = value.Get<Vector2>();
        moveVec = new Vector3(inputVal.x*0.5f, 0f, inputVal.y*0.5f);
    }

    // From StarterAssets
    private void CameraRotation(Vector2 look)
    {
        float RotationSpeed = 0.5f;

        if (look.sqrMagnitude >= 0.1)
        {
            _cinemachineTargetPitch += look.y * RotationSpeed;
            _rotationVelocity = look.x * RotationSpeed;

            // clamp our pitch rotation
            _cinemachineTargetPitch = ClampAngle(_cinemachineTargetPitch, BottomClamp, TopClamp);

            // Update Cinemachine camera target pitch
            CinemachineCameraTarget.transform.localRotation = Quaternion.Euler(_cinemachineTargetPitch, 0.0f, 0.0f);

            // rotate the player left and right
            transform.Rotate(Vector3.up * _rotationVelocity);
        }
    }

    private static float ClampAngle(float lfAngle, float lfMin, float lfMax)
    {
        if (lfAngle < -360f) lfAngle += 360f;
        if (lfAngle > 360f) lfAngle -= 360f;
        return Mathf.Clamp(lfAngle, lfMin, lfMax);
    }
}

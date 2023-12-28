using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float currentVelocity;
    [SerializeField] private float smoothRotationTime;
    [SerializeField] private float movementSpeed;
    [SerializeField] private bool enableMobile = false;
    [SerializeField] private FixedJoystick joystick;

    private float _currentSpeed, _speedVelocity, _targetSpeed;
    [SerializeField] private Transform cameraTransform;

    private void Start()
    {
    }

    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        Vector2 input = Vector2.zero;
        if (enableMobile)
        {
            input = new Vector2(joystick.input.x, joystick.input.y);
        }
        else
        {
            input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        }
        Vector2 inputDirection = input.normalized;

        if (inputDirection != Vector2.zero)
        {
            float rotation = Mathf.Atan2(inputDirection.x, inputDirection.y) * Mathf.Rad2Deg + cameraTransform.eulerAngles.y;
            transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, rotation, ref currentVelocity, smoothRotationTime);
        }

        _targetSpeed = movementSpeed * inputDirection.magnitude;
        _currentSpeed = Mathf.SmoothDamp(_currentSpeed, _targetSpeed, ref _speedVelocity, 0.1f);
        
        transform.Translate(transform.forward * _currentSpeed * Time.deltaTime, Space.World);
    }
}

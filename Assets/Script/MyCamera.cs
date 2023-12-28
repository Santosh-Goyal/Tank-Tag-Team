using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCamera : MonoBehaviour
{
    private float _yAxis, _xAxis;
    private const float RotationSensitivity = 0.2f;
    private float _smoothTime = 0.2f;
    private Vector3 _targetRotation, _currentVelocity;
    
    [SerializeField] private float rotationMax, rotationMin;
    [SerializeField] private Transform target;
    [SerializeField] private bool enableMobile = false;
    [SerializeField] private FixedTouchField touchField;
    void Start()
    {
        
    }

    void LateUpdate()
    {
        if (enableMobile)
        {
            _xAxis -= touchField.touchDist.y * RotationSensitivity;
            _yAxis += touchField.touchDist.x * RotationSensitivity;
        }
        else
        { 
            _xAxis -= Input.GetAxis("Mouse Y") * RotationSensitivity;
            _yAxis += Input.GetAxis("Mouse X") * RotationSensitivity;
        }
        
        _xAxis = Mathf.Clamp(_xAxis, rotationMin, rotationMax);

        _targetRotation = Vector3.SmoothDamp(_targetRotation, new Vector3(_xAxis, _yAxis), ref _currentVelocity,
            _smoothTime);
        transform.eulerAngles = _targetRotation;

        transform.position = target.position - transform.forward * 5f;
    }
}

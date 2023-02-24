using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtifactRotationController : MonoBehaviour
{
    [SerializeField] private float _mouseSensitivity = 100f;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Camera _camera;

    private float _mouseX;
    private float _mouseY;
    private Vector3 _rotationDirection;
    private Vector3 _moveDirection;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            _mouseX = Input.GetAxis("Mouse X") * _mouseSensitivity * Time.deltaTime;
            _mouseY = Input.GetAxis("Mouse Y") * _mouseSensitivity * Time.deltaTime;

            _rotationDirection = -_camera.transform.up * _mouseX + _camera.transform.right * _mouseY;
            transform.Rotate(_rotationDirection, Space.World);
        }
    }
}

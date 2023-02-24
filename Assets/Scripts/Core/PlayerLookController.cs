using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLookController : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private float _mouseSensitivity = 100f;

    private float _mouseX;
    private float _mouseY;
    private float _cameraRotationX;

    void Start()
    {
        _cameraRotationX = 0;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        _mouseX = Input.GetAxis("Mouse X") * _mouseSensitivity * Time.deltaTime;
        _mouseY = Input.GetAxis("Mouse Y") * _mouseSensitivity * Time.deltaTime;

        _cameraRotationX -= _mouseY;
        _cameraRotationX = Mathf.Clamp(_cameraRotationX, -90f, 90f);
        _camera.transform.localRotation = Quaternion.Euler(_cameraRotationX, 0f, 0f);

        transform.Rotate(Vector3.up * _mouseX);
    }
}

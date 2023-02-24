using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpHeight;

    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float _groundDistance;
    [SerializeField] private LayerMask _groundMask;
    
    private const float G = 9.8f;
    private Vector3 _veloicityInAir;
    private Vector3 _moveDirection;
    private bool _IsOnGround;

    void Update()
    {
        _IsOnGround = Physics.CheckSphere(_groundCheck.position, _groundDistance, _groundMask);

        if(_IsOnGround && _veloicityInAir.y < 0)
        {
            _veloicityInAir.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        _moveDirection = transform.right * x + transform.forward * z;
        _characterController.Move(_moveDirection * _speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && _IsOnGround)
        {
            _veloicityInAir.y = Mathf.Sqrt(_jumpHeight * 2f * G);
        }

        _veloicityInAir.y -= G * Time.deltaTime;

        _characterController.Move(_veloicityInAir * Time.deltaTime);
    }
}

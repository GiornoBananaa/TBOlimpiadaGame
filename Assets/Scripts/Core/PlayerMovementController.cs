using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private float _speed;

    private Ray _ray;
    private RaycastHit _rayHit;
    private Vector3 _playerDestination;
    private bool _isWalking;

    private void Start()
    {
        _playerDestination = transform.position;
        _isWalking = false;
    }

    private void Update()
    {
        _ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(_ray, out _rayHit, 1000, _groundMask, QueryTriggerInteraction.Ignore))
            {
                _playerDestination = new Vector3(_rayHit.point.x, transform.position.y, _rayHit.point.z);
                _animator.SetBool("Walk", true);
                _isWalking = true;
            }
        }

        if (new Vector3(transform.position.x / 0.01f, transform.position.y, transform.position.z / 0.01f) != new Vector3(_playerDestination.x / 0.01f, transform.position.y, _playerDestination.z / 0.01f))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(_playerDestination - transform.position), 0.05f);
            transform.position = Vector3.MoveTowards(transform.position, _playerDestination, _speed * Time.deltaTime);
        }
        else if(_isWalking)
        {
            _animator.SetBool("Walk", false);
        }
    }

    public void StopCharacter()
    {
        _playerDestination = transform.position;
        _animator.SetBool("Walk", false);
    }
}

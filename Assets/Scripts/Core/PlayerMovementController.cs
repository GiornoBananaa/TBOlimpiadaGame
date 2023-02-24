using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private float _speed;

    private Ray _ray;
    private RaycastHit _rayHit;
    private Vector3 _playerDestination;

    private void Start()
    {
        _playerDestination = transform.position;
    }

    private void Update()
    {
        _ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(_ray, out _rayHit, 1000, _groundMask, QueryTriggerInteraction.Ignore))
            {
                _playerDestination = new Vector3(_rayHit.point.x, transform.position.y, _rayHit.point.z);
            }
        }

        transform.LookAt(_playerDestination);
        transform.position = Vector3.MoveTowards(transform.position, _playerDestination, _speed * Time.deltaTime);
    }
}

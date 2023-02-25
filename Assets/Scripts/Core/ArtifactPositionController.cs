using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtifactPositionController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _maxDistance;
    [SerializeField] private Transform _artifactDeafultPosition;

    private float _x;
    private float _y;
    private float _z;
    private Vector3 _moveDirection;
    private Transform _moveTransform;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _x = Input.GetAxis("Horizontal");
        _z = Input.GetAxis("Vertical");
        _y = 0;

        if (Input.GetKey(KeyCode.Q))
            _y = 0.3f;
        else if(Input.GetKey(KeyCode.E))
            _y = -0.3f;


        _moveDirection = Vector3.right * _x + Vector3.up * _y + Vector3.forward * _z;
        transform.Translate(_moveDirection * _moveSpeed * Time.deltaTime, _artifactDeafultPosition);


        if (Vector3.Distance(_artifactDeafultPosition.position, transform.position) > _maxDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, _artifactDeafultPosition.position, 100);
        }
    }
}

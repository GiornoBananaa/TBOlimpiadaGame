using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtifactPositionController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _maxDistance;
    [SerializeField] private Transform _artifactDeafultPosition;
    [SerializeField] private GameObject _key;
    [SerializeField] private GameObject _keyColldier;
    [SerializeField] private GameObject[] _artifactColliders;

    private float _x;
    private float _y;
    private float _z;
    private Vector3 _moveDirection;
    private Rigidbody _rigidbody;
    private int _buttonsCount;

    private void Start()
    {
        _buttonsCount = 0;
        _rigidbody = GetComponent<Rigidbody>();

        foreach(GameObject i in _artifactColliders)
        {
            Physics.IgnoreCollision(i.GetComponent<Collider>(), _key.GetComponent<Collider>());
            Physics.IgnoreCollision(i.GetComponent<Collider>(), _keyColldier.GetComponent<Collider>());
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            _rigidbody.isKinematic = false;
            _z += 1;
            _buttonsCount++;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            _rigidbody.isKinematic = false;
            _z -= 1;
            _buttonsCount++;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            _rigidbody.isKinematic = false;
            _x += 1;
            _buttonsCount++;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            _rigidbody.isKinematic = false;
            _x -= 1;
            _buttonsCount++;
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            _rigidbody.isKinematic = false;
            _y += 1;
            _buttonsCount++;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            _rigidbody.isKinematic = false;
            _y -= 1;
            _buttonsCount++;
        }



        if (Input.GetKeyUp(KeyCode.W))
        {
            _z -= 1;
            _buttonsCount--;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            _z += 1;
            _buttonsCount--;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            _x -= 1;
            _buttonsCount--;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            _x += 1;
            _buttonsCount--;
        }
        if (Input.GetKeyUp(KeyCode.Q))
        {
            _y -= 1;
            _buttonsCount--;
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            _y += 1;
            _buttonsCount--;
        }


        if (_buttonsCount == 0)
        {
            _rigidbody.isKinematic = true;

        }

        _moveDirection = Vector3.right * _x + Vector3.up * _y + Vector3.forward * _z;
        _moveDirection = Quaternion.AngleAxis(Vector3.Angle(_moveDirection, _artifactDeafultPosition.rotation.eulerAngles),Vector3.up) * _moveDirection;
        _rigidbody.velocity = _moveDirection * _moveSpeed;


        if (Vector3.Distance(_artifactDeafultPosition.position, transform.position) > _maxDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, _artifactDeafultPosition.position, 100);
        }
    }
}

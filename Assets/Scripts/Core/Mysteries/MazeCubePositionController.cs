using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeCubePositionController : MonoBehaviour
{
    [SerializeField] private float _cubeMaxSpeed;
    [SerializeField] private int _cubeLayerNumber;
    [SerializeField] private int _mazeFinishLayerNumber;
    [SerializeField] private Material _activationMaterial;
    [SerializeField] private ArtifactRotationController _artifactRotation;
    [SerializeField] private InventoryManager _inventory;

    private bool _moveCube;
    private bool _isObservation;
    private Ray _ray;
    private Vector3 _clickPosition;
    private Vector3 _direction;
    private Vector3 _localVelocity;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.isKinematic = true;
        _rigidbody.detectCollisions = false;
        _rigidbody.freezeRotation = true;
        _isObservation = false;
    }

    private void Update()
    {
        RaycastHit _rayHit;

        _ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(_ray, out _rayHit))
            {
                if (_rayHit.collider.gameObject.layer == _cubeLayerNumber)
                {
                    _clickPosition = transform.InverseTransformPoint(_rayHit.point);
                    _moveCube = true;
                    _rigidbody.isKinematic = false;
                    _artifactRotation.enabled = false;
                }
            }
        }

        if (_moveCube && Input.GetMouseButtonUp(0))
        {
            _moveCube = false;
            _rigidbody.isKinematic = true;
            _artifactRotation.enabled = true;
        }

        if (_moveCube)
        {
            if (Physics.Raycast(_ray, out _rayHit, 1000))
            {
                _localVelocity = transform.InverseTransformDirection(_rigidbody.velocity);
                _rayHit.point = transform.InverseTransformPoint(_rayHit.point);

                _localVelocity.x = 0;

                _direction = new Vector3(0, _localVelocity.y + (_rayHit.point.y - _clickPosition.y), _localVelocity.z + (_rayHit.point.z - _clickPosition.z));
                
                if (_direction.y > _cubeMaxSpeed) _direction.y = _cubeMaxSpeed;
                else if (_direction.y < -_cubeMaxSpeed) _direction.y = -_cubeMaxSpeed;

                if (_direction.z > _cubeMaxSpeed) _direction.z = _cubeMaxSpeed;
                else if (_direction.z < -_cubeMaxSpeed) _direction.z = -_cubeMaxSpeed;

                Debug.DrawRay(transform.position, transform.TransformDirection(_direction), Color.green);
                _rigidbody.velocity = transform.TransformDirection(_direction);
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            if (_isObservation)
            {
                _rigidbody.detectCollisions = false;
                _isObservation = false;
            }
            else
            {
                _rigidbody.detectCollisions = true;
                _isObservation = true;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == _mazeFinishLayerNumber)
        {
            GetComponent<MeshRenderer>().material = _activationMaterial;

            _moveCube = false;
            _rigidbody.isKinematic = true;
            _artifactRotation.enabled = true;
            GetComponent<BoxCollider>().enabled = false;

            _inventory.Add(1);

            this.enabled = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyMystery : MonoBehaviour
{
    [SerializeField] private int _keyLayerNumber;
    [SerializeField] private int _keyHoleLayerNumber;
    [SerializeField] private ArtifactRotationController _artifactRotation;
    [SerializeField] private Material _activationMaterial;
    [SerializeField] private GameObject[] _doors;
    [SerializeField] private GameObject[] _keyHoles;

    private int _doorNumder;
    private Ray _ray;
    private RaycastHit _rayHit;
    private bool _moveKey;
    private Vector3 _clickPosition;

    private void Start()
    {
        _doorNumder = 0;
    }

    private void Update()
    {
        RaycastHit _rayHit;

        _ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(_ray, out _rayHit))
            {
                if (_rayHit.collider.gameObject.layer == _keyLayerNumber)
                {
                    _clickPosition = transform.InverseTransformPoint(_rayHit.point);
                    _moveKey = true;
                    _artifactRotation.enabled = false;
                }
            }
        }
        
        if (Input.GetMouseButtonUp(0) && _moveKey)
        {
            _moveKey = false;
            _artifactRotation.enabled = true;
        }

        if (_moveKey)
        {
            if(Physics.Raycast(_ray, out _rayHit, 1000))
            {
                if (_rayHit.collider.gameObject.layer == _keyLayerNumber)
                {
                    _rayHit.point = transform.InverseTransformPoint(_rayHit.point);
                    if (_rayHit.point.z - _clickPosition.z > 0 && transform.localPosition.z < 0.02f)
                    {
                        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z + _rayHit.point.z - _clickPosition.z);
                    }
                }
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == _keyHoleLayerNumber)
        {
            _doors[_doorNumder].GetComponent<DoorManager>().OpenDoor();
            _keyHoles[_doorNumder].GetComponent<MeshRenderer>().material = _activationMaterial;
        }
    }
}

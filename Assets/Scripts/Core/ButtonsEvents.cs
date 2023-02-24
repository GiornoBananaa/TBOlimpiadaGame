using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsEvents : MonoBehaviour
{
    [SerializeField] private ArtifactRotationController _artifactRotation;
    [SerializeField] private PlayerLookController _playerLook;
    [SerializeField] private PlayerMovementController _playerMovement;
    [SerializeField] private GameObject _artifact;
    [SerializeField] private Transform _artifactPositionInHand;
    [SerializeField] private Transform _artifactPositionForObservation;
    [SerializeField] private float _artifactTransitionSpeed;

    private Transform _artifactTransitDestination;
    private Coroutine _artifactTransit;

    private void Start()
    {
        _artifactTransitDestination = _artifactPositionInHand;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (_artifactTransitDestination != null)
                StopCoroutine(ArtifactTransit());

            _artifactTransit = StartCoroutine(ArtifactTransit());

            if (_artifactRotation.enabled == false)
            {
                Cursor.lockState = CursorLockMode.None;
                _playerLook.enabled = false;
                _playerMovement.enabled = false;
                _artifactRotation.enabled = true;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                _playerLook.enabled = true;
                _playerMovement.enabled = true;
                _artifactRotation.enabled = false;
            }
        }
    }
    IEnumerator ArtifactTransit()
    {
        if (_artifactTransitDestination == _artifactPositionInHand)
            _artifactTransitDestination = _artifactPositionForObservation;
        else
            _artifactTransitDestination = _artifactPositionInHand;

        while (_artifact.transform.position != _artifactTransitDestination.position)
        {
            _artifact.transform.position = Vector3.Lerp(_artifact.transform.position, _artifactTransitDestination.position, _artifactTransitionSpeed * Time.deltaTime);
            yield return null;
        }
    }
}

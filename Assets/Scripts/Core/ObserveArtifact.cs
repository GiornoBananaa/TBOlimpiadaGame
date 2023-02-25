using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObserveArtifact : MonoBehaviour
{
    [Header("CameraTransitions")]
    [SerializeField] private Camera _camera;
    [SerializeField] private Transform _cameraPositionInCharacter;
    [SerializeField] private Transform _cameraPositionDeafult;

    [Header("ArtifactTransitions")]
    [SerializeField] private GameObject _artifact;
    [SerializeField] private Transform _artifactPositionInHand;
    [SerializeField] private Transform _artifactPositionForObservation;
    [SerializeField] private float _artifactTransitionSpeed;

    [Header("Scripts")]
    [SerializeField] private ArtifactRotationController _artifactRotation;
    [SerializeField] private CameraTransition _cameraTransition;
    [SerializeField] private PlayerMovementController _playerMovement;


    private bool _IsObservation;
    private void Start()
    {
        _IsObservation = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            StopAllCoroutines();

            if (!_IsObservation)
            {
                _IsObservation = true;
                StartCoroutine(ArtifactTransit(_artifactPositionForObservation));
                _cameraTransition.StartTransition(_cameraPositionInCharacter);
            }
            else
            {
                _IsObservation = false;
                StartCoroutine(ArtifactTransit(_artifactPositionInHand));
                _cameraTransition.StartTransition(_cameraPositionDeafult);
            }

            if (_artifactRotation.enabled == false)
            {
                _playerMovement.StopCharacter();
                _playerMovement.enabled = false;
                _artifactRotation.enabled = true;
            }
            else
            {
                _playerMovement.enabled = true;
                _artifactRotation.enabled = false;
            }
        }
    }

    private IEnumerator ArtifactTransit(Transform _artifactTransitDestination)
    {
        while (_artifact.transform.position != _artifactTransitDestination.position)
        {
            _artifact.transform.position = Vector3.Lerp(_artifact.transform.position, _artifactTransitDestination.position, _artifactTransitionSpeed * Time.deltaTime);
            yield return null;
        }
    }
}

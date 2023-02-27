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
    [SerializeField] private ArtifactTransition _artifactTransition;
    [SerializeField] private PlayerMovementController _playerMovement;
    [SerializeField] private KeyMystery _keyMystery;

    public bool IsObservation;

    private void Start()
    {
        IsObservation = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            StopAllCoroutines();

            if (!IsObservation)
            {
                IsObservation = true;
                StartCoroutine(ArtifactTransit(_artifactPositionForObservation));
            }
            else
            {
                IsObservation = false;
                StartCoroutine(ArtifactTransit(_artifactPositionInHand));
                
            }

            if (_artifactRotation.enabled == false)
            {
                _playerMovement.StopCharacter();
                _playerMovement.enabled = false;
                _artifactRotation.enabled = true;
                _keyMystery.enabled = true;
            }
            else
            {
                _playerMovement.enabled = true;
                _artifactRotation.enabled = false;
                _keyMystery.enabled = false;
            }
        }
    }

    private IEnumerator ArtifactTransit(Transform _artifactTransitDestination)
    {
        if (IsObservation)
        {
            _cameraTransition.StartTransition(_cameraPositionInCharacter);
            yield return new WaitForSeconds(0.5f);
        }
        else
            _cameraTransition.StartTransition(_cameraPositionDeafult);

        _artifactTransition.StartTransition(_artifactTransitDestination);
    }
}

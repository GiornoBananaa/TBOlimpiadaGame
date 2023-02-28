using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Mystery1 : MonoBehaviour
{
    [SerializeField] private GameObject _pressButtonHint;
    [SerializeField] private Transform _cameraMysteryPosition;
    [SerializeField] private Transform _cameraDeafultPosition;
    [SerializeField] private Transform _artifactMysteryPosition;
    [SerializeField] private Transform _artifactInHandPosition;
    [Header("Scripts")]
    [SerializeField] private CameraTransition _cameraTransition;
    [SerializeField] private ArtifactTransition _artifactTransition;
    [SerializeField] private PlayerMovementController _playerMovement;
    [SerializeField] private ArtifactPositionController _artifactMovement;
    [SerializeField] private ArtifactRotationController _artifactRotation;
    [SerializeField] private ObserveArtifact _observeArtifact;
    [SerializeField] private KeyMystery _keyMystery;

    private bool _IsMysteryObservation;

    private void Start()
    {
        _IsMysteryObservation = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && !_observeArtifact.IsObservation)
        {
            if (!_IsMysteryObservation)
            {
                _IsMysteryObservation = true;

                _cameraTransition.StartTransition(_cameraMysteryPosition);
                _artifactTransition.StartTransition(_artifactMysteryPosition);

                _observeArtifact.enabled = false;
                _artifactMovement.enabled = true;
                _artifactRotation.enabled = true;
                _playerMovement.enabled = false;
                _keyMystery.enabled = true;
                _playerMovement.StopCharacter();

                _pressButtonHint.SetActive(false);
            }
            else
            {
                _IsMysteryObservation = false;

                _cameraTransition.StartTransition(_cameraDeafultPosition);
                _artifactTransition.StartTransition(_artifactInHandPosition);

                _observeArtifact.enabled = true;
                _artifactMovement.enabled = false;
                _artifactRotation.enabled = false;
                _playerMovement.enabled = true;
                _keyMystery.enabled = false;

                _pressButtonHint.SetActive(true);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Mystery1 : MonoBehaviour
{
    [SerializeField] private GameObject _pressButtonHint;
    [SerializeField] private Transform _cameraDeafultPosition;
    [SerializeField] private Transform _cameraPosition;
    [SerializeField] private CameraTransition _cameraTransition;
    [SerializeField] private PlayerMovementController _playerMovement;

    private bool _IsMysteryObservation;

    private void Start()
    {
        _IsMysteryObservation = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (_IsMysteryObservation)
            {
                _IsMysteryObservation = false;
                _cameraTransition.StartTransition(_cameraPosition);
                _playerMovement.enabled = false;
                _playerMovement.StopCharacter();
                _pressButtonHint.SetActive(false);
            }
            else
            {
                _IsMysteryObservation = true;
                _cameraTransition.StartTransition(_cameraDeafultPosition);
                _playerMovement.enabled = true;
                _playerMovement.StopCharacter();
                _pressButtonHint.SetActive(true);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTransition : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private float _cameraTransitionSpeed;

    private IEnumerator CameraTransit(Transform _cameraTransitDestination)
    {
        while (_camera.transform.position != _cameraTransitDestination.position || _camera.transform.rotation != _cameraTransitDestination.rotation)
        {
            _camera.transform.rotation = Quaternion.Slerp(_camera.transform.rotation, _cameraTransitDestination.rotation, _cameraTransitionSpeed * Time.deltaTime);
            _camera.transform.position = Vector3.Lerp(_camera.transform.position, _cameraTransitDestination.position, _cameraTransitionSpeed * Time.deltaTime);
            yield return null;
        }
    }

    public void StartTransition(Transform _cameraTransitDestination)
    {
        StopAllCoroutines();
        StartCoroutine(CameraTransit(_cameraTransitDestination));
    }
}

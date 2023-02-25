using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtifactTransition : MonoBehaviour
{
    [SerializeField] private GameObject _artifact;
    [SerializeField] private float _artifactTransitionSpeed;

    private IEnumerator ArtifactTransit(Transform _artifactTransitDestination)
    {
        while (_artifact.transform.position != _artifactTransitDestination.position && Input.GetAxisRaw("Horizontal") != 1 && Input.GetAxisRaw("Vertical") != 1 && !Input.GetKeyDown(KeyCode.Q) && !Input.GetKeyDown(KeyCode.E))
        { 
            _artifact.transform.position = Vector3.Lerp(_artifact.transform.position, _artifactTransitDestination.position, _artifactTransitionSpeed * Time.deltaTime);
            yield return null;
        }
    }

    public void StartTransition(Transform _artifactTransitDestination)
    {
        StopAllCoroutines();
        StartCoroutine(ArtifactTransit(_artifactTransitDestination));
    }
}

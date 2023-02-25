using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtifactPositionForMysteries : MonoBehaviour
{
    [SerializeField] private GameObject _camera;

    void Update()
    {
        transform.rotation = new Quaternion(transform.rotation.x, _camera.transform.rotation.y, transform.rotation.z, _camera.transform.rotation.y);
    }
}

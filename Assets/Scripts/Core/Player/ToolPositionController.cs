using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolPositionController : MonoBehaviour
{
    [SerializeField] private Transform _toolPositionInHand;

    void Update()
    {
        transform.position = _toolPositionInHand.position;
        transform.rotation = _toolPositionInHand.rotation;
    }
}

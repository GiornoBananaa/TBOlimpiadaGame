using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Mystery1Trigger : MonoBehaviour
{
    [SerializeField] private GameObject _pressButtonHint;
    [SerializeField] private Mystery1 _mysteryScript;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMovementController>())
        {
            _mysteryScript.enabled = true;
            _pressButtonHint.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerMovementController>())
        {
            _mysteryScript.enabled = false;
            _pressButtonHint.SetActive(false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableGameObject : MonoBehaviour
{
    private void Disable()
    {
        gameObject.SetActive(false);
    }
}

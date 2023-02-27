using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCollider : MonoBehaviour
{
    [SerializeField] private GameObject _key;

    private void Start()
    {
        Physics.IgnoreCollision(_key.GetComponent<Collider>(), GetComponent<Collider>());
    }

    void Update()
    {
        transform.position = _key.transform.position;
    }
}

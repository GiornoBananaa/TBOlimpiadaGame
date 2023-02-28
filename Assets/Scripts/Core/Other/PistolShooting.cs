using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolShooting : MonoBehaviour
{
    [SerializeField] private Transform _gunPoint;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private float _cooldown;

    private float _timeAfterShoot;


    private void Start()
    {
        _timeAfterShoot = 0;
    }

    private void Update()
    {
        _timeAfterShoot += Time.deltaTime;

        if(_timeAfterShoot > _cooldown && Input.GetMouseButton(0))
        {
            Instantiate(_bullet, _gunPoint);
        }
    }
}

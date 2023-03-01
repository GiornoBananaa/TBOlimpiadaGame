using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolShooting : MonoBehaviour
{
    [SerializeField] private Transform _gunPoint;
    [SerializeField] private Transform _player;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private float _cooldown;

    private float _timeAfterShoot;
    private Ray _ray;
    private RaycastHit _rayHit;
    private float i;


    private void Start()
    {
        _timeAfterShoot = 0;
    }

    private void Update()
    {
        _timeAfterShoot += Time.deltaTime;

        if(_timeAfterShoot > _cooldown && Input.GetMouseButtonDown(1))
        {
            _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(_ray, out _rayHit, 1000))
            {
                Vector3 lookPosition = new Vector3(_rayHit.point.x, _player.position.y, _rayHit.point.z) - _player.position;
                _player.rotation = Quaternion.LookRotation(lookPosition);
            }
            GameObject bullet = Instantiate(_bullet, _gunPoint.position, _gunPoint.transform.rotation);
            bullet.transform.parent = null;

            _timeAfterShoot = 0;
        }
    }
}

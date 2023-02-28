using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private int _enemyLayerNumber;
    [SerializeField] private int _damage;
    [SerializeField] private Animation _bulletHit;

    private Rigidbody _rigidbody;


    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _rigidbody.velocity = transform.forward * _bulletSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == _enemyLayerNumber)
        {
            //collision.gameObject.GetComponent<EnemyScript>().GetDamage(_damage);
        }
        //_bulletHit.Play();
        Destroy(gameObject);
    }
}

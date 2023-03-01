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
        _rigidbody.velocity = transform.up * _bulletSpeed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.layer == _enemyLayerNumber)
        {
            collision.gameObject.GetComponent<EnemyScript>().TakeDamage(_damage);
        }

        Destroy(gameObject);
    }
}

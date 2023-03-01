using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _lookRotationSpeed;
    [SerializeField] private int _attackDamage;
    [SerializeField] private int _HP;
    [SerializeField] private Animator _animator;

    private GameObject _player;
    private bool _followPlayer;
    private bool _playerInAttackZone;


    void Start()
    {
        _followPlayer = false;
        _playerInAttackZone = false;
    }

    void Update()
    {
        if (_followPlayer)
        {
            Vector3 lookPosition = _player.transform.position - transform.position;
            lookPosition.y = 0;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(lookPosition), _lookRotationSpeed * Time.deltaTime);

            transform.position += transform.forward * _moveSpeed * Time.deltaTime;
        }
    }

    public void AttackZone(bool enter)
    {
        if(enter)
            _animator.SetTrigger("Attack");

        _playerInAttackZone = enter;
        _followPlayer = false;
    }

    public void DealDamage()
    {
        if (_playerInAttackZone)
        {
            _player.GetComponent<HealthManager>().TakeDamage(_attackDamage);
        }
    }

    public void TakeDamage(int damage)
    {
        _HP -= damage;

        if (_HP <= 0)
        {
            _animator.SetTrigger("Death");
        }
    }

    public void FollowPlayer(GameObject player, bool follow)
    {
        _player = player;
        _followPlayer = follow;
        _animator.SetBool("Move", follow);
    }

    public void FollowPlayer(bool follow)
    {
        _followPlayer = follow;
        _animator.SetBool("Move", follow);
    }


}

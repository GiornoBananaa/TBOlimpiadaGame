using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HealthManager : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private Animator _animator;
    [SerializeField] private PlayerMovementController _movement;
    [SerializeField] private ObserveArtifact _observe;
    [SerializeField] private Mystery1Trigger _mystery;

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            _mystery.enabled = false;
            _observe.enabled = false;
            _movement.enabled = false;
            _animator.SetTrigger("Death");
        }
    }
}

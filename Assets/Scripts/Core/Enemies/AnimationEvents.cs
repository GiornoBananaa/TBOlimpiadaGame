using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvents : MonoBehaviour
{
    [SerializeField] private EnemyScript _enemy;

    private void Attack()
    {
        _enemy.DealDamage();
    }

    private void ContinueMove()
    {
        _enemy.FollowPlayer(true);
    }

    private void Death()
    {
        Destroy(transform.parent.gameObject);
    }
}

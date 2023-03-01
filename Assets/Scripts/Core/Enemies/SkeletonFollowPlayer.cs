using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonFollowPlayer : MonoBehaviour
{
    [SerializeField] private EnemyScript _enemy;


    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMovementController>())
        {
            _enemy.FollowPlayer(other.gameObject, true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerMovementController>())
        {
            _enemy.FollowPlayer(other.gameObject, false);
        }
    }
}

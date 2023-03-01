using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonAttack : MonoBehaviour
{
    [SerializeField] private EnemyScript _enemy;

    private void OnTriggerStay(Collider other)
    {
        if(other.GetComponent<PlayerMovementController>())
        {
            _enemy.AttackZone(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerMovementController>())
        {
            _enemy.AttackZone(false);
        }
    }
}

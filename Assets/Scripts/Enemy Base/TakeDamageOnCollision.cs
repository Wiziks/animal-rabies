using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyHealth))]
public class TakeDamageOnCollision : MonoBehaviour
{
    [SerializeField] private int _damageValue = 1;
    [SerializeField] private bool _damageOnAnyCollision;
    private EnemyHealth enemyHealth;

    private void Start()
    {
        enemyHealth = GetComponent<EnemyHealth>();
    }
    private void OnCollisionEnter(Collision other)
    {
        Rigidbody rigidbody = other.rigidbody;
        if (rigidbody)
        {
            if (rigidbody.TryGetComponent(out Bullet bullet))
            {
                enemyHealth.TakeDamage(_damageValue);
                return;
            }
        }
        if (_damageOnAnyCollision)
        {
            enemyHealth.TakeDamage(99999);
        }
    }
}

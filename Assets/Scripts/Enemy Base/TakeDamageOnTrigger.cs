using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyHealth))]
public class TakeDamageOnTrigger : MonoBehaviour
{
    [SerializeField] private int _damageValue = 1;
    [SerializeField] private bool _damageOnAnyCollision;
    private EnemyHealth enemyHealth;

    private void Start()
    {
        enemyHealth = GetComponent<EnemyHealth>();
    }
    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rigidbody = other.attachedRigidbody;
        if (rigidbody)
        {
            if (rigidbody.TryGetComponent(out Bullet bullet))
            {
                enemyHealth.TakeDamage(_damageValue);
                Destroy(rigidbody.gameObject);
                return;
            }
        }
        if (_damageOnAnyCollision && !other.isTrigger)
        {
            enemyHealth.TakeDamage(99999);
        }
    }
}

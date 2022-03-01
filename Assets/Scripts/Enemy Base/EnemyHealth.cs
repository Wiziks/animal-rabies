using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int _health = 5;
    [SerializeField] private UnityEvent _eventOnTakeDamage;
    [SerializeField] private UnityEvent _eventOnDie;

    public void TakeDamage(int damageValue)
    {
        _health -= damageValue;
        if (_health <= 0)
        {
            Die();
        }
        _eventOnTakeDamage.Invoke();
    }

    private void Die()
    {
        Destroy(gameObject);
        _eventOnDie.Invoke();
    }
}

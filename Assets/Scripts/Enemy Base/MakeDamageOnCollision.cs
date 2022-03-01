using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeDamageOnCollision : MonoBehaviour
{
    [SerializeField] private int _damageValue = 1;

    private void OnCollisionEnter(Collision other)
    {
        Rigidbody rigidbody = other.rigidbody;
        if (rigidbody)
        {
            if (rigidbody.TryGetComponent(out PlayerHealth playerHealth))
            {
                playerHealth.TakeDamage(_damageValue);
            }
        }
    }
}

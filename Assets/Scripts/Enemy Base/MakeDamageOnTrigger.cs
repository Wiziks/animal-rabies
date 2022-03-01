using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeDamageOnTrigger : MonoBehaviour
{
    [SerializeField] private int _damageValue = 1;
    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rigidbody = other.attachedRigidbody;
        if (rigidbody)
        {
            if (rigidbody.TryGetComponent(out PlayerHealth playerHealth))
            {
                playerHealth.TakeDamage(_damageValue);
            }
        }
    }
}

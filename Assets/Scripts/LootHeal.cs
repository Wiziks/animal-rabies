using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootHeal : MonoBehaviour
{
    [SerializeField] private int _healValue = 1;

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rigidbody = other.attachedRigidbody;
        if (rigidbody)
        {
            PlayerHealth playerHealth = rigidbody.GetComponent<PlayerHealth>();
            if (playerHealth)
            {
                playerHealth.AddHealth(_healValue);
                Destroy(gameObject);
            }
        }
    }
}

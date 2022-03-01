using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBullet : MonoBehaviour
{
    [SerializeField] private int _gunIndex = 1;
    [SerializeField] private int _numberOBullets = 30;

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rigidbody = other.attachedRigidbody;
        if (rigidbody)
        {
            if (rigidbody.TryGetComponent<PlayerArmory>(out PlayerArmory playerArmory))
            {
                playerArmory.AddBullets(_gunIndex, _numberOBullets);
                Destroy(gameObject);
            }
        }
    }
}

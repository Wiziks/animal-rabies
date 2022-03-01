using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] GameObject _effectPrefab;
    [SerializeField] GameObject _explosiveSound;
    void Start()
    {
        Destroy(gameObject, 4f);
    }

    private void OnCollisionEnter(Collision other)
    {
        Instantiate(_effectPrefab, transform.position, Quaternion.identity);
        Instantiate(_explosiveSound, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}

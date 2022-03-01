using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Carrot : MonoBehaviour
{
    [SerializeField] private float _speed;
    private new Rigidbody rigidbody;
    private Transform _playerTransform;
    void Start()
    {
        transform.rotation = Quaternion.identity;
        rigidbody = GetComponent<Rigidbody>();
        _playerTransform = FindObjectOfType<PlayerMove>().transform;
        Vector3 toPlayer = (_playerTransform.position - transform.position).normalized;
        rigidbody.velocity = toPlayer * _speed;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Hen : MonoBehaviour
{

    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _timeToGetMaxSpeed;
    private Rigidbody _rigidbody;
    private Transform _playerTransform;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _playerTransform = FindObjectOfType<PlayerMove>().transform;
    }
    
    void FixedUpdate()
    {
        Vector3 toPlayer = (_playerTransform.position - transform.position).normalized;
        Vector3 force = _rigidbody.mass * (toPlayer * _maxSpeed - _rigidbody.velocity) / _timeToGetMaxSpeed;
        _rigidbody.AddForce(force);
    }
}

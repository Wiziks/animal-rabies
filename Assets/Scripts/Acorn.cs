using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acorn : MonoBehaviour
{
    [SerializeField] private Vector3 _forceDirection;
    [SerializeField] private float _maxAngularSpeed;
    void Start()
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.AddRelativeForce(_forceDirection, ForceMode.VelocityChange);
        float xAngularSpeed = Random.Range(-_maxAngularSpeed, _maxAngularSpeed);
        float yAngularSpeed = Random.Range(-_maxAngularSpeed, _maxAngularSpeed);
        float zAngularSpeed = Random.Range(-_maxAngularSpeed, _maxAngularSpeed);
        rigidbody.angularVelocity = new Vector3(xAngularSpeed, yAngularSpeed, zAngularSpeed);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;
    [SerializeField] private float _rotationSpeed = 3f;
    private Transform playerTransform;
    void Start()
    {
        playerTransform = FindObjectOfType<PlayerHealth>().transform;
        transform.LookAt(playerTransform);
    }

    void Update()
    {
        transform.Translate(transform.up * _speed * Time.deltaTime);
        Vector3 toPlayer = playerTransform.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(toPlayer, Vector3.forward);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
    }
}

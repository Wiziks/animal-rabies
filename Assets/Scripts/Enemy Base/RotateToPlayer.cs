using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToPlayer : MonoBehaviour
{
    [SerializeField] private float _rotateAngleLeft = 30f;
    [SerializeField] private float _rotateAngleRight = -150f;
    private Transform _playerTransform;
    private float x, z;
    void Start()
    {
        _playerTransform = FindObjectOfType<PlayerHealth>().transform;
        x = transform.rotation.eulerAngles.x;
        z = transform.rotation.eulerAngles.z;
    }

    void Update()
    {
        float _angleMultiplier = _rotateAngleLeft;
        if (_playerTransform.position.x > transform.position.x)
            _angleMultiplier = _rotateAngleRight;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(x, _angleMultiplier, z), 15 * Time.deltaTime);
    }
}

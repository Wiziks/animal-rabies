using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToTransform : MonoBehaviour
{
    [SerializeField] private Vector3 _leftEuler;
    [SerializeField] private Vector3 _rigthEuler;
    [SerializeField] private float _rotationSpeed;
    private Vector3 targetEuler;
    void Start()
    {
        targetEuler = _leftEuler;
    }
    void Update()
    {
        transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(targetEuler), _rotationSpeed * Time.deltaTime);
    }

    public void RotateRigth()
    {
        targetEuler = _rigthEuler;
    }
    public void RotateLeft()
    {
        targetEuler = _leftEuler;
    }
}

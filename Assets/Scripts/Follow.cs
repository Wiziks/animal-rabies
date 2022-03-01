using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    [SerializeField] Transform _target;
    [SerializeField] float _lerpRate;
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, _target.position, _lerpRate);
    }
}

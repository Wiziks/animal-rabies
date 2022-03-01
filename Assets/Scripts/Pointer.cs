using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    [SerializeField] Transform _playerTransform;
    [SerializeField] Transform _aim;
    [SerializeField] Camera _playerCamera;
    
    void LateUpdate()
    {
        Ray ray = _playerCamera.ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(Vector3.back, Vector3.zero);
        plane.Raycast(ray, out float distance);
        Vector3 point = ray.GetPoint(distance);
        _aim.position = point;
        transform.LookAt(point);
        int _angleMultiplier = 1;
        if (_playerTransform.position.x < point.x)
            _angleMultiplier = -1;
        _playerTransform.localRotation = Quaternion.Lerp(_playerTransform.localRotation, Quaternion.Euler(_playerTransform.localRotation.x, 45 * _angleMultiplier,
            _playerTransform.localRotation.z), 15 * Time.deltaTime);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

enum Direction
{
    Left,
    Right
}

public class Walker : MonoBehaviour
{
    [SerializeField] private Transform A;
    [SerializeField] private Transform B;
    [SerializeField] private float _speed;
    [SerializeField] private float _stopPeriod;
    [SerializeField] private UnityEvent _rigthRotationEvent;
    [SerializeField] private UnityEvent _leftRotationEvent;
    [SerializeField] private Transform _rayStartPoint;
    private Direction currentRotation;
    private bool _isStoped;
    void Start()
    {
        A.parent = null;
        B.parent = null;
    }
    void Update()
    {
        if (_isStoped) { return; }
        if (currentRotation == Direction.Left)
        {
            if (transform.position.x > A.position.x)
            {
                transform.position += Vector3.left * _speed * Time.deltaTime;
            }
            else
            {
                currentRotation = Direction.Right;
                _isStoped = true;
                Invoke(nameof(ContinueWalking), _stopPeriod);
                _rigthRotationEvent.Invoke();
            }
        }
        else
        {
            if (transform.position.x < B.position.x)
            {
                transform.position += Vector3.right * _speed * Time.deltaTime;
            }
            else
            {
                currentRotation = Direction.Left;
                _isStoped = true;
                Invoke(nameof(ContinueWalking), _stopPeriod);
                _leftRotationEvent.Invoke();
            }
        }
        RaycastHit hit;
        if (Physics.Raycast(_rayStartPoint.position, Vector3.down, out hit))
        {
            transform.position = hit.point;
        }
    }

    void ContinueWalking()
    {
        _isStoped = false;
    }
}

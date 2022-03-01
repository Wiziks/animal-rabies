using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] Rigidbody _rigidbody;
    [SerializeField] float _moveSpeed;
    [SerializeField] float _jumpSpeed;
    [SerializeField] float _friction;
    [SerializeField] bool _grounded;
    [SerializeField] bool _rise;
    [SerializeField] float _maxSpeed;
    [SerializeField] Transform _colliderTransform;
    [SerializeField] AudioSource _jumpSound;
    [SerializeField] ParticleSystem _groundEffect;
    private bool playedOnce;
    private int jumpFrameCounter;

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.S) || !_grounded)
        {
            _colliderTransform.localScale = Vector3.Lerp(_colliderTransform.localScale, new Vector3(1, 0.5f, 1), Time.deltaTime * 15f);
        }
        else
        {
            if (_rise)
                _colliderTransform.localScale = Vector3.Lerp(_colliderTransform.localScale, new Vector3(1, 1, 1), Time.deltaTime * 15f);
        }
        if (Input.GetKeyDown(KeyCode.Space) && _grounded)
        {
            Jump();
        }
    }

    public void Jump()
    {
        _rigidbody.AddForce(0, _jumpSpeed, 0, ForceMode.VelocityChange);
        jumpFrameCounter = 0;
        _jumpSound.Play();
    }

    private void FixedUpdate()
    {
        float _speedMultiplier = 1f;
        if (!_grounded)
        {
            _speedMultiplier = 0.1f;
            if (Input.GetAxis("Horizontal") > 0 && _rigidbody.velocity.x > _maxSpeed)
            {
                _speedMultiplier = 0;
            }
            if (Input.GetAxis("Horizontal") < 0 && _rigidbody.velocity.x < -_maxSpeed)
            {
                _speedMultiplier = 0;
            }
            jumpFrameCounter++;
        }
        else
        {
            _rigidbody.AddForce(-_rigidbody.velocity.x * _friction, 0, 0, ForceMode.VelocityChange);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.identity, Time.deltaTime * 15f);
        }
        _rigidbody.AddForce(Input.GetAxis("Horizontal") * _moveSpeed * _speedMultiplier, 0, 0, ForceMode.VelocityChange);
        if (jumpFrameCounter == 2)
        {
            _rigidbody.freezeRotation = false;
            _rigidbody.AddTorque(0f, 0f, 10f, ForceMode.VelocityChange);
        }
    }

    private void OnCollisionStay(Collision other)
    {
        foreach (var v in other.contacts)
        {
            float angle = Vector3.Angle(v.normal, Vector3.up);
            if (angle < 45)
            {
                _grounded = true;
                _rigidbody.freezeRotation = true;
                if (!playedOnce)
                {
                    playedOnce = true;
                    _groundEffect.Play();
                }
            }
            if (v.normal.y < -0.1f)
                _rise = false;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        Invoke(nameof(ChangeGrounded), 0.2f);
        _rise = true;
        playedOnce = false;
    }

    private void ChangeGrounded()
    {
        _grounded = false;
    }

    public bool GetGrounded()
    {
        return _grounded;
    }
}

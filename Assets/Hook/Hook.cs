using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    private FixedJoint fixedJoint;
    public Rigidbody Rigidbody;

    [SerializeField] private RopeGun _ropeGun;

    [SerializeField] private Collider _collider;
    [SerializeField] private Collider _playerCollider;

    void Start()
    {
        Physics.IgnoreCollision(_collider, _playerCollider);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (!fixedJoint)
        {
            fixedJoint = gameObject.AddComponent<FixedJoint>();
            _ropeGun.CreateSpring();
            Rigidbody rigidbody = other.rigidbody;
            if (rigidbody)
                fixedJoint.connectedBody = rigidbody;
        }
    }

    public void StopJoin()
    {
        Destroy(fixedJoint);
    }
}
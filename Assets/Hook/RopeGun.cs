using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RopeState   
{
    Disable,
    Fly,
    Active
}

public class RopeGun : MonoBehaviour
{
    [SerializeField] private Hook _hook;
    [SerializeField] private Transform _spawn;
    [SerializeField] private float _speed;
    [SerializeField] private Transform _ropeStart;
    [SerializeField] private RopeState ropeState;
    private SpringJoint _springJoint;
    [SerializeField] private float _length;
    [SerializeField] private RopeRenderer _ropeRenderer;
    [SerializeField] private PlayerMove _playerMove;

    void Update()
    {
        if (Input.GetMouseButtonDown(2))
        {
            Shot();
        }
        if(ropeState == RopeState.Fly)
        {
            float distance = Vector3.Distance(_ropeStart.position, _hook.transform.position);
            if(distance > 20f)
            {
                _hook.gameObject.SetActive(false);
                ropeState = RopeState.Disable;
                _ropeRenderer.Hide();
            }
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(ropeState == RopeState.Active && !_playerMove.GetGrounded())
            {
                _playerMove.Jump();
            }
            DestroySpring();
        }
        if(ropeState == RopeState.Active || ropeState == RopeState.Fly)
        {
            _ropeRenderer.Draw(_ropeStart.position, _hook.transform.position, _length);
        }
    }

    void Shot()
    {
        if(_springJoint)
            Destroy(_springJoint);
        _hook.gameObject.SetActive(true);
        _hook.StopJoin();
        _hook.transform.position = _spawn.position;
        _hook.transform.rotation = _spawn.rotation;
        _hook.Rigidbody.velocity = _spawn.forward * _speed;
        ropeState = RopeState.Fly;
    }

    public void CreateSpring()
    {
        if (!_springJoint)
        {
            _springJoint = gameObject.AddComponent<SpringJoint>();
            _springJoint.connectedBody = _hook.Rigidbody;
            _springJoint.autoConfigureConnectedAnchor = false;
            _springJoint.connectedAnchor = Vector3.zero;
            _springJoint.anchor = _ropeStart.localPosition;
            _springJoint.spring = 100f;
            _springJoint.damper = 5f;
            _length = Vector3.Distance(_ropeStart.position, _hook.transform.position);
            _springJoint.maxDistance = _length;
            ropeState = RopeState.Active;
        }
    }

    public void DestroySpring()
    {
        if(_springJoint)
        {
            Destroy(_springJoint);
            ropeState = RopeState.Disable;
            _hook.gameObject.SetActive(false);
            _ropeRenderer.Hide();
        }
    }
}
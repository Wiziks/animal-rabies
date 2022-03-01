using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class SetTriggerEveryNSecond : MonoBehaviour
{
    [SerializeField] private float _period;
    [SerializeField] string _triggerName = "Attack";
    private Animator _animator;
    private float _timer = 0;
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= _period)
        {
            _timer = 0;
            _animator.SetTrigger(_triggerName);
        }
    }
}

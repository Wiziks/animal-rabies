using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpGun : MonoBehaviour
{
    [SerializeField] private Rigidbody _player;
    [SerializeField] private float _speed;
    [SerializeField] private Transform _spawn;
    [SerializeField] private Gun _pistol;
    [SerializeField] private float _maxCharge = 3f;
    [SerializeField] private ChargeIcon _chargeIcon;
    private float currentCharge;
    private bool isCharge;
    void Update()
    {
        if (isCharge)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                _player.AddForce(-_spawn.forward * _speed, ForceMode.VelocityChange);
                _pistol.Shot();
                isCharge = false;
                currentCharge = 0f;
                _chargeIcon.StartCharge();
            }
        }
        else
        {
            currentCharge += Time.unscaledDeltaTime;
            _chargeIcon.SetValueCharge(currentCharge, _maxCharge);
            if (currentCharge >=_maxCharge)
            {
                isCharge = true;
                _chargeIcon.StopCharge();
            }
        }
    }
}

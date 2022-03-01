using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Automat : Gun
{
    [Header("Automat")]
    [SerializeField] private int _numberOBullet;
    [SerializeField] private TextMeshProUGUI _bulletsText;
    [SerializeField] private PlayerArmory _playerArmory;

    public override void Shot()
    {
        base.Shot();
        _bulletsText.text = $"Пули: {_numberOBullet--}";
        if (_numberOBullet <= 0)
        {
            _playerArmory.TakeGunByIndex(0);
        }
    }
    public override void Activate()
    {
        base.Activate();
        _bulletsText.text = $"Пули: {_numberOBullet}";
        _bulletsText.enabled = true;
    }

    public override void Deactivate()
    {
        base.Deactivate();
        _bulletsText.enabled = false;
        
    }

    public override void AddBullets(int count)
    {
        _numberOBullet += count;
        _bulletsText.text = $"Пули: {_numberOBullet}";
    }
}

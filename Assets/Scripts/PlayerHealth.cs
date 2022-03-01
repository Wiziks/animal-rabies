using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int _health = 5;
    [SerializeField] private int _maxHealth = 8;
    [SerializeField] private AudioSource _addHealthSound;
    [SerializeField] private HealthUI _healthUI;
    [SerializeField] private UnityEvent _eventOnTakeDamage;
    [SerializeField] private GameObject _losePanel;

    private bool _invulrable;
    private void Start()
    {
        _healthUI.Setup(_maxHealth);
        _healthUI.DisplayIcons(_health);
    }
    public void TakeDamage(int damageValue)
    {
        if (!_invulrable)
        {
            _health -= damageValue;
            if (_health <= 0)
            {
                _health = 0;
                Die();
            }
            _invulrable = true;
            Invoke(nameof(TurnInvulrable), 1f);
            _healthUI.DisplayIcons(_health);
            _eventOnTakeDamage.Invoke();
        }
    }

    public void AddHealth(int healValue)
    {
        _health += healValue;
        if (_health > _maxHealth)
        {
            _health = _maxHealth;
        }
        _addHealthSound.Play();
        _healthUI.DisplayIcons(_health);
    }

    private void TurnInvulrable()
    {
        _invulrable = false;
    }

    private void Die()
    {
        transform.position = new Vector3(transform.position.x,transform.position.y, -2);
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.AddForce(0, 15, 0, ForceMode.VelocityChange);
        rigidbody.constraints = RigidbodyConstraints.FreezePositionX & RigidbodyConstraints.FreezePositionY;
        Invoke(nameof(ShowLosePanel), 1.5f);
    }

    private void ShowLosePanel()
    {
        _losePanel.SetActive(true);
    }
}

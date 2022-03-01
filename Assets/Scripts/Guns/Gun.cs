using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] GameObject _bulletPrefab;
    [SerializeField] Transform _spawn;
    [SerializeField] float _bulletSpeed;
    [SerializeField] float _rateOfFire;
    [SerializeField] AudioSource _shotSound;
    [SerializeField] GameObject _flash;
    [SerializeField] ParticleSystem _smokeEffect;
    private float _shotPeriod;
    private float _timer;

    private void Start()
    {
        _shotPeriod = 60 / _rateOfFire;
    }
    private void Update()
    {
        _timer += Time.unscaledDeltaTime;
        if (_timer > _shotPeriod && Input.GetMouseButton(0))
        {
            _timer = 0;
            Shot();
        }
    }

    public virtual void Shot()
    {
        GameObject _newBullet = Instantiate(_bulletPrefab, _spawn.position, _spawn.rotation);
        _newBullet.GetComponent<Rigidbody>().velocity = _spawn.forward * _bulletSpeed;
        _shotSound.Play();
        _smokeEffect.Play();
        _flash.SetActive(true);
        Invoke(nameof(HideFlash), 0.12f);
    }

    private void HideFlash()
    {
        _flash.SetActive(false);
    }

    public virtual void Activate()
    {
        gameObject.SetActive(true);
    }

    public virtual void Deactivate()
    {
        gameObject.SetActive(false);
    }

    public virtual void AddBullets(int count) { }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private float _timeScale = 0.3f;
    private float _startDeltaTime;
    void Start()
    {
        _startDeltaTime = Time.fixedDeltaTime;
    }

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            Time.timeScale = _timeScale;
        }
        else
        {
            Time.timeScale = 1;
        }
        Time.fixedDeltaTime = _startDeltaTime * Time.deltaTime;
    }

    private void OnDestroy()
    {
        Time.fixedDeltaTime = _startDeltaTime;
    }
}
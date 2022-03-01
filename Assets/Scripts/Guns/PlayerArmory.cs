using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArmory : MonoBehaviour
{
    [SerializeField] private Gun[] _guns;
    [SerializeField] private int _currentIndex;
    void Start()
    {
        foreach(var v in _guns)
        {
            v.Deactivate();
        }
        TakeGunByIndex(_currentIndex);
    }

    public void TakeGunByIndex(int gunIndex)
    {
        _guns[_currentIndex].Deactivate();
        _currentIndex = gunIndex;
        _guns[gunIndex].Activate();
    }

    public void AddBullets(int index, int count)
    {
        TakeGunByIndex(index);
        _guns[index].AddBullets(count);
    }
}

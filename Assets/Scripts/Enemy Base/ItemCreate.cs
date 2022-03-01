using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCreate : MonoBehaviour
{
    [SerializeField] private GameObject _itemPrefab;
    [SerializeField] private Transform _startPosition;

    public void Spawn()
    {
        Instantiate(_itemPrefab, _startPosition.position, _startPosition.rotation);
    }
}

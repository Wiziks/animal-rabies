using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BacthItemCreate : MonoBehaviour
{
    [SerializeField] private GameObject _itemPrefab;
    [SerializeField] private Transform[] _startPositions;

    [ContextMenu("Spawn")]
    public void Spawn()
    {
        foreach (var v in _startPositions)
            Instantiate(_itemPrefab, v.position, v.rotation);
    }
}

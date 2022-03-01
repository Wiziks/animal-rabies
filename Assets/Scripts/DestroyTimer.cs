using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTimer : MonoBehaviour
{
    [SerializeField] float _destroyTimer;
    void Start()
    {
        Destroy(gameObject, _destroyTimer);
    }
}

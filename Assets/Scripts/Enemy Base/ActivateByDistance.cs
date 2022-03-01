using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class ActivateByDistance : MonoBehaviour
{
    [Range(5f, 50f)]
    [SerializeField] private float _distanceToActivate = 20;
    private bool isActive = true;
    private EnemyManager enemyManager;
    private void Awake()
    {
        enemyManager = FindObjectOfType<EnemyManager>();
        enemyManager._enemies.Add(this);
    }

    public void CheckDistance(Vector3 playerPosition)
    {
        float distance = Vector3.Distance(transform.position, playerPosition);
        if (isActive)
        {
            if (distance > _distanceToActivate + 2)
            {
                Deactivate();
            }

        }
        else
        {
            if (distance < _distanceToActivate)
            {
                Activate();
            }
        }
    }

    void Activate()
    {
        isActive = true;
        gameObject.SetActive(true);
    }

    void Deactivate()
    {
        isActive = false;
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        enemyManager.UpdateScore(this);
    }
#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.grey;
        Handles.DrawWireDisc(transform.position, Vector3.forward, _distanceToActivate);
    }
#endif
}

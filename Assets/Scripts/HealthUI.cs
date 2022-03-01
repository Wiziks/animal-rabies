using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private GameObject _healthIconPrefab;
    private List<GameObject> healthIcons = new List<GameObject>();

    public void Setup(int maxHealthCount)
    {
        for (int i = 0; i < maxHealthCount; i++)
        {
            healthIcons.Add(Instantiate(_healthIconPrefab, transform));
        }
    }

    public void DisplayIcons(int currentHealth)
    {
        for (int i = 0; i < healthIcons.Count; i++)
        {
            if (i < currentHealth)
            {
                healthIcons[i].SetActive(true);
            }
            else
            {
                healthIcons[i].SetActive(false);
            }
        }
    }
}

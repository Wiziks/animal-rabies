using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyManager : MonoBehaviour
{
    public List<ActivateByDistance> _enemies;
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private GameObject _winPanel;
    private int score;
    private Transform _playerTransform;
    void Start()
    {
        score = _enemies.Count;
        UpdateText();
        _playerTransform = FindObjectOfType<PlayerMove>().transform;
    }
    private void Update()
    {
        CheckDistance();
    }
    void CheckDistance()
    {
        foreach (var v in _enemies)
        {
            v.CheckDistance(_playerTransform.position);
        }
    }

    public void UpdateScore(ActivateByDistance destroyObject)
    {
        foreach (var v in _enemies)
        {
            if (destroyObject == v)
            {
                score--;
                _enemies.Remove(v);
                UpdateText();
                if (score <= 0)
                {
                    _winPanel.SetActive(true);
                }
                return;
            }
        }
    }

    private void UpdateText()
    {
        _scoreText.text = $"Врагов осталось {score}";
    }
}

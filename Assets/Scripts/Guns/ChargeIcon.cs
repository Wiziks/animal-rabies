using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChargeIcon : MonoBehaviour
{
    [SerializeField] private Image _foreground;
    [SerializeField] private Image _background;
    [SerializeField] private TextMeshProUGUI _timerText;

    public void StartCharge()
    {
        _foreground.enabled = true;
        _timerText.enabled = true;
        _background.color = new Color(1,1,1,0.2f);
    }

    public void StopCharge()
    {
        _foreground.enabled = false;
        _timerText.enabled = false;
        _background.color = new Color(1,1,1,1);
    }

    public void SetValueCharge(float current, float max)
    {
        _foreground.fillAmount = current/max;
        _timerText.text = "" + Mathf.Ceil(max - current);
    }
}

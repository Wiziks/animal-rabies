using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageScreen : MonoBehaviour
{
    [SerializeField] private Image _damegeImage;

    public void StartEffect()
    {
        StartCoroutine(DamageEffect());
    }

    private IEnumerator DamageEffect()
    {
        _damegeImage.enabled = true;
        for (float t = 1f; t > 0f; t -= Time.deltaTime)
        {
            _damegeImage.color = new Color(1f, 0f, 0f, t);
            yield return null;
        }
        _damegeImage.enabled = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour
{
    [SerializeField] private Renderer[] _renderers;

    public void StartEffect()
    {
        StartCoroutine(BlinkEffect());
        Invoke(nameof(TurnOffBlink), 0.8f);
    }

    private IEnumerator BlinkEffect()
    {
        for (float t = 0f; t < 0.6f; t += Time.deltaTime)
        {
            foreach (var v in _renderers)
            {
                foreach (var m in v.materials)
                {
                    m.EnableKeyword("_EMISSION");
                    m.SetColor("_EmissionColor", new Color(Mathf.Sin(t * 50f) * 0.5f + 0.5f, 0, 0, 0));
                }
            }
            yield return null;
        }
    }

    private void TurnOffBlink()
    {
        foreach (var v in _renderers)
        {
            foreach (var m in v.materials)
            {
                m.EnableKeyword("_EMISSION");
                m.SetColor("_EmissionColor", new Color(0, 0, 0, 0));
            }
        }
    }
}

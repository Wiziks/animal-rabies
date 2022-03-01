using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject _menuButton;
    [SerializeField] private GameObject _menuWindow;
    [SerializeField] private MonoBehaviour[] _componentsToDisable;

    public void OpenMenuWindow()
    {
        _menuButton.SetActive(false);
        _menuWindow.SetActive(true);
        foreach (var v in _componentsToDisable)
            v.enabled = false;
        Time.timeScale = 0.01f;
    }

    public void CloseMenuWindow()
    {
        _menuButton.SetActive(true);
        _menuWindow.SetActive(false);
        foreach (var v in _componentsToDisable)
            v.enabled = true;
        Time.timeScale = 1f;
    }
}

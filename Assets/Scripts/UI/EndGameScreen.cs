using System;
using UnityEngine;
using UnityEngine.UI;

public class EndGameScreen : Window
{
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _menuButton;

    public event Action RestartButtonCliked;
    public event Action MenuButtonCliked;

    private void OnEnable()
    {
        _restartButton.onClick.AddListener(OnRestartButtonCliked);
        _menuButton.onClick.AddListener(OnMenuButtonCliked);
    }

    private void OnDisable()
    {
        _restartButton.onClick.RemoveListener(OnRestartButtonCliked);
        _menuButton.onClick.RemoveListener(OnMenuButtonCliked);
    }

    private void OnRestartButtonCliked()
    {
        RestartButtonCliked?.Invoke();
    }

    private void OnMenuButtonCliked()
    {
        MenuButtonCliked?.Invoke();
    }
}
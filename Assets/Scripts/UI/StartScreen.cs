using System;
using UnityEngine;
using UnityEngine.UI;

public class StartScreen : Window
{
    [SerializeField] private Button _startButton;

    public event Action PlayButtonClicked;

    private void OnEnable()
    {
        _startButton.onClick.AddListener(OnPlayButtonClicked);
    }

    private void OnDisable()
    {
        _startButton.onClick.RemoveListener(OnPlayButtonClicked);
    }

    private void OnPlayButtonClicked()
    {
        PlayButtonClicked?.Invoke();
    }
}
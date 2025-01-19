using UnityEngine;

public abstract class Window : MonoBehaviour
{
    [SerializeField] private CanvasGroup _windowGroup;

    private bool _isActive = false;

    public bool IsActive => _isActive;

    public void Open()
    {
        _isActive = true;
        _windowGroup.alpha = 1f;
        _windowGroup.interactable = true;
        _windowGroup.blocksRaycasts = true;
    }

    public void Close()
    {
        _isActive = false;
        _windowGroup.alpha = 0f;
        _windowGroup.interactable = false;
        _windowGroup.blocksRaycasts = false;
    }
}
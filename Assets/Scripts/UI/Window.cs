using UnityEngine;

public abstract class Window : MonoBehaviour
{
    [SerializeField] private CanvasGroup _windowGroup;

    protected CanvasGroup WindowGroup => _windowGroup;

    public void Open()
    {
        WindowGroup.alpha = 1f;
        WindowGroup.interactable = true;
        WindowGroup.blocksRaycasts = true;
    }

    public void Close()
    {
        WindowGroup.alpha = 0f;
        WindowGroup.interactable = false;
        WindowGroup.blocksRaycasts = false;
    }
}
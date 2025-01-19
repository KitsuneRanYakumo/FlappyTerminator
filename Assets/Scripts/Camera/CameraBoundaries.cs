using UnityEngine;

[RequireComponent(typeof(BoxCollider2D), typeof(Camera))]
public class CameraBoundaries : MonoBehaviour
{
    [SerializeField] private float _sizeRatio = 1.2f;

    private Camera _camera;
    private BoxCollider2D _boxCollider2D;

    private void Awake()
    {
        _camera = GetComponent<Camera>();
        _boxCollider2D = GetComponent<BoxCollider2D>();
    }

    private void Start()
    {
        _boxCollider2D.size = GetSize();
        _boxCollider2D.isTrigger = true;
    }

    private Vector2 GetSize()
    {
        Vector2 size = _camera.ViewportToWorldPoint(new Vector3(1f, 1f, _camera.nearClipPlane)) -
                       _camera.ViewportToWorldPoint(new Vector3(0, 0, _camera.nearClipPlane));
        size *= _sizeRatio;
        return size;
    }
}
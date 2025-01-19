using System.Collections;
using UnityEngine;

public class BulletMover : MonoBehaviour
{
    private bool _isMoving;
    private Coroutine _coroutine;

    public void Reset()
    {
        _isMoving = false;
    }

    public void Initialize(Vector3 position, Vector3 direction, float moveSpeed)
    {
        transform.position = position;
        _isMoving = true;

        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(MoveTowards(direction, moveSpeed));
    }

    public void StopMoving()
    {
        _isMoving = false;
    }

    private IEnumerator MoveTowards(Vector3 direction, float moveSpeed)
    {
        while (_isMoving)
        {
            transform.Translate(moveSpeed * Time.deltaTime * direction);
            yield return null;
        }
    }
}
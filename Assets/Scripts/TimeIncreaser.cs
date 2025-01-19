using System.Collections;
using UnityEngine;

public class TimeIncreaser : MonoBehaviour
{
    [SerializeField] private float _speedIncrease = 0.01f;

    private Coroutine _coroutine;

    public void StartIncreaseTimeScale()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(IncreaseTimeScale());
    }

    public void EndIncreaseTimeScale()
    {
        StopCoroutine(_coroutine);
    }

    private IEnumerator IncreaseTimeScale()
    {
        while (enabled)
        {
            Time.timeScale += _speedIncrease * Time.deltaTime;
            yield return null;
        }
    }
}
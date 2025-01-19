using UnityEngine;

public class PlayerTacker : MonoBehaviour
{
    [SerializeField] private Player _player;

    private float _xOffset;

    private void Start()
    {
        _xOffset = transform.position.x - _player.transform.position.x;
    }

    private void Update()
    {
        TrackUnit();
    }

    private void TrackUnit()
    {
        Vector3 position = transform.position;
        position.x = _player.transform.position.x + _xOffset;
        transform.position = position;
    }
}
using UnityEngine;

[RequireComponent(typeof(UserInput))]
public class Player : Unit
{
    [SerializeField] private Mover _mover;
    [SerializeField] private Rotator _rotator;
    [SerializeField] private ScoreCounter _scoreCounter;
    [SerializeField] private EndGameDetector _endGameObjectDetector;

    private UserInput _userInput;
    private bool _isFlying;

    public override void Reset()
    {
        base.Reset();
        _scoreCounter.Reset();
        _mover.Reset();
        _rotator.Reset();
    }

    private void Awake()
    {
        _userInput = GetComponent<UserInput>();
    }

    private void OnEnable()
    {
        _endGameObjectDetector.FacedWithEndGameObject += OnLifeTimeFinished;
    }

    private void FixedUpdate()
    {
        if (_isFlying)
        {
            _mover.Move();
            _isFlying = false;
        }
    }

    private void Update()
    {
        if (_userInput.IsFlightButtonPressed)
        {
            _rotator.SetMaxRotation();
            _isFlying = true;
        }

        if (_userInput.IsShotButtonPressed)
        {
            Weapon.Shoot();
        }
    }

    private void OnDisable()
    {
        _endGameObjectDetector.FacedWithEndGameObject -= OnLifeTimeFinished;
    }
}
using UnityEngine;

public class PlayerAnimationsSwitcher : AnimationsSwitcher<Player>
{
    private readonly int _flightTrigger = Animator.StringToHash("FlightTrigger");

    protected override void OnEnable()
    {
        base.OnEnable();
        Unit.FlightStarted += SetFlightTrigger;
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        Unit.FlightStarted -= SetFlightTrigger;
    }

    private void SetFlightTrigger()
    {
        Animator.SetTrigger(_flightTrigger);
    }
}
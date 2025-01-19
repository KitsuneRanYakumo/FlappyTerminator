using UnityEngine;

[RequireComponent(typeof(Animator))]
public abstract class AnimationsSwitcher<T> : MonoBehaviour where T : Unit
{
    [SerializeField] protected T Unit;

    private readonly int _takeDamageTrigger = Animator.StringToHash("TakeDamageTrigger");

    protected Animator Animator;

    private void Awake()
    {
        Animator = GetComponent<Animator>();
    }

    protected virtual void OnEnable()
    {
        Unit.DamageTaken += SetDamageTrigger;
    }

    protected virtual void OnDisable()
    {
        Unit.DamageTaken -= SetDamageTrigger;
    }

    private void SetDamageTrigger()
    {
        Animator.SetTrigger(_takeDamageTrigger);
    }
}
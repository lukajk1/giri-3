using UnityEngine;
using UnityEngine.AI;

public abstract class EnemyController : UnitController
{

    [SerializeField] public Animator animator;
    [SerializeField] public NavMeshAgent navAgent;
    protected IState currentState;

    [HideInInspector] public Unit unit;

    protected virtual void Update()
    {
        currentState.Tick();
    }
    public void ChangeState(IState nextState)
    {
        currentState.Exit();
        currentState = nextState;
        currentState.Enter();
    }

    protected virtual void OnDeath()
    {
        ChangeState(new EmptyState(this));
        unit.healthbar.gameObject.SetActive(false);
    }
}
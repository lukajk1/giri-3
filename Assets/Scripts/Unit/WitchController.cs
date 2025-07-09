using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class WitchController : MonoBehaviour
{
    [SerializeField] public Animator animator;
    [SerializeField] public NavMeshAgent navAgent;

    [HideInInspector] public Unit unit;
    protected IState currentState;
    private Coroutine attackCooldown;

    private float attackCD = 8f;

    // not ideal but not that annoying to hardcode either
    private float attackAnimLength = 1.375f;

    #region setup
    public virtual void Init(Unit unit)
    {
        this.unit = unit; 
        
        unit.OnDeath += OnDeath;
        unit.OnDamageTaken += OnDamageTaken;

        currentState = new IdleState(this);
        currentState.Enter();
    }

    private void OnDisable()
    {
        unit.OnDeath -= OnDeath;
        unit.OnDamageTaken -= OnDamageTaken;
    }
    #endregion

    private void Update()
    {
        currentState.Tick();
    }

    public void MoveToState(IState nextState)
    {
        currentState.Exit();
        currentState = nextState;
        currentState.Enter();
    }
    public bool AttackUp()
    {
        return attackCooldown == null;
    }
    public void Attack(Action OnComplete)
    {
        animator.SetTrigger("Attack");
        attackCooldown = StartCoroutine(AttackCooldownCR(attackCD));
        StartCoroutine(AnimLengthCR(attackAnimLength, OnComplete)); 
    }
    private IEnumerator AttackCooldownCR(float duration)
    {
        float elapsed = 0f;
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            yield return null;
        }

        attackCooldown = null;
    }
    private IEnumerator AnimLengthCR(float duration, Action OnComplete)
    {
        float elapsed = 0f;
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            yield return null;
        }

        OnComplete?.Invoke();
    }

    #region combat
    protected void OnDamageTaken(CombatData data) { }
    protected void OnDeath()
    {
        currentState.Exit();
        Destroy(unit.healthbar.gameObject);
        animator.SetTrigger("Die");
        navAgent.speed = 0f;
    }
    #endregion
}
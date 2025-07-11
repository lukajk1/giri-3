using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class WitchController : EnemyController
{
    [SerializeField] public StateDisplay stateDisplay;
    // states
    [SerializeField] public AttackState attackState;
    [SerializeField] public MoveState moveState;
    [SerializeField] public IdleState idleState;

    private Coroutine attackCooldown;

    private float attackCD = 8f;

    // not ideal but not that annoying to hardcode either
    private const float attackFrames = 34f;
    private const float deathFrames = 47f;

    #region setup
    private void Awake()
    {
        attackState.Init(this);
        moveState.Init(this);
        idleState.Init(this);
    }
    public override void Init(Unit unit)
    {
        this.unit = unit; 
        
        unit.OnDeath += OnDeath;
        unit.OnDamageTaken += OnDamageTaken;

        currentState = idleState;
        currentState.Enter();
    }

    private void OnDisable()
    {
        unit.OnDeath -= OnDeath;
        unit.OnDamageTaken -= OnDamageTaken;
    }
    #endregion

    public bool AttackUp()
    {
        return attackCooldown == null;
    }
    public void Attack(Action OnComplete)
    {
        attackCooldown = StartCoroutine(AttackCooldownCR(attackCD));
        StartCoroutine(
            RunUtil.i.DelayAndCallbackCR(RunUtil.AnimFramesToSecs(attackFrames), OnComplete)
            ); 
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

    #region combat
    protected void OnDamageTaken(CombatData data) { }
    protected override void OnDeath()
    {
        base.OnDeath();

        SoundManagerSO.PlaySoundFXClip(new SoundData(WitchList.i.death));

        animator.SetTrigger("Die");
        navAgent.speed = 0f;
        StartCoroutine(
            RunUtil.i.DelayAndCallbackCR(RunUtil.AnimFramesToSecs(deathFrames) + 0.9f, () => Destroy(unit.gameObject))
            );
    }
    #endregion
}
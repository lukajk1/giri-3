using System;
using System.Collections.Generic;
using UnityEngine;

public delegate void BuffCompleteDelegate(BuffData buff);
public class Unit : Entity
{
    [SerializeField] public UnitBaseStats BaseStats;
    [SerializeField] public UIHealthbar healthbar;
    [SerializeField] protected UnitController controller;

    [HideInInspector] public bool Attackable = true;
    [HideInInspector] public bool IsDead;

    #region fields for stats
    [HideInInspector] public int currentShield;
    [HideInInspector] public int currentHealth;
    [HideInInspector] public int currentMaxHealth;

    [HideInInspector] public float currentMoveSpeed;

    [HideInInspector] public float currentAttackSpeed;
    [HideInInspector] public float currentAttackRange;
    [HideInInspector] public float currentCritChance;
    [HideInInspector] public int currentDamage;

    [HideInInspector] public float currentCooldownReduction;
    #endregion

    protected List<BuffData> buffList = new();
    public List<UnitState> stateList = new();
    //private List<ItemData> itemList;  -> in the future probably use something like this to calculate items

    public Action OnStatsModified;
    public Action OnStateListModified;
    public Action<CombatData> OnCombatEventInitiated;
    public Action<CombatData> OnCombatEventResolved;
    public Action OnDeath;
    protected virtual void Start()
    {
        SetBaseStats();
        healthbar.Init(this);
        controller.Init(this);
    }

    #region manage buffs
    public virtual void AddBuff(BuffData buff)
    {
        buffList.Add(buff);
        AddStates(buff);
        RefreshStats();
    }

    private void AddStates(BuffData buff)
    {
        foreach (UnitState state in buff.StateEffectsToApply)
        {
            stateList.Add(state);
        }
        OnStateListModified?.Invoke();
    }

    /// <summary>
    /// callback method to remove a buff from the unit's list of active buffs once the duration has expired
    /// </summary>
    /// <param name="buff"></param>
    public void BuffOnComplete(BuffData buff)
    {
        if (buffList.Contains(buff)) // should never be false but you never know
        {
            buffList.Remove(buff);
        }

        RefreshStats();
    }
    #endregion

    #region set stats
    protected void SetBaseStats()
    {
        currentShield = BaseStats.Shield;

        currentHealth = BaseStats.BaseMaxHealth;
        currentMaxHealth = BaseStats.BaseMaxHealth;

        currentMoveSpeed = BaseStats.BaseMoveSpeed;

        currentAttackSpeed = BaseStats.BaseAttackSpeed;
        currentAttackRange = BaseStats.BaseAttackRange;
        currentCritChance = BaseStats.BaseCritChance;
        currentDamage = BaseStats.BaseDamage;

        currentCooldownReduction = BaseStats.BaseCooldownReduction;

        OnStatsModified?.Invoke();
    }
    public void RefreshStats()
    {
        SetBaseStats();

        float moveSpeedMult = 1f;
        float damageMult = 1f;
        float attackSpeedMult = 1f;

        foreach (BuffData buff in buffList)
        {
            currentShield += buff.statMod.ShieldFlat;
            currentMaxHealth += buff.statMod.MaxHealthFlat;

            currentMoveSpeed += buff.statMod.MoveSpeedFlat;

            currentAttackSpeed += buff.statMod.AttackSpeedFlat;
            currentAttackRange += buff.statMod.AttackRangeFlat;
            currentCritChance += buff.statMod.CritChanceFlat;
            currentDamage += buff.statMod.DamageFlat;

            currentCooldownReduction += buff.statMod.CDR;

            // add 1 since 0.4 mult = 40% extra (140%)
            moveSpeedMult *= 1f + buff.statMod.MoveSpeedMult;
            damageMult *= 1f + buff.statMod.DamageMult;
            attackSpeedMult *= 1f + buff.statMod.AttackSpeedMult;
        }

        currentMoveSpeed *= moveSpeedMult;
        currentDamage = Mathf.RoundToInt(currentDamage * damageMult);
        currentAttackSpeed *= attackSpeedMult;

        healthbar.RefreshHealthbar();
        OnStatsModified?.Invoke();
    }
    #endregion

    #region combat methods
    public virtual void Damage(CombatData data)
    {
        OnCombatEventInitiated?.Invoke(data);

        if (data.damage <= 0) return;
        if (stateList.Contains(UnitState.Wraithed) 
            || stateList.Contains(UnitState.Invulnerable)) return;

        currentHealth -= data.damage;

        if (currentHealth <= 0)
        {
            Die();
        }
        else
        {
            OnCombatEventResolved?.Invoke(data);
        }

        CombatEventBus.TriggerCombatResolved(data);
        healthbar.RefreshHealthbar();
    }
    public virtual void Heal(CombatData data)
    {
        if (currentHealth == currentMaxHealth) return;

        int tentative = currentHealth + data.healing;
        if (tentative > currentMaxHealth)
        {
            currentHealth = currentMaxHealth;
        }
        else currentHealth = tentative;

        SoundManagerSO.PlaySoundFXClip(new SoundData(CombatList.i.heal));
        CombatEventBus.TriggerCombatResolved(data);
        healthbar.RefreshHealthbar();
    }

    public virtual void Die()
    {
        if (IsDead) return;

        OnDeath?.Invoke();
        Attackable = false;
        IsDead = true;
        SoundManagerSO.PlaySoundFXClip(new SoundData(CombatList.i.unitDeath));
    }
    #endregion
}

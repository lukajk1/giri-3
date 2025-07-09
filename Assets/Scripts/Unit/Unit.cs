using System;
using System.Collections.Generic;
using UnityEngine;

public delegate void BuffCompleteDelegate(BuffData buff);
public class Unit : Entity
{
    [SerializeField] public UnitBaseStats BaseStats;
    [SerializeField] public UIHealthbar healthbar;
    [SerializeField] protected WitchController controller;

    [HideInInspector] public bool Attackable = true;

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
    //private List<ItemData> itemList;  -> in the future probably use something like this to calculate items

    public Action OnStatsModified;
    public Action<CombatData> OnDamageTaken;
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
        RefreshStats();
    }

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

            currentAttackRange += buff.statMod.AttackRangeFlat;
            currentCritChance += buff.statMod.CritChanceFlat;
            currentDamage += buff.statMod.DamageFlat;

            currentCooldownReduction += buff.statMod.CDR;

            moveSpeedMult *= buff.statMod.MoveSpeedMult;
            damageMult *= buff.statMod.DamageMult;
            attackSpeedMult *= buff.statMod.AttackSpeedMult;
        }

        currentMoveSpeed *= moveSpeedMult;
        currentDamage = Mathf.RoundToInt(currentDamage * damageMult);
        currentAttackSpeed *= attackSpeedMult;

        healthbar.RefreshHealthbar();
        OnStatsModified?.Invoke();
    }
    #endregion

    #region combat methods
    public void Damage(CombatData data)
    {
        if (currentDamage <= 0) return;

        currentHealth -= data.damage;

        if (currentHealth <= 0)
        {
            Die();
        }
        else
        {
            OnDamageTaken?.Invoke(data);
        }

        CombatEventBus.TriggerUnitHealthChange(data);
        healthbar.RefreshHealthbar();
    }
    public void Heal(CombatData data)
    {
        if (currentHealth == currentMaxHealth) return;

        int tentative = currentHealth + data.healing;
        if (tentative > currentMaxHealth)
        {
            currentHealth = currentMaxHealth;
        }
        else currentHealth = tentative;

        SoundManagerSO.PlaySoundFXClip(new SoundData(CombatList.i.heal));
        CombatEventBus.TriggerUnitHealthChange(data);
        healthbar.RefreshHealthbar();
    }

    public void Die()
    {
        OnDeath?.Invoke();
        Attackable = false;
        SoundManagerSO.PlaySoundFXClip(new SoundData(CombatList.i.unitDeath));
    }
    #endregion
}

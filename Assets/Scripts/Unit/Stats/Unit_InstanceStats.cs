using System;
using System.Collections.Generic;
using UnityEngine;

public class Unit_InstanceStats : MonoBehaviour
{
    // events
    public event Action<CCState> OnStatusEffectAdded;
    public event Action<CCState> OnStatusEffectRemoved;

    // refs
    [SerializeField] protected HealthbarChange healthbar;
    private Unit unit;
    protected UnitBaseStats baseStats;

    // stats
    [HideInInspector] public int currentShield;
    [HideInInspector] public int currentHealth;
    [HideInInspector] public int currentMaxHealth;

    [HideInInspector] public float currentMoveSpeed;

    [HideInInspector] public float currentAttackSpeed;
    [HideInInspector] public float currentAttackRange;
    [HideInInspector] public float currentCritChance;
    [HideInInspector] public int currentDamage;

    [HideInInspector] public float currentCooldownReduction;

    public List<CCState> effects;
    public List<StatMod> statMods;
    public virtual void Init(Unit unit)
    {
        this.unit = unit;
        this.baseStats = unit.BaseStats;

        SetBaseStats();
        healthbar.Init(this);
    }

    protected void SetBaseStats()
    {
        currentShield = baseStats.Shield;

        currentHealth = baseStats.BaseMaxHealth;
        currentMaxHealth = baseStats.BaseMaxHealth;

        currentMoveSpeed = baseStats.BaseMoveSpeed;

        currentAttackSpeed = baseStats.BaseAttackSpeed;
        currentAttackRange = baseStats.BaseAttackRange;
        currentCritChance = baseStats.BaseCritChance;
        currentDamage = baseStats.BaseDamage;

        currentCooldownReduction = baseStats.BaseCooldownReduction;
    }

    public void Damage(int damage)
    {
        if (currentDamage <= 0) return;

        currentHealth -= damage;
        healthbar.UpdateBar();
    }
    public void Heal(int heal)
    {
        if (currentHealth == currentMaxHealth) return;

        int tentative = currentHealth + heal;
        if (tentative > currentMaxHealth)
        {
            currentHealth = currentMaxHealth;
        }
        else currentHealth = tentative;

        healthbar.UpdateBar();
    }

    public void AddState()
    {

    }
    public void AddStatMod(StatMod e)
    {
        statMods.Add(e);
        CalculateStats();
    }
    public void CalculateStats()
    {
        SetBaseStats();

        float moveSpeedMult = 1f;
        float damageMult = 1f;

        foreach (var mod in statMods)
        {
            currentShield += mod.BonusShieldFlat;
            currentMaxHealth += mod.BonusMaxHealthFlat;
            currentMoveSpeed += mod.BonusMoveSpeedFlat;
            moveSpeedMult *= mod.BonusMoveSpeedMult;
            currentAttackRange += mod.BonusAttackRangeFlat;
            currentCritChance += mod.BonusCritChanceFlat;
            currentDamage += mod.BonusDamageFlat;
            damageMult *= mod.BonusDamageMult;
            currentCooldownReduction += mod.BonusCDR;
        }

        currentMoveSpeed *= moveSpeedMult;
        currentDamage = Mathf.RoundToInt(currentDamage * damageMult);

        healthbar.UpdateBar();
    }

    public void ApplyEffect(CCState effect)
    {
        effects.Add(effect);
        OnStatusEffectAdded?.Invoke(effect);
    }    
    public void RemoveEffect(CCState effect)
    {
        effects.Remove(effect);
        OnStatusEffectRemoved?.Invoke(effect);
    }


    public void ApplyTimedStatusEffect()
    {

    }
}
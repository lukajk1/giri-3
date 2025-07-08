using System.Collections.Generic;
using UnityEngine;

public delegate void BuffCompleteDelegate(BuffData buff);
public class Unit : Entity
{
    [Header("Stats")]
    [SerializeField] public UnitBaseStats BaseStats;
    [SerializeField] public Unit_InstanceStats InstanceStats;

    public void Damage(DamageData damage)
    {
        InstanceStats.Damage(damage);
    }

    public void Heal(int heal)
    {
        InstanceStats.Heal(heal);
    }
    public virtual void AddBuff(BuffData buff)
    {
        Debug.Log("Buff was added in unit");
        BuffManager.i.AddBuff(buff, BuffOnComplete); // pass oncomplete method as callback
    }

    public void BuffOnComplete(BuffData buff)
    {
        Debug.Log("Buff was completed in unit");
    }
}

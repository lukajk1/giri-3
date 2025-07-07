using System;
using UnityEngine;

public struct DamageData
{
    public bool isCrit;
    public int damage;
    public Vector3 pos;

    public DamageData(int damage, Vector3 pos, bool isCrit = false)
    {
        this.isCrit = isCrit;
        this.damage = damage;
        this.pos = pos;
    }
}

public struct HealData
{

}
public static class CombatEventBus
{
    public static event Action<DamageData> OnUnitHealthChange;

    public static void TriggerUnitHealthChange(DamageData damage)
    {
        OnUnitHealthChange?.Invoke(damage);
    }
}
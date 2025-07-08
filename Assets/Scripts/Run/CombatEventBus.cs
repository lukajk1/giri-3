using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Contains data for combat events, including a buff list. Defined in CombatEventBus.cs
/// </summary>
public struct CombatData
{
    public bool isCrit;
    public int damage;
    public int healing;
    public Vector3 pos;
    public List<BuffData> buffList;

    public CombatData(Vector3 pos, int damage = 0, int healing = 0, bool isCrit = false, List<BuffData> buffList = null)
    {
        this.pos = pos;

        this.damage = damage;
        this.healing = healing;

        this.isCrit = isCrit;
        this.buffList = buffList;
    }
}
public static class CombatEventBus
{
    public static event Action<CombatData> OnUnitHealthChange;

    public static void TriggerUnitHealthChange(CombatData damage)
    {
        OnUnitHealthChange?.Invoke(damage);
    }
}
using UnityEngine;

[System.Serializable]
public class StatMod
{
    [Tooltip("additional unity units / sec")] public float MoveSpeedFlat = 0;
    [Tooltip("multiplicative: 40% extra = 0.4")] public float MoveSpeedMult = 1f;

    public int ShieldFlat = 0;
    public int MaxHealthFlat = 0;

    [Header("Combat")]
    public float AttackRangeFlat = 0;

    [Tooltip("attacks per second")] public float AttackSpeedFlat = 0f;
    public float AttackSpeedMult = 0f;

    public float CritChanceFlat = 0;

    public int DamageFlat = 0;
    public float DamageMult = 0f;

    public float CDR = 0f;
}
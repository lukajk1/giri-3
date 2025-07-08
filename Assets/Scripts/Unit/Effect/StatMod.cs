using UnityEngine;

[System.Serializable]
public class StatMod
{
    public int MoveSpeedFlat = 0;
    public float MoveSpeedMult = 1f;

    public int ShieldFlat = 0;
    public int MaxHealthFlat = 0;

    public float AttackRangeFlat = 0;
    public float AttackSpeedMult = 1f;
    public float CritChanceFlat = 0;

    public int DamageFlat = 0;
    public float DamageMult = 1f;

    public float CDR = 0f;
}
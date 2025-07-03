using UnityEngine;

[CreateAssetMenu(fileName = "NewUnitBaseStats", menuName = "Data/Unit Base Stats")]
public class UnitBaseStats : ScriptableObject
{
    [Header("Mobility")]

    [Tooltip("How long in secs to turn 180 degrees.")]
    public float TurnSpeed = 0.2f;

    [Tooltip("Unity units/s")]
    public float BaseMoveSpeed = 2.5f;

    [Header("Health")]
    public int BaseMaxHealth = 450;
    public int Shield = 0;

    [Header("Attack")]

    [Tooltip("1.5f = 150% speed")]
    public float BaseAttackSpeed = 1f;

    [Tooltip("Unity units")]
    public float BaseAttackRange = 3f;

    [Tooltip("0.05 = 5%, 1 = 100% chance")]
    public float BaseCritChance = 0.05f;
    public int BaseDamage = 50;

    [Header("Utility")]

    [Tooltip("2 = cooldowns refresh 200% as quickly")]
    public float BaseCooldownReduction = 1f;
}

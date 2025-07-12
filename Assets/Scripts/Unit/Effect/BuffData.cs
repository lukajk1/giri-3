using NaughtyAttributes;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Buff", fileName = "NewBuff")]
public class BuffData : ScriptableObject
{
    public string debugName;

    [ShowAssetPreview(40, 40)] public Sprite Icon;
    public GameObject CustomLogic;

    public bool IsIndefinite = false;
    [HideIf("IsIndefinite")] public float Duration = 1f;

    [Header("Stat Bonuses")] public StatMod statMod;
    [Header("States")] public List<UnitState> StateEffectsToApply;
}

// cast effects to spaced out ints directly to avoid mixing up serialized fields when I add more
public enum UnitState
{
    Unseen = 1,
    Exposed = 5, // visible regardless of LOS. possibly drop
    Disarmed = 10, // can't auto attack? 
    Rooted = 15,
    Stunned = 20,
    Wraithed = 25, // disables unit collision, can't be damaged, can't be targeted
    Vulnerable = 30, // takes additional damage
    Invulnerable = 35 // cannot be damaged, can be targeted
}
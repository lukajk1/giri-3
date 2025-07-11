using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Buff", fileName = "NewBuff")]
public class BuffData : ScriptableObject
{
    public string debugName;

    public Sprite Icon;
    public GameObject CustomLogic;

    public bool IsIndefinite = false;
    public float Duration = 1f;

    [Header("Stat Bonuses")] public StatMod statMod;
    [Header("CC")] public List<CCState> ccEffectsToApply;
}

// cast effects to ints directly to avoid mixing up serialized fields when I add more
public enum CCState
{
    Unseen = 1,
    Exposed = 5, // visible regardless of LOS. possibly drop
    Disarmed = 10,
    Rooted = 15,
    Stunned = 20,
    Wraithed = 25 // disables unit collision
}
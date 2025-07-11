using System.Collections.Generic;
using UnityEngine;

public class Eivel_Passive : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private BuffData passiveProc;
    private Dictionary<Unit, int> targetUnitCounts = new Dictionary<Unit, int>();
    private void Awake()
    {
        CombatEventBus.OnCombatDataResolved += OnCombatDataResolved;
    }

    private void OnCombatDataResolved(CombatData data)
    {
        Unit target = data.targetUnit;

        if (targetUnitCounts.ContainsKey(target))
        {
            targetUnitCounts[target]++;
        }
        else
        {
            targetUnitCounts[target] = 1;
        }

        if (targetUnitCounts[target] == 3)
        {
            Debug.Log("passive proceed"); 
            targetUnitCounts[target] = 0;
            player.AddBuff(passiveProc);
        }
    }
}
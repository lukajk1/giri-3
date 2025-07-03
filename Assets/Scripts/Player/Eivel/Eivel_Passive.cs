using UnityEngine;

public class Eivel_Passive : MonoBehaviour
{
    // hm.. what's the best way.. subscribe to an event that triggers when a new status effect is added? Maybe status effects could be an interface.. Then call OnApply() and OnComplete() is easy enough.. Some sort of lookup is going to be neccesary though. You just can't tie arbitrary code to assets? 
    private Unit_InstanceStats stats;
    private void Init(Player player)
    {
        this.stats = player.InstanceStats;
        player.InstanceStats.OnStatusEffectRemoved += CheckRemoved;
        player.InstanceStats.OnStatusEffectAdded += CheckAdded;

    }

    private void OnDisable()
    {

    }

    private void CheckRemoved(CCState effect)
    {
        //if (effect._effect == CCState.State.Unseen)
        //{
        //    StatMod e = new StatMod
        //    {
        //        BonusAttackSpeedMult = 1.3f
        //    };

        //    stats.AddStatMod(e);
        //}
    }

    private void CheckAdded(CCState effect)
    {
        //if (effect._effect == CCState.State.Unseen)
        //{
        //    StatMod e = new StatMod
        //    {
        //        BonusDamageMult = 1.2f
        //    };

        //    stats.AddStatMod(e);
        //}
    }
}
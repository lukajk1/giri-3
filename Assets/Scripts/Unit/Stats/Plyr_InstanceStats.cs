using UnityEngine;

public class Plyr_InstanceStats : Unit_InstanceStats
{
    private Player player;

    public void Init(Player player) // overload, init takes type player here
    {
        this.player = player;
        this.baseStats = player.BaseStats;

        SetBaseStats();
        healthbar.Init(this);
    }
}
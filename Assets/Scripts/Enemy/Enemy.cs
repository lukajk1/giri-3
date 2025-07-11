using UnityEngine;

public abstract class Enemy : Unit
{
    public override void Damage(CombatData data)
    {
        base.Damage(data);

        SoundManagerSO.PlaySoundFXClip(new SoundData(EnemyList.i.enemyTakeDamage));
    }
}
using UnityEngine;

public class Eivel_R : AbilityImplementation
{
    public override void TryActivate()
    {
        if (UIAbility.CooldownUp())
        {
            player.Damage(new DamageData(54, transform.position));
            UIAbility.Activate(BaseCooldown);
        }
        else
        {
            CooldownNotUpSound();
        }
    }
}
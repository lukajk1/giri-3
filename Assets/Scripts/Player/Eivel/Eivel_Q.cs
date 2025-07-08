using UnityEngine;

public class Eivel_Q : AbilityImplementation
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
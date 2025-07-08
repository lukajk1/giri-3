using UnityEngine;

public class Eivel_R : AbilityImplementation
{
    public override void TryActivate()
    {
        if (UIAbility.CooldownUp())
        {
            UIAbility.Activate(BaseCooldown);
        }
        else
        {
            CooldownNotUpSound();
        }
    }
}
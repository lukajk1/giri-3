using UnityEngine;

public class Eivel_E : AbilityImplementation
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
using UnityEngine;

public class Eivel_Q : AbilityImplementation
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
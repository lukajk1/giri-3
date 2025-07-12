using UnityEngine;

public class Eivel_Q : AbilityImplementation
{
    [SerializeField] private BuffData qBuff;
    public override void TryActivate()
    {
        if (UIAbility.CooldownUp())
        {
            player.AddBuff(qBuff);
            UIAbility.Activate(BaseCooldown);
        }
        else
        {
            CooldownNotUp();
        }
    }
}
using UnityEngine;

public class Eivel_R : AbilityImplementation
{
    [SerializeField] private BuffData rBuff;
    public override void TryActivate()
    {
        if (UIAbility.CooldownUp())
        {
            player.AddBuff(rBuff);
            UIAbility.Activate(BaseCooldown);
        }
        else
        {
            CooldownNotUp();
        }
    }
}
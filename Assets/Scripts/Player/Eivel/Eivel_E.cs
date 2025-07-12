using UnityEngine;

public class Eivel_E : AbilityImplementation
{
    [SerializeField] private BuffData eBuff;
    public override void TryActivate()
    {
        if (UIAbility.CooldownUp())
        {
            player.AddBuff(eBuff);
            UIAbility.Activate(BaseCooldown);
        }
        else
        {
            CooldownNotUp();
        }
    }
}
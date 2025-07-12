using UnityEngine;

public class Eivel_W : AbilityImplementation
{
    [SerializeField] BuffData wDebuff;
    public override void TryActivate()
    {
        if (UIAbility.CooldownUp())
        {
            if (RunUtil.GetSelectedUnit(out Unit unit))
            {
                if (unit is Enemy)
                {
                    unit.AddBuff(wDebuff);
                    Debug.Log("wow it actually worked");
                }
            }
            UIAbility.Activate(BaseCooldown);
        }
        else
        {
            CooldownNotUp();
        }
    }
}
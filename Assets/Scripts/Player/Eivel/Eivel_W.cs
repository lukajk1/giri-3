using UnityEngine;

public class Eivel_W : AbilityImplementation
{
    [SerializeField] private float cooldown;
    public override float Cooldown
    {
        get => cooldown;
        protected set => cooldown = value;
    }
    public override bool Activate()
    {
        player.Damage(new DamageData(54, transform.position));
        return true;
    }
}
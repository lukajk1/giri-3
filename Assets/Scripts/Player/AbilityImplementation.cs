using UnityEngine;
using UnityEngine.UI;

public abstract class AbilityImplementation : MonoBehaviour
{
    [SerializeField] public Sprite abilityIcon;
    [SerializeField] protected float baseCooldown = 1f;
    public float BaseCooldown
    {
        get => baseCooldown;
        protected set => baseCooldown = value;
    }
    protected Player player;
    protected AbilityIcon UIAbility;

    public void Init(Player player, AbilityIcon UIAbility)
    {
        this.player = player;
        this.UIAbility = UIAbility;
    }
    public abstract void TryActivate();
    protected virtual void CooldownNotUpSound()
    {
        SoundManagerSO.PlaySoundFXClip(new SoundData(UIList.i.cooldownNotUp, varyPitch: false, varyVolume: false));
    }
}
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.UI;

public abstract class AbilityImplementation : MonoBehaviour
{
    [ShowAssetPreview(40, 40)]
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
    protected virtual void CooldownNotUp()
    {
        RunErrorNotice.i.CreateMessage("cooldown not ready!");
        SoundManagerSO.PlaySoundFXClip(new SoundData(UIList.i.cooldownNotUp, varyPitch: false, varyVolume: false));
    }
}
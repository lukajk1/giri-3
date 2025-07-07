using UnityEngine;

public abstract class AbilityImplementation : MonoBehaviour
{
    protected Player player;
    public abstract float Cooldown { get; protected set; }
    public abstract bool Activate();
    public void Init (Player player)
    {
        this.player = player;
    }
}
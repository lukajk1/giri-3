using UnityEngine;

public class Plyr_Abilities : MonoBehaviour
{
    [SerializeField] AbilityIcon Q_Icon;
    [SerializeField] AbilityIcon W_Icon;
    [SerializeField] AbilityIcon E_Icon;
    [SerializeField] AbilityIcon R_Icon;

    [SerializeField] AbilityImplementation W_Spell;
    public void Init(Player player)
    {
        W_Spell.Init(player);   
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (W_Icon.CooldownUp())
            {
                W_Spell.Activate();
                W_Icon.Activate(W_Spell.Cooldown);
            }
            else CooldownNotUp();
        }
    }

    private void CooldownNotUp()
    {
        // play error noise
    }
}
using UnityEngine;

public class PlyrAbilities : MonoBehaviour
{
    [SerializeField] AbilityImplementation Q_Spell;
    [SerializeField] AbilityImplementation W_Spell;
    [SerializeField] AbilityImplementation E_Spell;
    [SerializeField] AbilityImplementation R_Spell;
    public void Init(Player player)
    {
        UIAbilities ui = UIAbilities.i;
        Q_Spell.Init(player, ui.Q_Icon);   
        W_Spell.Init(player, ui.W_Icon);   
        E_Spell.Init(player, ui.E_Icon);   
        R_Spell.Init(player, ui.R_Icon);

        ui.Q_Icon.Init(Q_Spell.abilityIcon, "Q");
        ui.W_Icon.Init(W_Spell.abilityIcon, "W");
        ui.E_Icon.Init(E_Spell.abilityIcon, "E");
        ui.R_Icon.Init(R_Spell.abilityIcon, "R");
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Q_Spell.TryActivate();
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            W_Spell.TryActivate();
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            E_Spell.TryActivate();
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            R_Spell.TryActivate();
        }
    }

}
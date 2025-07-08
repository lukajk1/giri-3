using UnityEngine;

public class Plyr_Abilities : MonoBehaviour
{
    [SerializeField] AbilityIcon Q_Icon;
    [SerializeField] AbilityIcon W_Icon;
    [SerializeField] AbilityIcon E_Icon;
    [SerializeField] AbilityIcon R_Icon;

    [SerializeField] AbilityImplementation Q_Spell;
    [SerializeField] AbilityImplementation W_Spell;
    [SerializeField] AbilityImplementation E_Spell;
    [SerializeField] AbilityImplementation R_Spell;
    public void Init(Player player)
    {
        Q_Spell.Init(player, Q_Icon);   
        W_Spell.Init(player, W_Icon);   
        E_Spell.Init(player, E_Icon);   
        R_Spell.Init(player, R_Icon);

        Q_Icon.Init(Q_Spell.abilityIcon, "Q");
        W_Icon.Init(W_Spell.abilityIcon, "W");
        E_Icon.Init(E_Spell.abilityIcon, "E");
        R_Icon.Init(R_Spell.abilityIcon, "R");
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
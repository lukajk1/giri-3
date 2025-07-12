using UnityEngine;

public class UIAbilities : MonoBehaviour
{
    [SerializeField] public AbilityIcon PassiveIcon;
    [SerializeField] public AbilityIcon Q_Icon;
    [SerializeField] public AbilityIcon W_Icon;
    [SerializeField] public AbilityIcon E_Icon;
    [SerializeField] public AbilityIcon R_Icon;

    public static UIAbilities i;
    private void Awake()
    {
        i = this;
    }
}

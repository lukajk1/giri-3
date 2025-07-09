using UnityEngine;

public class CombatList : MonoBehaviour
{

    [SerializeField] public AudioClip heal;
    [SerializeField] public AudioClip unitDeath;

    #region singleton pattern
    public static CombatList i;
    void Awake()
    {
        if (i == null) i = this; // no need to handle destruction since parent game manager does
    }
    #endregion
}
using UnityEngine;

public class EivelList : MonoBehaviour
{

    [SerializeField] public AudioClip basicAttack_1;
    [SerializeField] public AudioClip basicAttackHit_1;

    #region singleton pattern
    public static EivelList i;
    void Awake()
    {
        if (i == null) i = this; // no need to handle destruction since parent game manager does
    }
    #endregion
}
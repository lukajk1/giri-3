using UnityEngine;

public class WitchList : MonoBehaviour
{

    [SerializeField] public AudioClip magicCast;
    [SerializeField] public AudioClip magicPop;
    [SerializeField] public AudioClip death;

    #region singleton pattern
    public static WitchList i;
    void Awake()
    {
        if (i == null) i = this; // no need to handle destruction since parent game manager does
    }
    #endregion
}
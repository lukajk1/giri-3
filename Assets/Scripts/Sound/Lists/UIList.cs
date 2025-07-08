using UnityEngine;

public class UIList : MonoBehaviour
{

    [SerializeField] public AudioClip cooldownNotUp;

    #region singleton pattern
    public static UIList i;
    void Awake()
    {
        if (i == null) i = this; // no need to handle destruction since parent game manager does
    }
    #endregion
}
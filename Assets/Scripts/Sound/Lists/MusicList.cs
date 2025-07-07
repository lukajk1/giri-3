using UnityEngine;

public class MusicList : MonoBehaviour
{

    [SerializeField] public AudioClip mainMenu;
    [SerializeField] public AudioClip game_1;

    #region singleton pattern
    public static MusicList i;
    void Awake()
    {
        if (i == null) i = this; // no need to handle destruction since parent game manager does
    }
    #endregion
}
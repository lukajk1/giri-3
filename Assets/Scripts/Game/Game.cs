using UnityEngine;


/// <summary>
/// The most general manager. All data that persists throughout runs (settings) runs through here.
/// </summary>
public class Game : MonoBehaviour
{
    public static Game i;
    private void Awake()
    {
        if (i == null) i = this;
        else
        {
            Debug.LogError($"multiple {this} singletons found. (destroying extra)");
            Destroy(this);
        }
    }
}
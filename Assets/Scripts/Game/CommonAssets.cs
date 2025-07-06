using UnityEngine;

public class CommonAssets : MonoBehaviour
{
    public Material OutlineShader;
    public Player Player;

    // add things here.. 

    public static CommonAssets i;
    private void Awake()
    {
        if (i == null) i = this;
        else
        {
            Debug.LogError($"multiple {this} singletons found. (destroying extra)");
            Destroy(gameObject);
        }

        if (OutlineShader == null || 
            Player == null
            )
        {
            Debug.LogWarning("nullreference in commonassets");
        }
    }
}

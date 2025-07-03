using UnityEngine;


public class CustomCursor : MonoBehaviour
{
    public Texture2D cursorTexture;
    void Awake()
    {
        Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.ForceSoftware);
    }
}

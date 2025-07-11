using UnityEngine;

public class LowRes : MonoBehaviour
{
    [SerializeField] private RenderTexture renderTexture;
    public static LowRes i;

    private void Awake()
    {
        i = this;
    }
    private void Start()
    {
        #if UNITY_EDITOR
            SetLowRes(false);
        #else
        #endif

    }

    public void SetLowRes(bool value)
    {
        if (value)
        {
            Camera.main.targetTexture = renderTexture;
        }
        else
        {
            Camera.main.targetTexture = null;
        }
    }
}
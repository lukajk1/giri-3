using UnityEngine;

public class LowRes : MonoBehaviour
{
    [SerializeField] private RenderTexture renderTexture;
    [SerializeField] private bool enable;
    private void Start()
    {
        SetLowRes(enable);
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
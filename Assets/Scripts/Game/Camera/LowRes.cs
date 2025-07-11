using MoreMountains.Tools;
using UnityEngine;

public class LowRes : MonoBehaviour
{
    [SerializeField] private RenderTexture renderTexture;
    [SerializeField] private GameObject lowResCanvas;

    public static LowRes i;

    private void Awake()
    {
        if (i == null) i = this;
    }

    private void OnDestroy()
    {
        i = null;
    }

    private void Start()
    {
        #if UNITY_EDITOR
            SetLowRes(false);
        #else
            SetLowRes(Game.PixellateOn);
        #endif
    }

    public void SetLowRes(bool value)
    {
        Debug.Log("set res to " + value);
        if (value)
        {
            Camera.main.targetTexture = renderTexture;
            lowResCanvas.SetActive(true);
        }
        else
        {
            Camera.main.targetTexture = null;
            lowResCanvas.SetActive(false);
        }
    }
}
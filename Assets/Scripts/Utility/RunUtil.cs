using System;
using System.Collections;
using UnityEngine;

public class RunUtil : MonoBehaviour
{
    public static RunUtil i;
    public static Vector2 ScreenDownscaleSize = new Vector2(1280f, 720f);
    //public static Vector2 ScreenDownscaleSize = new Vector2(1024f, 576f);

    public const float AnimationFPS = 24f;

    public LayerMask groundLayer;

    private void Awake()
    {
        if (i == null) i = this;
        else
        {
            Debug.LogError($"multiple {this} singletons found. (destroying extra)");
            Destroy(gameObject);
        }
    }

    public IEnumerator DelayAndCallbackCR(float duration, Action OnComplete)
    {
        float elapsed = 0f;
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            yield return null;
        }

        OnComplete?.Invoke();
    }
    public IEnumerator TimerCR(float duration)
    {
        float elapsed = 0f;
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            yield return null;
        }
    }
    public static float AnimFramesToSecs(float animLength)
    {
        return animLength / AnimationFPS;
    }

    public static bool CursorToWorldPos(out Vector3 worldPos)
    {
        float scaleX = ScreenDownscaleSize.x / Screen.width;
        float scaleY = ScreenDownscaleSize.y / Screen.height;

        Vector3 scaledMousePos = new Vector3(
            Input.mousePosition.x * scaleX,
            Input.mousePosition.y * scaleY,
            0f
        );

        Ray ray = Camera.main.ScreenPointToRay(scaledMousePos);
        RaycastHit hit;

        int layerMask = 1 << 6;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
        {
            worldPos = hit.point;
            return true;
        }
        else
        {
            worldPos = Vector3.zero;
            return false;
        }
    }
}
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
        Vector3 mousePos = Input.mousePosition;
        mousePos = NormalizeCursorPos(mousePos);

        Ray ray = Camera.main.ScreenPointToRay(mousePos);
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
    public static bool GetSelectedUnit(out Unit unit)
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos = NormalizeCursorPos(mousePos);

        Ray ray = Camera.main.ScreenPointToRay(mousePos);
        RaycastHit hit;
        Collider collider;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            collider = hit.collider;
            unit = collider.GetComponent<Unit>();

            if (unit != null) return true; 
            else return false;
        }
        else
        {
            collider = null;
            unit = null;
            return false;
        }
    }

    private static Vector3 NormalizeCursorPos(Vector3 mousePos)
    {
        if (Game.PixellateOn)
        {
            float scaleX = ScreenDownscaleSize.x / Screen.width;
            float scaleY = ScreenDownscaleSize.y / Screen.height;

            return new Vector3(
                mousePos.x * scaleX,
                mousePos.y * scaleY,
                0f
            );
        }
        else
        {
            return mousePos;
        }
    }

}
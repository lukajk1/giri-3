using UnityEngine;

public static class Easings
{
    public static float EaseCubic(float x)
    {
        return 1f - Mathf.Pow(1f - x, 3f);
    }
} 
using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

public static class Run
{
    private static float _timeScale = 1f;
    public static float TimeScale
    {
        get => _timeScale;
        private set
        {
            if (_timeScale != value)
            {
                _timeScale = value;
                Time.timeScale = value;
            }
        }
    }

    private static float timeScaleValue = 1f;

    private static List<Menu> OpenMenus = new();
    public static void ChangeMenuCount(bool isAddition, Menu menu)
    {
        if (isAddition)
        {
            OpenMenus.Add(menu);
        }
        else
        {
            if (OpenMenus.Contains(menu))
            {
                OpenMenus.Remove(menu);
            } 
        }

        if (OpenMenus.Count > 0) SetPause(true);
        else SetPause(false);
    }

    private static void SetPause(bool value)
    {
        if (value)
        {
            timeScaleValue = TimeScale;
            TimeScale = 0;
        }
        else
        {
            TimeScale = timeScaleValue;
        }

    }
}

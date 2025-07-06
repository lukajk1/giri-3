using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// The most general manager for a specific "run".
/// </summary>
public class Run : MonoBehaviour
{
    #region properties
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

    private static float timeScaleBuffer = 1f;
    #endregion

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
            timeScaleBuffer = TimeScale;
            TimeScale = 0;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            TimeScale = timeScaleBuffer;
            Cursor.lockState = CursorLockMode.Confined;
        }

    }

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }
}

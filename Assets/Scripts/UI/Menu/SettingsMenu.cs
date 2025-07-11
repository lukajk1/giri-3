using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using TMPro;

public class SettingsMenu : Menu
{
    [SerializeField] private GameObject settingsMenu;
    [SerializeField] private Button saveAndClose;

    [SerializeField] private Slider sliderMaster;
    [SerializeField] private Slider sliderSFX;
    [SerializeField] private Slider sliderMusic;

    [SerializeField] private TMP_Dropdown windowType;
    [SerializeField] private TMP_Dropdown resolution;

    [SerializeField] private Toggle enableVSync;
    [SerializeField] private Toggle enablePixellate;


    public static SettingsMenu i;

    void Awake()
    {
        if (i == null) i = this;

        saveAndClose.onClick.AddListener(SaveAndClose);

        sliderMaster.onValueChanged.AddListener(MasterChanged);
        sliderSFX.onValueChanged.AddListener(SFXChanged);
        sliderMusic.onValueChanged.AddListener(MusicChanged);

        windowType.onValueChanged.AddListener(WindowTypeChanged);
        resolution.onValueChanged.AddListener(ResolutionChanged);

        enableVSync.onValueChanged.AddListener(VSyncChanged);
        enablePixellate.onValueChanged.AddListener(PixellateChanged);
    }

    private void Start()
    {
        settingsMenu.SetActive(false);
    }

    public void Open()
    {
        settingsMenu.SetActive(true);
    }


    #region UI events

    private void MasterChanged(float value)
    {
        SoundMixerManager.i.SetMasterVolume(value);
    }
    private void SFXChanged(float value)
    {
        SoundMixerManager.i.SetSFXVolume(value);
    }
    private void MusicChanged(float value)
    {
        SoundMixerManager.i.SetMusicVolume(value);
    }

    private void WindowTypeChanged(int index)
    {
        FullScreenMode mode;

        switch(index)
        {
            case 0:
                mode = FullScreenMode.ExclusiveFullScreen;
                break;
            case 1: 
                mode = FullScreenMode.FullScreenWindow;
                break;
            case 2:
                mode = FullScreenMode.MaximizedWindow;
                break;
            case 3:
                mode = FullScreenMode.Windowed;
                break;
            default:
                mode = FullScreenMode.Windowed;
                break;
        }

        Screen.fullScreenMode = mode;   
    }
    private void ResolutionChanged(int index)
    {
        (int width, int height) res;

        switch (index)
        {
            case 0:
                res = (2560, 1440);
                break;
            case 1:
                res = (1920, 1080);
                break;
            case 2:
                res = (1600, 900);
                break;
            case 3:
                res = (1280, 720);
                break;
            default:
                res = (1600, 900);
                break;
        }

        Screen.SetResolution(res.width, res.height, Screen.fullScreenMode);

    }
    private void VSyncChanged(bool value)
    {
        QualitySettings.vSyncCount = value ? 1 : 0;
    }
    private void PixellateChanged(bool value)
    {
        Game.PixellateOn = value;
        if (LowRes.i != null) LowRes.i.SetLowRes(value);
    }

    private void SaveAndClose()
    {
        SaveSystem.Save();
        settingsMenu.SetActive(false);
    }
    #endregion

    #region Save, load
    public void Save(ref GameSettings data)
    {
        data = new GameSettings
        {
            MasterVolume = sliderMaster.value,
            SoundFxVolume = sliderSFX.value,
            MusicVolume = sliderMusic.value,

            WindowType = windowType.value,
            Resolution = resolution.value,
            VSync = enableVSync.isOn,
            Pixellate = enablePixellate.isOn
        };
    }

    public void Load(GameSettings data)
    {
        sliderMaster.value = data.MasterVolume;
        sliderSFX.value = data.SoundFxVolume;
        sliderMusic.value = data.MusicVolume;

        windowType.value = data.WindowType;
        resolution.value = data.Resolution;
        enableVSync.isOn = data.VSync;
        enablePixellate.isOn = data.Pixellate;
    }
}

/// <summary>
/// Class, defined in SettingsMenu.cs
/// </summary>

[System.Serializable]
public class GameSettings
{
    // 0 to 1
    public float MasterVolume;
    public float SoundFxVolume;
    public float MusicVolume;

    public bool VSync;
    public bool Pixellate;

    // int type to use indices, just a bit easier
    public int WindowType;
    public int Resolution;

    // constructor with default values
    public GameSettings()
    {
        MasterVolume = 0.5f;
        SoundFxVolume = 0.5f;
        MusicVolume = 0.5f;

        VSync = false;
        Pixellate = true;
        WindowType = 3;
        Resolution = 2;
    }
}
#endregion
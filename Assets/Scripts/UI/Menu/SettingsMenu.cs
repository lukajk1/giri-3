using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class SettingsMenu : Menu
{
    [SerializeField] private Button saveAndClose;

    [SerializeField] private Slider sliderMaster;
    [SerializeField] private Slider sliderSFX;
    [SerializeField] private Slider sliderMusic;

    [SerializeField] private GameObject settingsMenu;

    public static SettingsMenu i;

    void Awake()
    {
        if (i == null) i = this;

        saveAndClose.onClick.AddListener(SaveAndClose);

        sliderMaster.onValueChanged.AddListener(MasterChanged);
        sliderSFX.onValueChanged.AddListener(SFXChanged);
        sliderMusic.onValueChanged.AddListener(MusicChanged);
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
            MusicVolume = sliderMusic.value
        };
    }

    public void Load(GameSettings data)
    {
        sliderMaster.value = data.MasterVolume;
        sliderSFX.value = data.SoundFxVolume;
        sliderMusic.value = data.MusicVolume;
    }
}


[System.Serializable]
public class GameSettings
{
    // 0 to 1
    public float MasterVolume;
    public float SoundFxVolume;
    public float MusicVolume;

    // that's all I need for the moment? 
    // guess I would have custom binds in here at some point. And every other setting obviously

    public GameSettings()
    {
        MasterVolume = 0.5f;
        SoundFxVolume = 0.5f;
        MusicVolume = 0.5f;
    }
}
#endregion
using UnityEngine;
using UnityEngine.Audio;

public class SoundMixerManager : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;

    #region singleton pattern
    public static SoundMixerManager i;

    private void Awake()
    {
        if (i == null) i = this;
    }
    #endregion
    public void SetMasterVolume(float volume)
    {
        if (volume <= 0.02f) audioMixer.SetFloat("MasterVol", -80f); // attenuation is weird. -80 should be effectively muted
        else audioMixer.SetFloat("MasterVol", Mathf.Log10(volume) * 20f);
    }
    public void SetSFXVolume(float volume)
    {
        if (volume <= 0.02f) audioMixer.SetFloat("SoundFXVol", -80f);
        else audioMixer.SetFloat("SoundFXVol", Mathf.Log10(volume) * 20f);
    }
    public void SetMusicVolume(float volume)
    {
        if (volume <= 0.02f)  audioMixer.SetFloat("MusicVol", -80f);
        else audioMixer.SetFloat("MusicVol", Mathf.Log10(volume) * 20f);
    }
}

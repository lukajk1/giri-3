using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AVEffectsHandler : MonoBehaviour
{
    
    private AVEffectsHandler effectsHandler;
    public static AVEffectsHandler instance;
    private AudioSource[] fxArray; 
    private AudioSource[] musicArray; 
    private Dictionary<AudioSource, float> baseVolumes;
    private Music music;
    
    private void Awake() {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start(){
        fxArray = transform.Find("FX").GetComponents<AudioSource>(); 
        musicArray = transform.Find("Music").GetComponents<AudioSource>(); 

        baseVolumes = new Dictionary<AudioSource, float>();

        foreach (AudioSource item in musicArray) {
            baseVolumes.Add(item, item.volume);
        }
        foreach (AudioSource item in fxArray) {
            baseVolumes.Add(item, item.volume);
        }

        music = transform.Find("Music").GetComponent<Music>();

        music.song.Play();
    }

    public void UpdateSoundLevel(bool isMusic, float sliderValue) {
        foreach (AudioSource item in isMusic ? musicArray : fxArray) {
            item.volume = baseVolumes[item] * sliderValue;
        }
    }

    public void Fade(bool isFadeIn, float duration, int scene = -1) {
        StartCoroutine(FadeRoutine(isFadeIn, duration, scene));
    }
    public IEnumerator FadeRoutine(bool isFadeIn, float delayTime, int scene = -1)
    {
        float elapsedTime = 0f;

        while (elapsedTime < delayTime)
        {
            elapsedTime += Time.deltaTime;
            float progress = elapsedTime / delayTime;
            float transparency = isFadeIn ? 1 - progress : progress;
            float volume = isFadeIn ? progress : 1 - progress;
            AudioListener.volume = volume;
            yield return null;
        }
        AudioListener.volume = 1;
    }

}

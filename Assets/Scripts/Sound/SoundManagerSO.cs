using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu(menuName = "Audio/Sound Manager", fileName = "Sound Manager")]
public class SoundManagerSO : ScriptableObject
{
    private static SoundManagerSO _i;
    public static SoundManagerSO i
    {
        get
        {
            if (_i == null)
            {
                _i = Resources.Load<SoundManagerSO>("Sound Manager");
                if (_i == null) Debug.LogError("not found");
            }

            return _i;
        }
    }

    public AudioSource SoundObject;

    // prevent sounds from being too similar in playback
    private static float volumeVariance = 0.15f;
    private static float pitchVariance = 0.1f;


    public static void PlaySoundFXClip(SoundData sound)
    {
        if (sound.clip == null) {
            Debug.LogError("soundclip was null!");
            return;
        }

        float randVolume = Random.Range(sound.volume - volumeVariance, sound.volume + volumeVariance);
        float randPitch = Random.Range(1 - pitchVariance, 1 + pitchVariance);

        AudioSource a = Instantiate(i.SoundObject, sound.soundPos, Quaternion.identity);

        if (sound.type == SoundType.Spatial)
        {
            a.spatialBlend = 1f;
            a.minDistance = sound.minDist;
            a.maxDistance = sound.maxDist;
        }
        else
        {
            a.spatialBlend = 0f; // ensure non-spatial if requested
        }

        a.clip = sound.clip;
        a.volume = randVolume;
        a.pitch = randPitch * Run.TimeScale;
        a.loop = sound.isLooping;
        a.Play();
    }

}
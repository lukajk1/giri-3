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
    public AudioMixerGroup SoundFXMixer;
    public AudioMixerGroup MusicMixer;

    // prevent sounds from being too similar in playback
    private static float volumeVariance = 0.15f;
    private static float pitchVariance = 0.1f;


    public static void PlaySoundFXClip(SoundData sound)
    {
        if (sound.clip == null) {
            Debug.LogError("soundclip was null!");
            return;
        }

        if (sound.isMusic)
        {
            Game.i.PlayMusic(sound.clip);
            return;
        }

        AudioSource audioSource = Instantiate(i.SoundObject, sound.soundPos, Quaternion.identity);

        if (sound.varyVolume)
        {
            float randVolume = Random.Range(sound.volume - volumeVariance, sound.volume + volumeVariance);
            audioSource.volume = randVolume;   
        }

        if (sound.varyPitch)
        {
            float randPitch = Random.Range(1 - pitchVariance, 1 + pitchVariance);
            audioSource.pitch = randPitch;
        }

        audioSource.pitch *= Run.TimeScale;

        if (sound.type == SoundType.Spatial)
        {
            audioSource.spatialBlend = 1f;
            audioSource.minDistance = sound.minDist;
            audioSource.maxDistance = sound.maxDist;
        }
        else
        {
            audioSource.spatialBlend = 0f;
        }
        audioSource.outputAudioMixerGroup = i.SoundFXMixer;
        audioSource.clip = sound.clip;
        audioSource.loop = sound.isLooping;
        audioSource.Play();
    }

}
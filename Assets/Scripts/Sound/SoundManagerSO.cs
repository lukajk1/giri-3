using UnityEngine;

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


    public static void PlaySoundFXClip(AudioClip clip, Vector3 soundPos, float volume)
    {
        float randVolume = Random.Range(volume - volumeVariance, volume + volumeVariance);
        float randPitch = Random.Range(1 - pitchVariance, 1 + pitchVariance);

        AudioSource a = Instantiate(i.SoundObject, soundPos, Quaternion.identity);

        a.clip = clip;
        a.volume = randVolume;
        a.pitch = randPitch;
        a.Play();
    }
}
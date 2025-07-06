using UnityEngine;

public enum SoundType
{
    Spatial,
    NonSpatial
}

public struct SoundData
{
    public AudioClip clip;
    public Vector3 soundPos;
    public float volume;
    public SoundType type;

    public float minDist;
    public float maxDist;
    public bool isLooping;

    public SoundData(
        AudioClip clip,
        Vector3 soundPos,
        float volume,
        SoundType type = SoundType.Spatial,
        float minDist = 0f,
        float maxDist = 0f,
        bool isLooping = false)
    {
        this.clip = clip;
        this.soundPos = soundPos;
        this.volume = volume;
        this.type = type;
        this.minDist = minDist;
        this.maxDist = maxDist;
        this.isLooping = isLooping;
    }
}

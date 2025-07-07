using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public struct AudioData
{
    public string ClipName;
    public AudioClip Clip;
}
public class TestSerializeableAudio : MonoBehaviour
{
    public List<AudioData> data;
    public Dictionary<string, int> dictData;    
}

[CreateAssetMenu(menuName = "Audio/AudioDataThing", fileName = "NewThing")]
public class AudioSO : ScriptableObject
{
    public List<AudioData> data;

}

using UnityEngine;

public class SoundTest : MonoBehaviour
{
    public AudioClip clip;

    private void Start()
    {
        SoundData d = new SoundData(MusicList.i.mainMenu, Vector3.zero, 1f, SoundType.NonSpatial);

        SoundManagerSO.PlaySoundFXClip(d);

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            SoundData d = new SoundData(clip, Vector3.zero, 1f, SoundType.NonSpatial);

            SoundManagerSO.PlaySoundFXClip(d);
        }

    }
}

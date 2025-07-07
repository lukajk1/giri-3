using UnityEngine;

public class SoundTest : MonoBehaviour
{
    public AudioClip clip;

    private void Start()
    {
        SoundData d = new()
        {
            clip = MusicList.i.mainMenu,
            type = SoundType.NonSpatial,
            isMusic = true,
            varyPitch = false,
            varyVolume = false
        };

        SoundManagerSO.PlaySoundFXClip(d);

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            SoundData d = new()
            {
                clip = this.clip,
                type = SoundType.NonSpatial,
            };

            SoundManagerSO.PlaySoundFXClip(d);
        }

    }
}

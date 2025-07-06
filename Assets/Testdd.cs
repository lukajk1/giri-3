using UnityEngine;

public class Testdd : MonoBehaviour
{
    public AudioClip clip;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            SoundManagerSO.PlaySoundFXClip(clip, Vector3.zero, 1f);
        }

    }
}

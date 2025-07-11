using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEditor;

public class MagickCircle : MonoBehaviour
{
    [SerializeField] private List<MeshRenderer> renderers;
    [SerializeField] private float duration;
    [SerializeField] private Transform innerCircle;

    [Header("hitbox")]
    [SerializeField] private LinearGrow linearGrow;
    [SerializeField] private float hitboxWindup;


    private Vector3 innerCircleOGScale;

    private void Start()
    {
        foreach (var renderer in renderers)
        {
            renderer.material.SetFloat("_Dissolve", 0f);
        }

        innerCircleOGScale = innerCircle.localScale;

        StartCoroutine(DissolveCR());

    }

    private IEnumerator DissolveCR()
    {
        float elapsed = 0f;
        float progress = 0f; 
        SoundManagerSO.PlaySoundFXClip(new SoundData(WitchList.i.magicCast));

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            progress = elapsed / duration;

            foreach (var renderer in renderers)
            {
                renderer.material.SetFloat("_Dissolve", progress);
            }

            innerCircle.localScale = innerCircleOGScale * Easings.EaseCubic(progress);

            yield return null;
        }

        SoundManagerSO.PlaySoundFXClip(new SoundData(WitchList.i.magicPop));
        linearGrow.Init(hitboxWindup);
        StartCoroutine(RunUtil.i.DelayAndCallbackCR(1.5f, () => Destroy(gameObject)));
    }
}

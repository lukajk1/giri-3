using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEditor;

public class MagicCircle : MonoBehaviour
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

        linearGrow.Init(hitboxWindup);
    }
}

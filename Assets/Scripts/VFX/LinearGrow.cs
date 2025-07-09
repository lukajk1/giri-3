using System.Collections;
using UnityEngine;

public class LinearGrow : MonoBehaviour
{
    private Vector3 ogScale;

    private void Awake()
    {

        ogScale = transform.localScale;
        transform.localScale = Vector3.zero;
    }
    public void Init(float duration)
    {
        StartCoroutine(GrowCR(duration));
    }

    private IEnumerator GrowCR(float duration)
    {
        float elapsed = 0f;
        float progress = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            progress = elapsed / duration;

            transform.localScale = ogScale * progress;

            yield return null;
        }
    }
}
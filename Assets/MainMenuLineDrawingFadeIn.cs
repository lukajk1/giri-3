using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuLineDrawingFadeIn : MonoBehaviour
{
    public float delayBeforeStartingFadeIn;
    public float fadeInTime;
    private Image image;
    private Color originalCol;
    void Start()
    {
        image = GetComponent<Image>();
        originalCol = image.color;
        image.color = new Color(originalCol.r, originalCol.g, originalCol.b, 0f);

        StartCoroutine(FadeInCR());
    }

    private IEnumerator FadeInCR()
    {
        yield return new WaitForSeconds(delayBeforeStartingFadeIn);

        Color color = image.color;

        float timer = 0f;

        while (timer < fadeInTime)
        {
            timer += Time.deltaTime;
            float t = timer / fadeInTime;
            color.a = Mathf.Lerp(0f, 1f, t);
            image.color = color;
            yield return null;
        }

        color.a = 1f;
        image.color = originalCol;
    }
}

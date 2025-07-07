using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class TransitionManager : MonoBehaviour
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private Image image;
    private Coroutine transitionCR;

    public enum Type
    {
        SceneToBlack,
        BlackToScene
    }

    private void Awake()
    {
        canvas.gameObject.SetActive(false);
    }

    public void Transition(Type type, float length, Action onComplete = null)
    {
        // If a transition is running, skip it to its end state
        if (transitionCR != null)
        {
            StopCoroutine(transitionCR);

            image.color = new Color(
                image.color.r,
                image.color.g,
                image.color.b,
                (lastType == Type.SceneToBlack) ? 1f : 0f
            );
            transitionCR = null;
        }

        // Cache type to determine what the end state should be if interrupted
        lastType = type;

        transitionCR = StartCoroutine(TransitionCoroutine(type, length, onComplete));
    }

    private Type lastType;

    private IEnumerator TransitionCoroutine(Type type, float length, Action onComplete)
    {
        canvas.gameObject.SetActive(true);

        Color color = image.color;
        float timer = 0f;

        float startAlpha = (type == Type.SceneToBlack) ? 0f : 1f;
        float endAlpha = (type == Type.SceneToBlack) ? 1f : 0f;

        color.a = startAlpha;
        image.color = color;

        while (timer < length)
        {
            timer += Time.deltaTime;
            float t = timer / length;
            color.a = Mathf.Lerp(startAlpha, endAlpha, t);
            image.color = color;
            yield return null;
        }

        color.a = endAlpha;
        image.color = color;

        onComplete?.Invoke();

        if (type == Type.BlackToScene)
        {
            canvas.gameObject.SetActive(false);
        }

        transitionCR = null;
    }
}

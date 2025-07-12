using System.Collections;
using TMPro;
using UnityEngine;

public class RunErrorNotice : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI messageText;
    public static RunErrorNotice i;

    private void Awake()
    {
        i = this;
        messageText.gameObject.SetActive(false);
    }
    public void CreateMessage(string message)
    {
        StartCoroutine(AnimateCR(message));
    }

    private IEnumerator AnimateCR(string message)
    {
        GameObject instance = Instantiate(messageText.gameObject, messageText.transform.parent);
        instance.SetActive(true);
        TextMeshProUGUI textInstance = instance.GetComponent<TextMeshProUGUI>();
        textInstance.text = message;

        float duration = 1.5f;
        float speed = 50f;
        float elapsed = 0f;
        Color originalColor = textInstance.color;

        RectTransform rectTransform = instance.GetComponent<RectTransform>();

        while (elapsed < duration)
        {
            float delta = Time.deltaTime;
            elapsed += delta;

            rectTransform.anchoredPosition += Vector2.up * speed * delta;

            // Fade out
            float alpha = Mathf.Lerp(1f, 0f, elapsed / duration);
            textInstance.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);

            yield return null;
        }

        Destroy(instance);
    }
}
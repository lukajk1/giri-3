using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CombatNumbersAnimator : MonoBehaviour
{

    private TMP_Text dmgText;
    private float fadeDuration = 0.8f;
    private float height;

    public Color damageColor;
    public Color critColor;
    public Color healColor;

    private Color startingColor;

    public void Awake()
    {
        dmgText = GetComponent<TMP_Text>();
    }
    public void Init(DamageData data)
    {
        height = Random.Range(8f, 12f);

        if (data.isCrit)
        {
            startingColor = critColor;
            dmgText.text = $"*{data.damage.ToString()}";
        }
        else
        {
            startingColor = damageColor;
            dmgText.text = data.damage.ToString();
        }
        
        if (data.damage < 0)
        {
            startingColor = healColor;
            dmgText.text = Mathf.Abs(data.damage).ToString();
        }

        StartCoroutine(FadeOutText());
    }

    private IEnumerator FadeOutText()
    {
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        Vector2 startPosition = rectTransform.anchoredPosition += new Vector2(0, 0f);
        float elapsedTime = 0f;
        float xOffset = Random.Range(-1, 1f);

        while (elapsedTime < fadeDuration)
        {

            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(1, 0, elapsedTime / fadeDuration);
            dmgText.color = new Color(startingColor.r, startingColor.g, startingColor.b, alpha);

            float x = Mathf.Lerp(startPosition.x, startPosition.x + xOffset, elapsedTime / fadeDuration); // Horizontal movement (adjust as needed)
            float y = startPosition.y + height * (4 * elapsedTime / fadeDuration * (1 - elapsedTime / fadeDuration)); // Parabolic movement

            dmgText.rectTransform.anchoredPosition = new Vector2(x, y);
            yield return null;
        }
        Destroy(gameObject);
    }
}

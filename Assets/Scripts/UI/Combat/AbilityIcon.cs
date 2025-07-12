using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AbilityIcon : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private Image radialFill;
    [SerializeField] private TMP_Text countdownText;
    [SerializeField] private TMP_Text textAbilityLabel;
    private Coroutine cooldown;

    private void Awake()
    {
        countdownText.text = "";
        radialFill.fillAmount = 0f;
    }
    public void Init(Sprite abilitySprite, string label)
    {
        icon.sprite = abilitySprite;
        radialFill.sprite = abilitySprite;
        textAbilityLabel.text = label;
    }

    public void Activate(float duration)
    {
        if (cooldown != null)
            StopCoroutine(cooldown);

        cooldown = StartCoroutine(RadialCountdown(duration));
    }

    public bool CooldownUp()
    {
        return cooldown == null;
    }

    private IEnumerator RadialCountdown(float duration)
    {
        float elapsed = 0f;
        radialFill.fillAmount = 1f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            radialFill.fillAmount = Mathf.Lerp(1f, 0f, elapsed / duration);

            float remaining = duration - elapsed;
            if (remaining > 3f)
            {
                countdownText.text = Mathf.FloorToInt(remaining).ToString();
            }
            else
            {
                countdownText.text = remaining.ToString("0.0");
            }

            yield return null;
        }

        radialFill.fillAmount = 0f;
        countdownText.text = "";
        cooldown = null;
    }

}
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AbilityIcon : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private Image radialFill;
    [SerializeField] private TMP_Text countdownText;
    private Coroutine cooldown;


    private void Start()
    {
        countdownText.text = "";
        radialFill.fillAmount = 0f;
    }
    public void Init(Sprite abilitySprite)
    {
        icon.sprite = abilitySprite;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Activate(9f);
        }
    }

    public void Activate(float duration)
    {
        if (cooldown != null)
            StopCoroutine(cooldown);

        cooldown = StartCoroutine(RadialCountdown(duration));
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
                countdownText.text = Mathf.CeilToInt(remaining).ToString();
            }
            else
            {
                countdownText.text = remaining.ToString("0.0");
            }

            yield return null;
        }

        radialFill.fillAmount = 0f;
        countdownText.text = "";
    }

}
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BuffIcon : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private Image radialFill;

    private float duration;
    private BuffData buff;
    private BuffCompleteDelegate onBuffComplete;

    private void Awake()
    {
        radialFill.fillAmount = 0f;
    }

    public void Init(BuffData buff, BuffCompleteDelegate callback)
    {
        this.buff = buff;
        duration = buff.Duration;
        onBuffComplete = callback;

        icon.sprite = buff.Icon;
        StartCoroutine(RadialCountdown(duration));
    }

    private IEnumerator RadialCountdown(float duration)
    {
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            radialFill.fillAmount = Mathf.Lerp(0f, 1f, elapsed / duration);
            yield return null;
        }

        radialFill.fillAmount = 1f;
        onBuffComplete?.Invoke(buff);

        Destroy(gameObject);
    }
}

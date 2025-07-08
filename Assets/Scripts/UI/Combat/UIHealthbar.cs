using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIHealthbar : MonoBehaviour
{
    [SerializeField] protected Image healthbar;
    [SerializeField] protected Image whiteHealth;

    protected Coroutine lerpWhiteHealth;
    protected float tickdownSpeed = 0.35f;
    private Unit unit;

    public void Init(Unit unit)
    {
        this.unit = unit;
        healthbar.fillAmount = 1f;
        whiteHealth.fillAmount = 1f;
    }
    public void RefreshHealthbar()
    {
        healthbar.fillAmount = (float)unit.currentHealth / unit.currentMaxHealth; // cast to float to avoid int division

        if (lerpWhiteHealth == null)
        {
            lerpWhiteHealth = StartCoroutine(LerpWhiteHealth());
        }
        else
        {
            StopCoroutine(lerpWhiteHealth);
            lerpWhiteHealth = StartCoroutine(LerpWhiteHealth());
        }
    }

    protected IEnumerator LerpWhiteHealth()
    {
        float startFill = whiteHealth.fillAmount;
        float endFill = healthbar.fillAmount;
        float elapsed = 0f;

        while (elapsed < tickdownSpeed)
        {
            elapsed += Time.deltaTime;
            whiteHealth.fillAmount = Mathf.Lerp(startFill, endFill, elapsed / tickdownSpeed);
            yield return null;
        }

        whiteHealth.fillAmount = endFill;
        lerpWhiteHealth = null;
    }

    protected void OnDeath()
    {
        gameObject.SetActive(false);
    }

}

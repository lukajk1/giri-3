using System.Collections;
using UnityEngine;

public class Dummy : Unit
{
    protected void Start()
    {
        InstanceStats.Init(this);
        StartCoroutine(AutoHealCoroutine());
    }

    private IEnumerator AutoHealCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(5f);

            int missingHealth = InstanceStats.currentMaxHealth - InstanceStats.currentHealth;
            if (missingHealth > 0)
            {
                Heal(missingHealth);
            }
        }
    }
}
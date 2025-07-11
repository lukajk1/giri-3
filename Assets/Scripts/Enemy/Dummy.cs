using System.Collections;
using UnityEngine;

public class Dummy : Enemy
{
    protected override void Start()
    {
        base.Start();

        StartCoroutine(AutoHealCoroutine());
    }

    private IEnumerator AutoHealCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(5f);

            int missingHealth = currentMaxHealth - currentHealth;
            if (missingHealth > 0)
            {
                Heal(new CombatData(this, this, transform.position, healing: missingHealth));
            }
        }
    }
}
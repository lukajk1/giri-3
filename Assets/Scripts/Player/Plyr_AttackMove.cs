using NUnit.Framework;
using UnityEngine;
using System.Collections;

public class Plyr_AttackMove : MonoBehaviour
{
    Transform cursorTransform;
    Agt_Player player;
    public void Init(Agt_Player player, Transform cursorTransform)
    {
        this.player = player;
        this.cursorTransform = cursorTransform;
    }

    void Update()
    {
        if (Input.GetButtonDown("AttackMove"))
        {
            Enemy[] enemies = FindObjectsByType<Enemy>(FindObjectsSortMode.None);

            float closest = 999f;
            Enemy closestEnemy = null;

            foreach (Enemy enemy in enemies)
            {
                float dist = Vector3.Distance(enemy.transform.position, cursorTransform.position);
                if (dist < closest)
                {
                    dist = closest;
                    closestEnemy = enemy;
                }
            }

            if (closestEnemy != null && closest <= player.AttackRange)
            {
                closestEnemy.Damage(player, new Damage(50f));
            }
        }
    }
}

 using System.Collections;
using System.Diagnostics;
using UnityEngine;

[RequireComponent(typeof(TrailRenderer))]
public class AttackTracer : MonoBehaviour
{
    TrailRenderer trail;
    float speed = 20f;
    Enemy enemyToDamage;

    void Start()
    {
        trail = GetComponent<TrailRenderer>();
        trail.enabled = false;
    }

    public void Shoot(Transform target, Enemy enemyToDamage)
    {
        this.enemyToDamage = enemyToDamage;
        trail.enabled = true;
        StartCoroutine(ShootingCR(target));
    }

    IEnumerator ShootingCR(Transform target)
    {
        trail.enabled = false;
        ResetPosition();
        trail.enabled = true;

        yield return null;

        while (target != null && Vector3.SqrMagnitude(target.position - transform.position) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            yield return null;
        }

        // null check before applying damage
        if (target != null)
        {
            CombatData dmg = new(target.position, CommonAssets.i.Player.currentDamage);
            enemyToDamage.Damage(dmg);
            SoundData sound = new(clip: EivelList.i.basicAttackHit_1);
            SoundManagerSO.PlaySoundFXClip(sound);
        }
        
        gameObject.SetActive(false);
    }

    public void ResetPosition()
    {
        transform.position = CommonAssets.i.Player.transform.position + new Vector3(0, 1.5f, 0);
    }
}
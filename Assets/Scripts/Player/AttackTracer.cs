 using System.Collections;
using System.Diagnostics;
using UnityEngine;

[RequireComponent(typeof(TrailRenderer))]
public class AttackTracer : MonoBehaviour
{
    TrailRenderer trail;
    float speed = 20f;

    void Start()
    {
        trail = GetComponent<TrailRenderer>();
        trail.enabled = false;
    }

    public void Shoot(Vector3 targetPoint)
    {
        trail.enabled = true;
        StartCoroutine(ShootingCR(targetPoint));
    }

    IEnumerator ShootingCR(Vector3 targetPoint)
    {
        trail.enabled = false;
        ResetPosition();
        trail.enabled = true;

        yield return null;

        while (Vector3.SqrMagnitude(targetPoint - transform.position) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPoint, speed * Time.deltaTime);
            yield return null;
        }

        CombatData dmg = new(transform.position, CommonAssets.i.Player.currentDamage);
        FindFirstObjectByType<Dummy>().Damage(dmg);

        SoundData sound = new(clip: EivelList.i.basicAttackHit_1);
        SoundManagerSO.PlaySoundFXClip(sound);
        
        gameObject.SetActive(false);
    }

    public void ResetPosition()
    {
        transform.position = CommonAssets.i.Player.transform.position + new Vector3(0, 1.5f, 0);
    }
}
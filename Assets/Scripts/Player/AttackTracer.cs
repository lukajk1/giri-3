 using System.Collections;
using System.Diagnostics;
using UnityEngine;

[RequireComponent(typeof(TrailRenderer))]
public class AttackTracer : MonoBehaviour
{
    TrailRenderer trail;
    float speed = 20f;
    Unit targetUnit;
    CombatData data;

    void Start()
    {
        trail = GetComponent<TrailRenderer>();
        trail.enabled = false;
    }

    public void Init(CombatData data)
    {
        this.targetUnit = data.targetUnit;
        this.data = data;

        trail.enabled = true;
        StartCoroutine(ShootingCR(data.pos));
    }

    IEnumerator ShootingCR(Vector3 pos)
    {
        trail.enabled = false;
        ResetPosition();
        trail.enabled = true;

        yield return null;

        while (Vector3.SqrMagnitude(pos - transform.position) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, pos, speed * Time.deltaTime);
            yield return null;
        }

        // null check before applying damage
        if (targetUnit != null)
        {
            targetUnit.Damage(data);
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
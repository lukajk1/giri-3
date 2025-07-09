using NUnit.Framework;
using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices.WindowsRuntime;

public class PlyrBasicAttack : MonoBehaviour
{
    [SerializeField] GameObject tracerPrefab;

    private Coroutine fire;
    private Player player;
    private Animator animator;
    public void Init(Player player, Animator animator)
    {
        this.player = player;
        this.animator = animator;
    }

    void Update()
    {
        if (Input.GetButtonDown("AttackMove"))
        {
            TryAttack();
        }
    }

    private void TryAttack()
    {
        int layerMask = 1 << 0;
        Collider[] colliders = Physics.OverlapSphere(player.transform.position, player.currentAttackRange * 1.1f, layerMask);

        if (!RunUtilities.CursorToWorldPos(out Vector3 pointToCheckDistFrom)) return;
        if (fire != null) return;

        FindAnyObjectByType<AttackCursor>().MoveCommand(pointToCheckDistFrom);

        float closestDistance = 999f;
        Collider closestEnemy = null;

        foreach (Collider col in colliders)
        {
            if (col.GetComponent<Enemy>() == null) continue;

            float dist = Vector3.Distance(col.transform.position, pointToCheckDistFrom);
            if (dist < closestDistance)
            {
                closestDistance = dist;
                closestEnemy = col;
            }
        }

        if (closestEnemy != null && closestDistance <= player.currentAttackRange)
        {
            animator.SetTrigger("Attack");
            player.Movement.Attack(closestEnemy.transform.position);

            fire = StartCoroutine(Fire(closestEnemy));
        }
    }

    private IEnumerator Fire(Collider closestEnemy)
    {
        yield return new WaitForSeconds(0.416f / player.currentAttackSpeed); // releases on frame 10 @ 24fps = 0.416s. Scaled proportionally with attackspeed

        TracerManager.i.FireTracer(closestEnemy.transform, closestEnemy.GetComponent<Enemy>());

        SoundData sound = new(clip: EivelList.i.basicAttack_1);
        SoundManagerSO.PlaySoundFXClip(sound);

        fire = null;
    }
}

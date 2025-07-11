using NUnit.Framework;
using UnityEngine;
using System.Collections;

public class PlyrBasicAttack : MonoBehaviour
{
    [SerializeField] GameObject tracerPrefab;

    private const float attackReleaseFrameNum = 8f; 

    private Coroutine attackWindup;
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

        if (Input.GetButtonDown("MoveClick") && attackWindup != null)
        {
            StopCoroutine(attackWindup);
            attackWindup = null;
        }
    }

    private void TryAttack()
    {
        int layerMask = 1 << 0;
        Collider[] colliders = Physics.OverlapSphere(player.transform.position, player.currentAttackRange * 1.1f, layerMask);

        if (!RunUtil.CursorToWorldPos(out Vector3 pointToCheckDistFrom)) return;
        if (attackWindup != null) return;

        FindAnyObjectByType<AttackCursor>().MoveCommand(pointToCheckDistFrom);

        float closestDistance = 999f;
        Collider closestEnemy = null;

        foreach (Collider col in colliders)
        {
            Enemy enemy = col.GetComponent<Enemy>();

            if (enemy == null || !enemy.Attackable) continue;

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

            attackWindup = StartCoroutine(Fire(closestEnemy));
        }
    }

    private IEnumerator Fire(Collider closestEnemy)
    {
        yield return new WaitForSeconds(RunUtil.AnimFramesToSecs(attackReleaseFrameNum) / player.currentAttackSpeed); // scale with attackspeed

        CombatData data = new(player, closestEnemy.GetComponent<Enemy>(), closestEnemy.transform.position, damage: player.currentDamage);
        TracerManager.i.FireTracer(data);

        SoundData sound = new(clip: EivelList.i.basicAttack_1);
        SoundManagerSO.PlaySoundFXClip(sound);

        attackWindup = null;
    }
}

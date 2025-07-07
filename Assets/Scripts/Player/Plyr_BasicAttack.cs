using NUnit.Framework;
using UnityEngine;
using System.Collections;

public class Plyr_BasicAttack : MonoBehaviour
{
    [SerializeField] GameObject tracerPrefab;

    Player player;
    Animator animator;
    public void Init(Player player, Animator animator)
    {
        this.player = player;
        this.animator = animator;
    }

    void Update()
    {
        if (Input.GetButtonDown("AttackMove"))
        {
            animator.SetTrigger("Attack");
            player.Movement.Attack(Vector3.zero);

            Collider[] colliders = Physics.OverlapSphere(player.transform.position, player.InstanceStats.currentAttackRange * 1.1f);

            StartCoroutine(Fire());

            //Enemy[] enemies = FindObjectsByType<Enemy>(FindObjectsSortMode.None);

            //float closest = 999f;
            //Enemy closestEnemy = null;

            //foreach (Enemy enemy in enemies)
            //{
            //    float dist = Vector3.Distance(enemy.transform.position, cursorTransform.position);
            //    if (dist < closest)
            //    {
            //        dist = closest;
            //        closestEnemy = enemy;
            //    }
            //}

            //if (closestEnemy != null && closest <= player.AttackRange)
            //{
            //    closestEnemy.Damage(player, new Damage(50f));
            //}
        }
    }
    private IEnumerator Fire()
    {
        yield return new WaitForSeconds(0.416f / player.InstanceStats.currentAttackSpeed); // releases on frame 10 @ 24fps = 0.416s. Scaled proportionally with attackspeed

        TracerManager.i.FireTracer(new Vector3(0, 1.5f, 0));

        SoundData sound = new(clip: EivelList.i.basicAttack_1);
        SoundManagerSO.PlaySoundFXClip(sound);
    }
}

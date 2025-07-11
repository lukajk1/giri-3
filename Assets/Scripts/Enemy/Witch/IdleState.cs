
using NUnit.Framework.Internal;
using UnityEngine;
using UnityEngine.AI;

public class IdleState : MonoBehaviour, IState
{
    private Unit unit;
    private WitchController controller;

    private float panicRange = 5f; // if player within this range run!
    private float prefRange = 7f; 
    public void Init(WitchController controller)
    {
        this.unit = controller.unit;
        this.controller = controller;
    }

    public void Enter() 
    {
        controller.stateDisplay.SetText("idle");
        controller.animator.SetTrigger("Idle");
    }

    public void Tick()
    {
        float distFromPlayer = Vector3.Distance(CommonAssets.i.Player.transform.position, unit.transform.position);
        Vector3 currentPos = unit.transform.position;
        Vector3 playerPos = CommonAssets.i.Player.transform.position;

        // attacking takes priority over repositioning
        if (distFromPlayer <= unit.currentAttackRange && controller.AttackUp())
        {
            controller.ChangeState(controller.attackState);
        }

        else if (distFromPlayer > unit.currentAttackRange)
        {
            Vector3 direction = (playerPos - currentPos).normalized;
            float distance = distFromPlayer;
            float clampedDistance = Mathf.Min(prefRange, distance);
            Vector3 dest = currentPos + direction * clampedDistance;

            TrySetDestination(dest);
        }

        else if (distFromPlayer < panicRange)
        {
            Vector3 direction = (currentPos - playerPos).normalized;
            Vector3 dest = playerPos + direction * prefRange;

            TrySetDestination(dest);
        }

        Vector3 rotDirection = playerPos - unit.transform.position;
        rotDirection.y = 0f;
        if (rotDirection == Vector3.zero) return;
        unit.transform.rotation = Quaternion.LookRotation(rotDirection);
    }

    public void Exit() { }
    private void TrySetDestination(Vector3 destination)
    {
        NavMeshHit hit;
        if (NavMesh.SamplePosition(destination, out hit, 3.0f, NavMesh.AllAreas))
        {
            controller.navAgent.SetDestination(hit.position);
            controller.ChangeState(controller.moveState);
        }
    }

}

using UnityEngine;
using UnityEngine.AI;

public class MoveState : MonoBehaviour, IState
{
    private Unit unit;
    private WitchController controller;
    private NavMeshAgent agent;
    public void Init(WitchController controller)
    {
        this.unit = controller.unit;
        this.controller = controller;
        agent = controller.navAgent;
    }

    public void Enter()
    {
        controller.stateDisplay.SetText("move");
        controller.animator.SetBool("IsMoving", true);
    }

    public void Tick()
    {
        float distFromPlayer = Vector3.Distance(CommonAssets.i.Player.transform.position, unit.transform.position);

        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            controller.ChangeState(controller.idleState);
        }
        else if (distFromPlayer >= IdleState.prefRange)
        {
            controller.ChangeState(controller.idleState);
        }

    }

    public void Exit() 
    {
        controller.animator.SetBool("IsMoving", false);
    }
}

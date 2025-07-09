using UnityEngine;

public class ChaseState : IState
{
    private Unit unit;
    private WitchController controller;
    public ChaseState(WitchController controller)
    {
        this.unit = controller.unit;
        this.controller = controller;
    }

    public void Enter()
    {
        Debug.Log("Chase entered");
        controller.animator.SetTrigger("Move");
        controller.animator.SetBool("IsMoving", true);
    }

    public void Tick()
    {
        float dist = Vector3.Distance(CommonAssets.i.Player.transform.position, controller.transform.position);

        if (dist <= unit.currentAttackRange)
        {
            controller.MoveToState(new IdleState(controller));
            controller.navAgent.destination = controller.transform.position;
        }
        else
        {
            controller.navAgent.destination = CommonAssets.i.Player.transform.position;
        }

    }

    public void Exit() 
    {
        
    }
}

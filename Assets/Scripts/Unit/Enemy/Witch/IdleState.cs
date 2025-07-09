
using UnityEngine;

public class IdleState : IState
{
    private Unit unit;
    private WitchController controller;
    public IdleState(WitchController controller)
    {
        this.unit = controller.unit;
        this.controller = controller;
    }

    public void Enter() 
    {
        Debug.Log("idle entered");
        controller.animator.SetTrigger("Idle");
        controller.animator.SetBool("IsMoving", false);
    }

    public void Tick()
    {
        float distFromPlayer = Vector3.Distance(CommonAssets.i.Player.transform.position, controller.transform.position);

        //if (controller.AttackUp())
        //{
        //    if (distFromPlayer <= attackRange)
        //    {
        //        controller.MoveToState(new CastState(controller));
        //    }
        //    else
        //    {
        //        controller.MoveToState(new ChaseState(controller));
        //    }   
        //}

        if (distFromPlayer > unit.currentAttackRange)
        {
            controller.MoveToState(new ChaseState(controller));
        }

    }

    public void Exit() { }
}

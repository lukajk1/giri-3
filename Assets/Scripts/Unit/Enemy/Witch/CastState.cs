using UnityEngine;
public class CastState : IState
{
    private Unit unit;
    private WitchController controller;

    public CastState(WitchController controller)
    {
        this.unit = controller.unit;
        this.controller = controller;
    }

    public void Enter()
    {
        controller.Attack(() => controller.MoveToState(new IdleState(controller)));
    }

    public void Tick() { }

    public void Exit() { }
}

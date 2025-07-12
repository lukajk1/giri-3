using UnityEngine;
using UnityEngine.AI;

public class RootedState : MonoBehaviour, IState
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
        controller.animator.SetTrigger("Idle");
    }

    public void Tick()
    {

    }

    public void Exit() 
    {
    }
}

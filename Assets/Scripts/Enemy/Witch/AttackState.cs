using UnityEngine;
public class AttackState : MonoBehaviour, IState
{
    [SerializeField] private GameObject castPrefab;

    private Unit unit;
    private WitchController controller;

    public void Init(WitchController controller)
    {
        this.unit = controller.unit;
        this.controller = controller;
    }

    public void Enter()
    {
        controller.stateDisplay.SetText("attack");
        controller.animator.SetTrigger("Attack");
        Instantiate(castPrefab, CommonAssets.i.Player.transform.position, Quaternion.identity);
        controller.Attack(() => controller.ChangeState(controller.idleState));
    }

    public void Tick() { }

    public void Exit() { }
}
